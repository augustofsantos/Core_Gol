using Gol.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.Data.Mappings
{
    public class TravelMapping : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Destino)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Origem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.DataViagem)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable("Travel");
        }
    }
}