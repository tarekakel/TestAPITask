using Contracts.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestFile
{
    public class RequestFileDto
    {
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        public string ImagePath { get; set; }
        public int fontSize { get; set; }
        public string type { get; set; }

    }
}
