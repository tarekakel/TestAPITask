using System;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {


        private readonly Lazy<IPhotoService> _lazyPhotoService;
        private readonly Lazy<IPhotoDownloadTypeService> _lazyPhotoDownloadTypeService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {

            _lazyPhotoService = new Lazy<IPhotoService>(() => new PhotoService(repositoryManager));
            _lazyPhotoDownloadTypeService = new Lazy<IPhotoDownloadTypeService>(() => new PhotoDownloadTypeService(repositoryManager));
        }
        public IPhotoService PhotoService => _lazyPhotoService.Value;

        public IPhotoDownloadTypeService PhotoDownloadTypeService => _lazyPhotoDownloadTypeService.Value;
    }
}
