using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models
{
    public class Alarma :  System.ComponentModel.INotifyPropertyChanged
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public bool domingo { get; set; }
        public bool recurrente { get; set; }
        public int iduser { get; set; }
        public int mode { get; set; }

        private String recur;
        public String Recur
        {
            get
            {
                return recur;

            }
            set
            {
                recur = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Recur"));
            }
        }
        private DateTime hora;
        public DateTime Hora {
            get
            {
                return hora;

        }
            set {
                hora = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Hora"));
            }
        }

        private String tipo;
        public String Tipo
        {
            get
            {
                return tipo;

            }
            set
            {
                tipo = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Tipo"));
            }
        }
       private String modo;
       public String Modo{
           set{
           modo = value;
           if (PropertyChanged != null)
               PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Modo"));
       
             }get{
                return modo;
                 }
       
       }
       private String nombre;
       public String Nombre { get {
           return nombre;
       }
           set {
               nombre = value;
               if (PropertyChanged != null)
                   PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Nombre"));
           
           }
       }
       private Boolean state;
       public Boolean State
       {
           get
           {
               return state;
           }
           set
           {
               state = value;
               if (PropertyChanged != null)
                   PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("State"));

           }
       }
        


        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
