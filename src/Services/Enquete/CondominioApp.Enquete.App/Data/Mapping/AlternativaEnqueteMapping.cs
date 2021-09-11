using CondominioApp.Enquetes.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioApp.Enquetes.App.Data.Mapping
{
    public class AlternativaEnqueteMapping : IEntityTypeConfiguration<AlternativaEnquete>
    {
        public void Configure(EntityTypeBuilder<AlternativaEnquete> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("AlternativasEnquete");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Enquete.Max})");

            builder.Property(u => u.EnqueteId).IsRequired();          
           
        }
    }
}