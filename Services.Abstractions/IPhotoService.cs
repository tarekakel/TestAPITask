
using Contracts.Photo;
using Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IPhotoService
    {
        Task<PageResultDto<PhotoDto>> GetAllAsync(PageRequestDto pageRequestDto, string[]? includes = null);

        Task<PhotoDto> GetByIdAsync(int Id);
    }
}
