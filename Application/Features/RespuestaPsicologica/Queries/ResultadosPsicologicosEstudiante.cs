using Application.Exceptions;
using Application.Wrappers;
using AutoMapper;
using Contracts.Repositories;
using Domain.Entities;
using DTOs;
using MediatR;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RespuestaPsicologica.Queries
{
    public class ResultadosPsicologicosEstudiantesQuery: IRequest<Response<RespuestasEstudianteDto>>
    {
        public int EstudianteId { get; set; }
        public int UnidadId { get; set; }

        public int AulaId { get; set; }
        public int DimensionId { get; set; }

    }
    public class ResultadosPsicologicosEstudiantesHandler: IRequestHandler<ResultadosPsicologicosEstudiantesQuery, Response<RespuestasEstudianteDto>>
    {
        private readonly IEvaluacionPsicologicaRepository _evaluacionPsicologicaRepository;
        private readonly IEvaluacionPsicologicaEstudianteRepository _evaluacionPsicologicaEstudianteRepository;
        private readonly IEvaluacionPsicologicaAulaRepository _evaluacionPsicologicaAulaRepository;
        private readonly IMapper _mapper;
        
        public ResultadosPsicologicosEstudiantesHandler(
            IEvaluacionPsicologicaRepository evaluacionPsicologicaRepository,
            IEvaluacionPsicologicaAulaRepository evaluacionPsicologicaAulaRepository,
            IEvaluacionPsicologicaEstudianteRepository evaluacionPsicologicaEstudianteRepository,
            IMapper mapper)
        {
            _evaluacionPsicologicaRepository = evaluacionPsicologicaRepository;
            _evaluacionPsicologicaAulaRepository = evaluacionPsicologicaAulaRepository;
            _evaluacionPsicologicaEstudianteRepository = evaluacionPsicologicaEstudianteRepository;
            _mapper = mapper;
        }
        public async Task<Response<RespuestasEstudianteDto>> Handle(ResultadosPsicologicosEstudiantesQuery request, CancellationToken cancellationToken)
        {

          
            var evaPsiAula = await _evaluacionPsicologicaAulaRepository.EvaPsiAulaPorAulaIdYUnidadId(request.AulaId, request.UnidadId) ?? throw new EntidadNoEncontradaException(nameof(EvaluacionPsicologicaAula));
            var evaPsiEstId = await _evaluacionPsicologicaEstudianteRepository.EvaPsiEstudianteIdPorEstudianteId(evaPsiAula.Id, request.EstudianteId) ?? throw new EntidadNoEncontradaException(nameof(EvaluacionPsicologicaEstudiante));
            
            if (evaPsiAula.EvaluacionPsicologica == null)
                throw new EntidadNoEncontradaException(nameof(EvaluacionPsicologica));

            if (evaPsiAula.EvaluacionPsicologica.Id == 2 && request.DimensionId == 1)
                request.DimensionId = 3;
            else if (evaPsiAula.EvaluacionPsicologica.Id == 2 && request.DimensionId == 2)
                request.DimensionId = 4;
            
            var respuestasEscalasPsicologicas = await _evaluacionPsicologicaRepository.ResultadosPsicologicosEstudiante(evaPsiEstId, evaPsiAula.EvaluacionPsicologicaId, request.DimensionId) ?? throw new EntidadNoPuedeSerEliminadaPorSusDependenciasException(nameof(EvaluacionPsicologicaEstudiante));

            var escalasPsicologicasDto = _mapper.Map<IList<EscalaPsicologicaDto>>(respuestasEscalasPsicologicas);
            var respuestasEstudianteDto = new RespuestasEstudianteDto{EscalasPsicologicas = escalasPsicologicasDto};

            // Funcion para poder guardar los resultados en las escalas
            int countIndicadoresEnInicio = 0, countIndicadoresEnProceso = 0, countIndicadoresSatisfactorio = 0;
            int countEscalasEnInicio = 0, countEscalasEnProceso = 0, countEscalasSatisfactorio = 0;

            foreach (var escalaDto in respuestasEstudianteDto.EscalasPsicologicas)
            {
                double? promedioEscala = null;

                if (escalaDto.IndicadoresPsicologicos != null && escalaDto.IndicadoresPsicologicos.Any())
                {
                    foreach (var indicador in escalaDto.IndicadoresPsicologicos)
                    {

                        indicador.PromedioIndicador = indicador?.PreguntasPsicologicas?.Sum(i =>
                        {
                            if(i.RespuestasPsicologicas != null)
                            {
                                if (double.TryParse(i.RespuestasPsicologicas.FirstOrDefault()?.Respuesta, out double respuestaNumero))
                                return respuestaNumero;
                            }
                            return 0.0; // Si no se puede convertir, se suma 0.
                        });

                        // Contar indicadores en cada categoría
                        if (indicador?.PromedioIndicador <= 1)
                            countIndicadoresEnInicio++;
                        else if (indicador?.PromedioIndicador > 1 && indicador.PromedioIndicador < 3)
                            countIndicadoresEnProceso++;
                        else if (indicador?.PromedioIndicador >= 3)
                            countIndicadoresSatisfactorio++;
                    }
                    var totalPromedioIndicadores = escalaDto.IndicadoresPsicologicos.Sum(i => i.PromedioIndicador ?? 0.0);
                    promedioEscala = Math.Round(totalPromedioIndicadores / escalaDto.IndicadoresPsicologicos.Count, 4);
                    // Contar escalas en cada categoría
                    if (promedioEscala <= 1)
                        countEscalasEnInicio++;
                    else if (promedioEscala > 1 && promedioEscala < 3)
                        countEscalasEnProceso++;
                    else if (promedioEscala >= 3)
                        countEscalasSatisfactorio++;
                }
                escalaDto.PromedioEscala = promedioEscala;
            }
            respuestasEstudianteDto.TotalEscalasEnInicio = countEscalasEnInicio;
            respuestasEstudianteDto.TotalEscalasEnProceso = countEscalasEnProceso;
            respuestasEstudianteDto.TotalEscalasSatisfactorio = countEscalasSatisfactorio;
            respuestasEstudianteDto.TotalIndicadoresEnInicio = countIndicadoresEnInicio;
            respuestasEstudianteDto.TotalIndicadoresEnProceso = countIndicadoresEnProceso;
            respuestasEstudianteDto.TotalIndicadoresSatisfactorio = countIndicadoresSatisfactorio;

            return new Response<RespuestasEstudianteDto>(respuestasEstudianteDto);
        }
    }
}
