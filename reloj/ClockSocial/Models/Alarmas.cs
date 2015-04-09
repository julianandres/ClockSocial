using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models 
{
    public class Alarmas : INotifyPropertyChanged
    {
        private ObservableCollection<Alarma> data;

        public ObservableCollection<Alarma> Data
        {
         get
            {                
                return data;
            }
            set 
            {
                data = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Data"));
            }
         }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
