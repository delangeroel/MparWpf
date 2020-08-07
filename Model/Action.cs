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
    public class Action : ModelBase, INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionId { get; set; }
        public string ActionText { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void x()
        {
            RaisePropertyChanged("LastName");
        }
    }
}
