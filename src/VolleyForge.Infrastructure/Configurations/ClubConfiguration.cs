using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyForge.Domain.Entities;

namespace VolleyForge.Infrastructure.Configurations;

public class ClubConfiguration : IEntityTypeConfiguration<Club>
{
    public void Configure(EntityTypeBuilder<Club> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(c => c.ShortName)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasData(
            new { Id = Guid.Parse("a1000000-0000-0000-0000-000000000001"), Name = "Associação Desportiva e Recreativa Escolar Praiense", ShortName = "ADREP" },
            new { Id = Guid.Parse("a1000000-0000-0000-0000-000000000002"), Name = "Fayal Sport Club", ShortName = "FSC" },
            new { Id = Guid.Parse("a1000000-0000-0000-0000-000000000003"), Name = "Clube Desportivo Escolar das Flores", ShortName = "CDEF" },
            new { Id = Guid.Parse("a1000000-0000-0000-0000-000000000004"), Name = "Grupo Desportivo Velense", ShortName = "GDV" },
            new { Id = Guid.Parse("a1000000-0000-0000-0000-000000000005"), Name = "Futebol Clube Calheta", ShortName = "FCC" },
            new { Id = Guid.Parse("a1000000-0000-0000-0000-000000000006"), Name = "Castelo Branco Sport Clube", ShortName = "CBSC" }
        );
    }
}