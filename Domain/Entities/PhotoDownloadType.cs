using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PhotoDownloadType : BaseEntity
    {
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public int DownloadTypeId { get; set; }
        public DownloadType DownloadType { get; set; }

        public int Total { get; set; }


    }
}
