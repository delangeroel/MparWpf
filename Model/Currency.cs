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
    public class Currency : ModelBase, INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyId { get; set; }
        public string Currencycode3 { get; set; }
   
        public int CurrencyN3 { get; set; }
        public int CurrencyDecimals { get; set; }
        public string CurrencyText { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
