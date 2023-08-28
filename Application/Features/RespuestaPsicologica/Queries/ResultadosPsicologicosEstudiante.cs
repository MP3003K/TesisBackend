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

            CalcularResultadosEvaluacionPsicologica(escalasPsicologicasDto);
            return new Response<RespuestasEstudianteDto>(respuestasEstudianteDto);
        }



        private static void CalcularResultadosEvaluacionPsicologica(IList<EscalaPsicologicaDto> escalasPsicologicasDto)
        {
            foreach (var escalaDto in escalasPsicologicasDto)
            {
                double? promedioEscala = null;

                if (escalaDto.IndicadoresPsicologicos != null && escalaDto.IndicadoresPsicologicos.Any())
                {
                    foreach (var indicador in escalaDto.IndicadoresPsicologicos)
                    {
                        if (indicador != null)
                        {
                            indicador.PromedioIndicador = indicador.PreguntasPsicologicas?
                                .Where(i => i.RespuestasPsicologicas != null && i.RespuestasPsicologicas.Any())
                                .Sum(i =>
                                {
                                    var primeraRespuesta = i?.RespuestasPsicologicas?.FirstOrDefault();
                                    if (primeraRespuesta != null && double.TryParse(primeraRespuesta.Respuesta, out double respuestaNumero))
                                        return respuestaNumero;
                                    return 0.0;
                                });
                            indicador.PreguntasPsicologicas = null;
                        }
                    }

                    var totalPromedioIndicadores = escalaDto.IndicadoresPsicologicos.Sum(i => i.PromedioIndicador ?? 0.0);
                    promedioEscala = Math.Round(totalPromedioIndicadores / escalaDto.IndicadoresPsicologicos.Count, 4);
                }
                escalaDto.PromedioEscala = promedioEscala;
            }
        }

    }
}
