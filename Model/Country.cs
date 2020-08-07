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
    public class Country : ModelBase, INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbriviation { get; set; } 



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
 
 