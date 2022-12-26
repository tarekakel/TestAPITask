using Contracts.DownloadType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Photo
{
    public class PhotoDownloadTypeDto : BaseDto
    {
        public DownloadTypeDto DownloadType { get; set; }

        public int Total { get; set; }
    }
}
