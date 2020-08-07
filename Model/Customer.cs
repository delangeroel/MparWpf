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
    public class Customer : ModelBase, INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Uri Email { get; set; }
        public bool IsActive { get; set; }
        public OrderStatus Status { get; set; }
        public string State { get; set; }
        [ForeignKey("RoleFK")]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public enum OrderStatus { None, New, Processing, Shipped, Received };
}
