using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWpf.Model
{
    public abstract class AuditableEntity
    {
        [Timestamp]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [Timestamp]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
