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
    internal class DownloadTypeConfiguration : IEntityTypeConfiguration<DownloadType>
    {
        public void Configure(EntityTypeBuilder<DownloadType> builder)
        {
            builder.ToTable(nameof(DownloadType));
            builder.HasKey(download => download.Id);
            builder.Property(download => download.Id).ValueGeneratedOnAdd();
            builder.Property(download => download.TypeName).IsRequired();
        }

    }
}
