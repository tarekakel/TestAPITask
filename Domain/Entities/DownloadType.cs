using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DownloadType : BaseEntity
    {
        public string TypeName { get; set; }
        public ICollection<PhotoDownloadType> PhotoDownloadTypes { get; set; }

    }

}
