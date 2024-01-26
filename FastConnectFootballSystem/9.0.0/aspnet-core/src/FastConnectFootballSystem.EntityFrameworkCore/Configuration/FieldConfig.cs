using FastConnectFootballSystem.Fields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Configuration;

internal class FieldConfig : IEntityTypeConfiguration<Field>
{
    public void Configure(EntityTypeBuilder<Field> builder)
    {
        builder.ToTable(nameof(Field));

        builder.Property(x => x.Id)
            .HasColumnName("FieldID");

        builder.Property(x => x.FieldName)
            .IsRequired()
            .HasMaxLength(FieldConfiguration.NameMaxLength);

        builder.Property(x => x.FieldStatus)
            .IsRequired()
            .HasMaxLength(FieldConfiguration.StatusMaxLength);
    }
}
