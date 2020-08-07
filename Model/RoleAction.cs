using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWpf.Model
{
    public class RoleAction : ModelBase, INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [ForeignKey("RoleFK")]
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("ActionFK")]
        public int? ActionId { get; set; }
        public virtual Customer Customer { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
