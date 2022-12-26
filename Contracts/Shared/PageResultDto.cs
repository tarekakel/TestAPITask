﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Shared
{
    public class PageResultDto<T> where T : class
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }

    }
}
