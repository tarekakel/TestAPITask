using System;
using Domain.Repositories;
using Presentation;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IPhotoRepository> _lazyPhotoRepository;
        private readonly Lazy<IPhotoDownloadTypeRepository> _lazyPhotoDownloadTypeRepository;

        public RepositoryManager(RepositoryDbContext dbContext)
        {

            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _lazyPhotoRepository = new Lazy<IPhotoRepository>(() => new PhotoRepository(dbContext));
            _lazyPhotoDownloadTypeRepository = new Lazy<IPhotoDownloadTypeRepository>(() => new PhotoDownloadTypeRepository(dbContext));
        }


        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

        public IPhotoRepository PhotoRepository => _lazyPhotoRepository.Value;
        public IPhotoDownloadTypeRepository PhotoDownloadTypeRepository => _lazyPhotoDownloadTypeRepository.Value;
    }
}
