using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }

    }

    public class BaseCreateDto
    {
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = "ADMIN";
        public bool IsDeleted { get; set; } = false;
        public string? Remarks { get; set; }

    }

    public class BaseUpdateDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } = "ADMIN";
        public bool IsDeleted { get; set; } = false;
        public string? Remarks { get; set; }

    }
}
