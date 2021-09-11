﻿// <auto-generated />
using System;
using CondominioApp.Automacao.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioApp.Automacao.App.Migrations
{
    [DbContext(typeof(AutomacaoContextDB))]
    [Migration("20210204135003_AutomacaoInit")]
    partial class AutomacaoInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioApp.Automacao.Models.CondominioCredencial", b =>
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

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TipoApiAutomacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CondominiosCredenciais");
                });

            modelBuilder.Entity("CondominioApp.Automacao.Models.CondominioCredencial", b =>
                {
                    b.OwnsOne("CondominioApp.Automacao.App.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CondominioCredencialId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("CondominioCredencialId");

                            b1.ToTable("CondominiosCredenciais");

                            b1.WithOwner()
                                .HasForeignKey("CondominioCredencialId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}