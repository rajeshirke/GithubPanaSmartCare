using System;
using System.ComponentModel;

namespace eWarranty.Models
{
    public class TabOption: INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int id { get; set; }
        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
