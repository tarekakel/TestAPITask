
using Contracts.Photo;
using Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IPhotoDownloadTypeService
    {
         Task<PhotoDownloadTypeDto> UpdateAsync(int photoId, int typeId);

    }
}
