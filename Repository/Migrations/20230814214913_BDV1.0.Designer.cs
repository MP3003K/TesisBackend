﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.Context;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230814214913_BDV1.0")]
    partial class BDV10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Acceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accesos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DocenteId")
                        .HasColumnType("integer");

                    b.Property<int>("EscuelaId")
                        .HasColumnType("integer");

                    b.Property<int>("GradoId")
                        .HasColumnType("integer");

                    b.Property<string>("Secccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DocenteId");

                    b.HasIndex("EscuelaId");

                    b.HasIndex("GradoId");

                    b.ToTable("Aulas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DimensionPsicologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EvaluacionPsicologicaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EvaluacionPsicologicaId");

                    b.ToTable("DimensionesPsicologicas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Docente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.ToTable("Docentes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EscalaPsicologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DimensionId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DimensionId");

                    b.ToTable("EscalasPsicologicas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Escuela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoModular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Escuelas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoEstudiante")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.ToTable("Estudiantes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EstudianteAula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AulaId")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("EstudiantesAulas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EvaluacionesPsicologicas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologicaAula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AulaId")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("(No inicio= N, En proceso = P, Finalizo= F)");

                    b.Property<int>("EvaluacionPsicologicaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UnidadId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("EvaluacionPsicologicaId");

                    b.HasIndex("UnidadId");

                    b.ToTable("EvaluacionesPsicologicasAula", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologicaEstudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("(No inicio= N, En proceso = P, Finalizo= F)");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("integer");

                    b.Property<int>("EvaluacionAulaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("EvaluacionAulaId");

                    b.ToTable("EvaluacionesPsicologicasEstudiante", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NGrado")
                        .HasColumnType("integer");

                    b.Property<int>("NivelId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NivelId");

                    b.ToTable("Grados", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.GradoEvaPsicologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EvaPsiId")
                        .HasColumnType("integer");

                    b.Property<int>("GradoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EvaPsiId");

                    b.HasIndex("GradoId");

                    b.ToTable("GradosEvaPsicologicas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.IndicadorPsicologico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EscalaPsicologicaId")
                        .HasColumnType("integer");

                    b.Property<string>("NombreIndicador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EscalaPsicologicaId");

                    b.ToTable("IndicadoresPsicologicos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NNivel")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Niveles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DNI")
                        .HasColumnType("integer");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Personas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PreguntaPsicologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IndicadorPsicologicoId")
                        .HasColumnType("integer");

                    b.Property<int?>("NPregunta")
                        .HasColumnType("integer");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IndicadorPsicologicoId");

                    b.ToTable("PreguntasPsicologicas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RespuestaPsicologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EvaPsiEstId")
                        .HasColumnType("integer");

                    b.Property<int>("PreguntaPsicologicaId")
                        .HasColumnType("integer");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EvaPsiEstId");

                    b.HasIndex("PreguntaPsicologicaId");

                    b.ToTable("RespuestasPsicologicas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RolAcceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccesoId")
                        .HasColumnType("integer");

                    b.Property<int>("RolId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccesoId");

                    b.HasIndex("RolId");

                    b.ToTable("RolesAccesos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RolUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RolId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RolesUsuarios", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Unidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Año")
                        .HasColumnType("integer");

                    b.Property<int>("EscuelaId")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NUnidad")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EscuelaId");

                    b.ToTable("Unidades", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonaId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Aula", b =>
                {
                    b.HasOne("Domain.Entities.Docente", null)
                        .WithMany("Aulas")
                        .HasForeignKey("DocenteId");

                    b.HasOne("Domain.Entities.Escuela", "Escuela")
                        .WithMany("Aulas")
                        .HasForeignKey("EscuelaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Grado", "Grado")
                        .WithMany("Aulas")
                        .HasForeignKey("GradoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escuela");

                    b.Navigation("Grado");
                });

            modelBuilder.Entity("Domain.Entities.DimensionPsicologica", b =>
                {
                    b.HasOne("Domain.Entities.EvaluacionPsicologica", "EvaluacionPsicologica")
                        .WithMany("DimensionesPsicologicas")
                        .HasForeignKey("EvaluacionPsicologicaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EvaluacionPsicologica");
                });

            modelBuilder.Entity("Domain.Entities.Docente", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithOne("Docente")
                        .HasForeignKey("Domain.Entities.Docente", "PersonaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.EscalaPsicologica", b =>
                {
                    b.HasOne("Domain.Entities.DimensionPsicologica", "DimensionPsicologica")
                        .WithMany("EscalasPsicologicas")
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DimensionPsicologica");
                });

            modelBuilder.Entity("Domain.Entities.Estudiante", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithOne("Estudiante")
                        .HasForeignKey("Domain.Entities.Estudiante", "PersonaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.EstudianteAula", b =>
                {
                    b.HasOne("Domain.Entities.Aula", "Aula")
                        .WithMany("EstudiantesAulas")
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Estudiante", "Estudiante")
                        .WithMany("EstudiantesAulas")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologicaAula", b =>
                {
                    b.HasOne("Domain.Entities.Aula", "Aula")
                        .WithMany("EvaluacionesPsicologicasAula")
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.EvaluacionPsicologica", "EvaluacionPsicologica")
                        .WithMany("EvaluacionesPsicologicasAula")
                        .HasForeignKey("EvaluacionPsicologicaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Unidad", "Unidad")
                        .WithMany("EvaluacionesPsicologicasAula")
                        .HasForeignKey("UnidadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("EvaluacionPsicologica");

                    b.Navigation("Unidad");
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologicaEstudiante", b =>
                {
                    b.HasOne("Domain.Entities.Estudiante", "Estudiante")
                        .WithMany("EvaluacionesEstudiante")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.EvaluacionPsicologicaAula", "EvaluacionAula")
                        .WithMany("EvaluacionesPsicologicasEstudiante")
                        .HasForeignKey("EvaluacionAulaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("EvaluacionAula");
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.HasOne("Domain.Entities.Nivel", "Nivel")
                        .WithMany("Grados")
                        .HasForeignKey("NivelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Nivel");
                });

            modelBuilder.Entity("Domain.Entities.GradoEvaPsicologica", b =>
                {
                    b.HasOne("Domain.Entities.EvaluacionPsicologica", "EvaluacionPsicologica")
                        .WithMany("GradosEvaPsicologicas")
                        .HasForeignKey("EvaPsiId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Grado", "Grado")
                        .WithMany("GradosEvaPsicologicas")
                        .HasForeignKey("GradoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EvaluacionPsicologica");

                    b.Navigation("Grado");
                });

            modelBuilder.Entity("Domain.Entities.IndicadorPsicologico", b =>
                {
                    b.HasOne("Domain.Entities.EscalaPsicologica", "EscalaPsicologica")
                        .WithMany("IndicadoresPsicologicos")
                        .HasForeignKey("EscalaPsicologicaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EscalaPsicologica");
                });

            modelBuilder.Entity("Domain.Entities.PreguntaPsicologica", b =>
                {
                    b.HasOne("Domain.Entities.IndicadorPsicologico", "IndicadorPsicologico")
                        .WithMany("PreguntasPsicologicas")
                        .HasForeignKey("IndicadorPsicologicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IndicadorPsicologico");
                });

            modelBuilder.Entity("Domain.Entities.RespuestaPsicologica", b =>
                {
                    b.HasOne("Domain.Entities.EvaluacionPsicologicaEstudiante", "EvaluacionPsicologicaEstudiante")
                        .WithMany("RespuestasPsicologicas")
                        .HasForeignKey("EvaPsiEstId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PreguntaPsicologica", "PreguntaPsicologica")
                        .WithMany("RespuestasPsicologicas")
                        .HasForeignKey("PreguntaPsicologicaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EvaluacionPsicologicaEstudiante");

                    b.Navigation("PreguntaPsicologica");
                });

            modelBuilder.Entity("Domain.Entities.RolAcceso", b =>
                {
                    b.HasOne("Domain.Entities.Acceso", "Acceso")
                        .WithMany("RolesAccesos")
                        .HasForeignKey("AccesoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolesAccesos")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Acceso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Domain.Entities.RolUsuario", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Unidad", b =>
                {
                    b.HasOne("Domain.Entities.Escuela", "Escuela")
                        .WithMany("Unidades")
                        .HasForeignKey("EscuelaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Escuela");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithOne("Usuario")
                        .HasForeignKey("Domain.Entities.Usuario", "PersonaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.Acceso", b =>
                {
                    b.Navigation("RolesAccesos");
                });

            modelBuilder.Entity("Domain.Entities.Aula", b =>
                {
                    b.Navigation("EstudiantesAulas");

                    b.Navigation("EvaluacionesPsicologicasAula");
                });

            modelBuilder.Entity("Domain.Entities.DimensionPsicologica", b =>
                {
                    b.Navigation("EscalasPsicologicas");
                });

            modelBuilder.Entity("Domain.Entities.Docente", b =>
                {
                    b.Navigation("Aulas");
                });

            modelBuilder.Entity("Domain.Entities.EscalaPsicologica", b =>
                {
                    b.Navigation("IndicadoresPsicologicos");
                });

            modelBuilder.Entity("Domain.Entities.Escuela", b =>
                {
                    b.Navigation("Aulas");

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("Domain.Entities.Estudiante", b =>
                {
                    b.Navigation("EstudiantesAulas");

                    b.Navigation("EvaluacionesEstudiante");
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologica", b =>
                {
                    b.Navigation("DimensionesPsicologicas");

                    b.Navigation("EvaluacionesPsicologicasAula");

                    b.Navigation("GradosEvaPsicologicas");
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologicaAula", b =>
                {
                    b.Navigation("EvaluacionesPsicologicasEstudiante");
                });

            modelBuilder.Entity("Domain.Entities.EvaluacionPsicologicaEstudiante", b =>
                {
                    b.Navigation("RespuestasPsicologicas");
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Navigation("Aulas");

                    b.Navigation("GradosEvaPsicologicas");
                });

            modelBuilder.Entity("Domain.Entities.IndicadorPsicologico", b =>
                {
                    b.Navigation("PreguntasPsicologicas");
                });

            modelBuilder.Entity("Domain.Entities.Nivel", b =>
                {
                    b.Navigation("Grados");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("Docente");

                    b.Navigation("Estudiante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.PreguntaPsicologica", b =>
                {
                    b.Navigation("RespuestasPsicologicas");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("RolesAccesos");

                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.Unidad", b =>
                {
                    b.Navigation("EvaluacionesPsicologicasAula");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("RolesUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
