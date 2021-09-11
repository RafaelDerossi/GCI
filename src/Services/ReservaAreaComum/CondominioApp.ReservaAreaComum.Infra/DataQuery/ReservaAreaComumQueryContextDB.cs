﻿using CondominioApp.Core.Data;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using CondominioApp.ReservaAreaComum.Domain.ValueObjects;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Infra.DataQuery
{
    public class ReservaAreaComumQueryContextDB : DbContext, IUnitOfWorks
    {
        public DbSet<AreaComumFlat> AreasComunsFlat { get; set; }
        public DbSet<PeriodoFlat> PeriodosFlat { get; set; }
        public DbSet<ReservaFlat> ReservasFlat { get; set; }
        public DbSet<HistoricoReservaFlat> HistoricosReservasFlat { get; set; }

        public ReservaAreaComumQueryContextDB(DbContextOptions<ReservaAreaComumQueryContextDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReservaAreaComumQueryContextDB).Assembly);

            modelBuilder.Ignore<AreaComum>();
            modelBuilder.Ignore<Periodo>();
            modelBuilder.Ignore<Reserva>();
            modelBuilder.Ignore<FotoDaAreaComum>();
            modelBuilder.Ignore<Foto>();
            modelBuilder.Ignore<BloqueioDeArea>();
            modelBuilder.Ignore<NomeArquivo>();            
        }

        public async Task<bool> Commit()
        {
            var cetZone = ZonaDeTempo.ObterZonaDeTempo();

            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCadastro").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                    entry.Property("DataDeAlteracao").CurrentValue =
                        entry.Property("DataDeCadastro").CurrentValue;
                }                   

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }

            return await SaveChangesAsync() > 0;
        }
    }
}