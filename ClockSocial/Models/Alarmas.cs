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
                if (data == null)
                {
                    data = new ObservableCollection<Alarma>();
                    Alarma Alarma1 = new Alarma()
                    {
                       Hora= new DateTime(),
                       Nombre="alarma1",
                       Modo= "avanzado",
                       Tipo= "avanzado",
                       State = true
                                             
                    };
                    Alarma Alarma2 = new Alarma()
                   {
                       Hora = new DateTime(),
                       Nombre = "alarma2",
                       Modo = "avanzado2",
                       Tipo = "avanzado2",
                       State = false
                   };
                    Alarma Alarma3 = new Alarma()
                    {
                        Hora = new DateTime(),
                        Nombre = "alarma3",
                        Modo = "avanzado3",
                        Tipo = "avanzado3"
                    }; Alarma Alarma4 = new Alarma()
                    {
                        Hora = new DateTime(),
                        Nombre = "alarma4",
                        Modo = "avanzado4",
                        Tipo = "avanzado4"
                    };
                    Alarma Alarma5 = new Alarma()
                    {
                        Hora = new DateTime(),
                        Nombre = "alarma4",
                        Modo = "avanzado4",
                        Tipo = "avanzado4"
                    };

                    data.Add(Alarma1);
                    data.Add(Alarma2);
                    data.Add(Alarma3);
                    data.Add(Alarma4);
                    data.Add(Alarma5);
                }
                
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
