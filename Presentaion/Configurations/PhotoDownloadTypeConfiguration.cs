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
    public class PhotoDownloadTypeConfiguration : IEntityTypeConfiguration<PhotoDownloadType>
    {
        public void Configure(EntityTypeBuilder<PhotoDownloadType> builder)
        {
            builder.ToTable(nameof(PhotoDownloadType));
            builder.HasIndex(ph => new { ph.PhotoId, ph.DownloadTypeId }).IsUnique();

            builder.HasOne(ph => ph.Photo).WithMany(ph => ph.PhotoDownloadTypes)
                .HasForeignKey(ph => ph.PhotoId);

           builder.HasOne(ph => ph.DownloadType).WithMany(ph => ph.PhotoDownloadTypes)
                .HasForeignKey(ph => ph.DownloadTypeId);
        }

    }
}
