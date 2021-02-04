﻿// <auto-generated />
using System;
using CondominioApp.Comunicados.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Comunicados.App.Migrations
{
    [DbContext(typeof(ComunicadoContextDB))]
    [Migration("20210204204025_unidadeComunicado")]
    partial class unidadeComunicado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Comunicados.App.Models.Comunicado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CriadoPelaAdministradora")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeRealizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeCondominio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("TemAnexos")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Visibilidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Comunicados");
                });

            modelBuilder.Entity("CondominioApp.Comunicados.App.Models.UnidadeComunicado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Andar")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("ComunicadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoGrupo")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ComunicadoId");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("CondominioApp.Comunicados.App.Models.UnidadeComunicado", b =>
                {
                    b.HasOne("CondominioApp.Comunicados.App.Models.Comunicado", "Comunicado")
                        .WithMany("Unidades")
                        .HasForeignKey("ComunicadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
