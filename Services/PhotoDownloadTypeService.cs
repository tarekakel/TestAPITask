using Contracts;
using Contracts.Photo;
using Contracts.Shared;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PhotoDownloadTypeService : IPhotoDownloadTypeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PhotoDownloadTypeService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;


        public async Task<PhotoDownloadTypeDto> UpdateAsync(int photoId, int typeId)
        {
            var res = await _repositoryManager.PhotoDownloadTypeRepository.FindAsync(criteria: x => x.PhotoId == photoId && x.DownloadTypeId == typeId, includes: new string[] { "DownloadType" }, thenInclude: null);
            if (res != null)
            {
                res.Total += 1;
                //                _repositoryManager.PhotoDownloadTypeRepository.UpdateAsync(res);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                return res.Adapt<PhotoDownloadTypeDto>();

            }
            else
            {
                var result = await _repositoryManager.PhotoDownloadTypeRepository.AddAsync(new PhotoDownloadType() { Total = 1, CreateDate = DateTime.Now, DownloadTypeId = typeId, PhotoId = photoId });
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
                return result.Adapt<PhotoDownloadTypeDto>();

            }
        }
    }
}
