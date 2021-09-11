﻿// <auto-generated />
using System;
using CondominioApp.Principal.Infra.DataQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.ReservaAreaComum.Infra.Migrations.ReservaAreaComumQueryContextDBMigrations
{
    [DbContext(typeof(ReservaAreaComumQueryContextDB))]
    [Migration("20210104162531_CriaReservaFlat")]
    partial class CriaReservaFlat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.ReservaAreaComum.Domain.FlatModel.ReservaFlat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AndarUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("AreaComumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit");

                    b.Property<bool>("Cancelada")
                        .HasColumnType("bit");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeRealizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoGrupoUnidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaNaFila")
                        .HasColumnType("bit");

                    b.Property<string>("HoraFim")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("HoraInicio")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Justificativa")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeAreaComum")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeCondominio")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Origem")
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(14,2)");

                    b.Property<bool>("ReservadoPelaAdministracao")
                        .HasColumnType("bit");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ReservasFlat");
                });
#pragma warning restore 612, 618
        }
    }
}