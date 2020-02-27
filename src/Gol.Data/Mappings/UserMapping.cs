using Gol.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Senha)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.ToTable("User");
        }
    }
}