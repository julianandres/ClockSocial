using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models
{

    public class User : System.ComponentModel.INotifyPropertyChanged
    {
        public Oid _id { get; set; }

        private String nombre;
        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Nombre"));
            }
        }
        private String email;
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Email"));
            }
        }
        private String login;
        public String Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Login"));
            }
        }
        private String contrasena;
        public String Contrasena
        {
            get
            {
                return contrasena;
            }
            set
            {
                contrasena = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Contrasena"));
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
