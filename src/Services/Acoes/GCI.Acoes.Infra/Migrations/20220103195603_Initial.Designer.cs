// <auto-generated />
using System;
using GCI.Acoes.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GCI.Acoes.Infra.Migrations
{
    [DbContext(typeof(AcaoContextDB))]
    [Migration("20220103195603_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GCI.Acoes.Domain.Acao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Acoes");
                });
#pragma warning restore 612, 618
        }
    }
}
