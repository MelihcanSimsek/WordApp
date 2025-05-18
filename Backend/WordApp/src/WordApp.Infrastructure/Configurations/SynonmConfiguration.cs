using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WordApp.Domain.Synonms;

namespace WordApp.Infrastructure.Configurations;

public sealed class SynonmConfiguration : IEntityTypeConfiguration<Synonm>
{
    public void Configure(EntityTypeBuilder<Synonm> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.ForeignWord).IsRequired();
        builder.Property(p => p.TranslatedWord).IsRequired();
        builder.Property(x => x.CreationDate)
             .HasColumnType("timestamp without time zone");
    }
}
