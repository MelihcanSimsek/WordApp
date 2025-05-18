using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordApp.Domain.Words;

namespace WordApp.Infrastructure.Configurations;

public sealed class WordConfiguration : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.ForeignWord).IsRequired();
        builder.Property(p => p.TranslatedWord).IsRequired();

        builder.Property(x => x.LastCheckedTime)
             .HasColumnType("timestamp without time zone");

        builder.Property(x => x.CreationDate)
             .HasColumnType("timestamp without time zone");

        builder.HasMany(p => p.Synonms)
            .WithOne(p => p.Word)
            .HasForeignKey(p => p.WordId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
