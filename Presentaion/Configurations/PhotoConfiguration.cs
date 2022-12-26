using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentaion.Configurations
{
    internal class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable(nameof(Photo));
            builder.HasKey(ph => ph.Id);
            builder.Property(ph => ph.Id).ValueGeneratedOnAdd();
            builder.Property(ph => ph.ContentText).IsRequired();
            builder.Property(ph => ph.ContentTitle).IsRequired();
            builder.Property(ph => ph.ImagePath).IsRequired();
        }

    }
}
