﻿// <auto-generated />
using System;
using CondominioApp.ArquivoDigital.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.ArquivoDigital.App.Migrations
{
    [DbContext(typeof(ArquivoDigitalContextDB))]
    [Migration("20210518124024_Subpastas")]
    partial class Subpastas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.ArquivoDigital.App.Models.Arquivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnexadoPorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("PastaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Publico")
                        .HasColumnType("bit");

                    b.Property<double>("Tamanho")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PastaId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("CondominioApp.ArquivoDigital.App.Models.Pasta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoriaDaPastaDeSistema")
                        .HasColumnType("int");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<bool>("PastaDoSistema")
                        .HasColumnType("bit");

                    b.Property<Guid>("PastaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("PastaRaiz")
                        .HasColumnType("bit");

                    b.Property<bool>("Publica")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PastaId");

                    b.HasIndex("Titulo", "CondominioId")
                        .IsUnique();

                    b.ToTable("Pastas");
                });

            modelBuilder.Entity("CondominioApp.ArquivoDigital.App.Models.Arquivo", b =>
                {
                    b.HasOne("CondominioApp.ArquivoDigital.App.Models.Pasta", null)
                        .WithMany("Arquivos")
                        .HasForeignKey("PastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CondominioApp.ArquivoDigital.App.ValueObjects.NomeArquivo", "Nome", b1 =>
                        {
                            b1.Property<Guid>("ArquivoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ExtensaoDoArquivo")
                                .IsRequired()
                                .HasColumnName("ExtensaoDoArquivo")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("NomeDoArquivo")
                                .IsRequired()
                                .HasColumnName("NomeDoArquivo")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("NomeOriginal")
                                .IsRequired()
                                .HasColumnName("NomeOriginal")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("ArquivoId");

                            b1.ToTable("Arquivos");

                            b1.WithOwner()
                                .HasForeignKey("ArquivoId");
                        });

                    b.OwnsOne("CondominioApp.Usuarios.App.ValueObjects.Url", "Url", b1 =>
                        {
                            b1.Property<Guid>("ArquivoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("Url")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("ArquivoId");

                            b1.ToTable("Arquivos");

                            b1.WithOwner()
                                .HasForeignKey("ArquivoId");
                        });
                });

            modelBuilder.Entity("CondominioApp.ArquivoDigital.App.Models.Pasta", b =>
                {
                    b.HasOne("CondominioApp.ArquivoDigital.App.Models.Pasta", null)
                        .WithMany("Pastas")
                        .HasForeignKey("PastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
