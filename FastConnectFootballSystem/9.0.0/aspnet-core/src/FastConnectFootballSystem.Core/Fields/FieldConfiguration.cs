using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Fields
{
    public class FieldConfiguration
    {
        public const int NameMaxLength = 256;
        public const int StatusMaxLength = 100;

        public static void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Fields");
            builder.Property(e => e.FieldName).IsRequired().HasMaxLength(NameMaxLength);
            builder.Property(e => e.FieldStatus).IsRequired().HasMaxLength(StatusMaxLength);
        }
    }
}
