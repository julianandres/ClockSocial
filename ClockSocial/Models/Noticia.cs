using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models
{
    public class Noticia : System.ComponentModel.INotifyPropertyChanged
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        private String titulo;
        public String Titulo
        {
            get
            {
                return titulo;

            }
            set
            {
                titulo = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Titulo"));
            }
        }
        private String descripcion;
        public String Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Descripcion"));
            }
        }
        private String categoria;
        public String Categoria
        {
            set
            {
                categoria= value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Categoria"));

            }
            get
            {
                return categoria;
            }

        }
        private DateTime fecha;
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Fecha"));

            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
