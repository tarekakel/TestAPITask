
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class RepositoryDbContext : DbContext
    {


        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            SeedDownloadTypes(modelBuilder);
            SeedPhotos(modelBuilder);
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoDownloadType> PhotoDownloadTypes { get; set; }
        public DbSet<DownloadType> DownloadTypes { get; set; }




        private void SeedDownloadTypes(ModelBuilder builder)
        {
            builder.Entity<DownloadType>().HasData(
                new DownloadType() { Id = 1, TypeName = "A4Pdf", CreateDate = DateTime.Now, IsDeleted = false },
                new DownloadType() { Id = 2, TypeName = "MobilePdf", CreateDate = DateTime.Now, IsDeleted = false },
                new DownloadType() { Id = 3, TypeName = "JPG", CreateDate = DateTime.Now, IsDeleted = false }
                );
        }

        private void SeedPhotos(ModelBuilder builder)
        {
            builder.Entity<Photo>().HasData(
                new Photo() { Id = 1, ContentText = "book2.jpg", ContentTitle = "book2.jpg", ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot\\images", "book2.jpg"), CreateDate = DateTime.Now, IsDeleted = false },
                new Photo() { Id = 2, ContentText = "books.jpg", ContentTitle = "books.jpg", ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot\\images", "books.jpg"), CreateDate = DateTime.Now, IsDeleted = false },
                new Photo() { Id = 3, ContentText = "panda.jpg", ContentTitle = "panda.jpg", ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot\\images", "panda.jpg"), CreateDate = DateTime.Now, IsDeleted = false },
                new Photo() { Id = 4, ContentText = "panda2.png", ContentTitle = "panda2.png", ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot\\images", "panda2.png"), CreateDate = DateTime.Now, IsDeleted = false }
                 );
        }
    }
}
