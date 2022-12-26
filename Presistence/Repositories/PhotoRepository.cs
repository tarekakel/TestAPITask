using Contracts.Photo;
using Contracts.Shared;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public PhotoRepository(RepositoryDbContext dbContext) : base(dbContext) => _dbContext = dbContext;

    }
}