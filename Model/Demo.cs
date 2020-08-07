using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWpf.Model
{
    public class Demo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DemoId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime ValueDate { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Comment is required")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Lengte  1 - 35")]
        public string Comment { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string EmailAddress { get; set; }

        [Timestamp]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column("ChangeDate", TypeName = "DateTime2")]
        public DateTime ChangeDate { get; set; }

        [Timestamp]
        public DateTime CreateDate { get; set; }

        [Timestamp]
        [DataType(DataType.DateTime)]//("timestamp")] 
        [ConcurrencyCheck]
        public byte[] TimeStamp { get; }

    }
}
