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
    public class PhotoService : IPhotoService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PhotoService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<PageResultDto<PhotoDto>> GetAllAsync(PageRequestDto pageRequestDto, string[]? includes = null)
        {
            PageResultDto<PhotoDto> pageResultDto = new PageResultDto<PhotoDto>();
            var photos = (await _repositoryManager.PhotoRepository.GetAllAsync(pageRequestDto, includes: new string[] { "PhotoDownloadTypes" }, thenIncludes: new string[] { "PhotoDownloadTypes.DownloadType" })).ToList();

            var photoDtos = photos.Adapt<List<PhotoDto>>();
            pageResultDto.Data = photoDtos;
            pageResultDto.Total = await _repositoryManager.PhotoRepository.CountAsync();
            return pageResultDto;
        }

        public async Task<PhotoDto> GetByIdAsync(int id)
        {
            var photo = await _repositoryManager.PhotoRepository.FindAsync(x => x.Id == id, includes: new string[] { "PhotoDownloadTypes" }, thenInclude: new string[] { "PhotoDownloadTypes.DownloadType" });
            return photo.Adapt<PhotoDto>();
        }
    }
}
