using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        public string ImagePath { get; set; }
        public ICollection<PhotoDownloadType> PhotoDownloadTypes { get; set; }

    }
}
