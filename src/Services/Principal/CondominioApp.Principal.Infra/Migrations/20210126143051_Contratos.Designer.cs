﻿// <auto-generated />
using System;
using CondominioApp.Principal.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Principal.Infra.Migrations
{
    [DbContext(typeof(PrincipalContextDB))]
    [Migration("20210126143051_Contratos")]
    partial class Contratos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Principal.Domain.Condominio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BoletoFolder")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Chat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ChatMorador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("Classificado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ClassificadoMorador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("Correspondencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("CorrespondenciaNaPortaria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("LimiteTempoReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("LinkGeraBoleto")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<bool>("Mural")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("MuralMorador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Ocorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("OcorrenciaMorador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("Portaria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("PortariaMorador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<int?>("RefereciaId")
                        .HasColumnType("int");

                    b.Property<bool>("Reserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ReservaNaPortaria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("Condominios");
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.Contrato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAssinatura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.Unidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Andar")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Ramal")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Vagas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("CondominioId");

                    b.HasIndex("GrupoId");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.Condominio", b =>
                {
                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("numero")
                                .IsRequired()
                                .HasColumnName("Cnpj")
                                .HasColumnType("varchar(18)")
                                .HasMaxLength(18);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominios");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });

                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("cep")
                                .HasColumnName("Cep")
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("cidade")
                                .HasColumnName("Cidade")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("complemento")
                                .HasColumnName("Complemento")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("estado")
                                .HasColumnName("Estado")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("logradouro")
                                .HasColumnName("Logradouro")
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("numero")
                                .HasColumnName("Numero")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominios");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });

                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Foto", "LogoMarca", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeDoArquivo")
                                .HasColumnName("NomeDoArquivo")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("NomeOriginal")
                                .HasColumnName("NomeOriginal")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominios");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });

                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .HasColumnName("Telefone")
                                .HasColumnType("varchar(15)")
                                .HasMaxLength(15);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominios");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });

                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Url", "UrlWebServer", b1 =>
                        {
                            b1.Property<Guid>("CondominioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .HasColumnName("UrlWebServer")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("CondominioId");

                            b1.ToTable("Condominios");

                            b1.WithOwner()
                                .HasForeignKey("CondominioId");
                        });
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.Contrato", b =>
                {
                    b.HasOne("CondominioApp.Principal.Domain.Condominio", null)
                        .WithMany("Contratos")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.Grupo", b =>
                {
                    b.HasOne("CondominioApp.Principal.Domain.Condominio", "Condominio")
                        .WithMany("Grupos")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CondominioApp.Principal.Domain.Unidade", b =>
                {
                    b.HasOne("CondominioApp.Principal.Domain.Condominio", "Condominio")
                        .WithMany("Unidades")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CondominioApp.Principal.Domain.Grupo", "Grupo")
                        .WithMany("Unidades")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CondominioApp.Principal.Domain.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("UnidadeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .HasColumnName("Telefone")
                                .HasColumnType("varchar(15)")
                                .HasMaxLength(15);

                            b1.HasKey("UnidadeId");

                            b1.ToTable("Unidades");

                            b1.WithOwner()
                                .HasForeignKey("UnidadeId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}