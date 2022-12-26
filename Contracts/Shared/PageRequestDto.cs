using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Shared
{
    public class PageRequestDto
    {
        public int Rows { get; set; } = 10;
        public int First { get; set; } = 0;
    }
}
