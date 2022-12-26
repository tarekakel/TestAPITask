using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Photo
{
    public class PhotoDto : BaseDto
    {
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        public string ImagePath { get; set; }
        public ICollection<PhotoDownloadTypeDto> PhotoDownloadTypes { get; set; }

        public string TotalDownloadsPerType { get; set; }
    }
}
