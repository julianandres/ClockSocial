using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models
{
    public class Noticias
    {
        private ObservableCollection<Noticia> data;

        public ObservableCollection<Noticia> Data
        {
            get
            {
                if (data == null)
                {
                    data = new ObservableCollection<Noticia>();
                    Noticia noticia1 = new Noticia()
                    {
                        Categoria="drama",
                        Descripcion="hola soy drama",
                        Fecha= new DateTime(),
                        Titulo="soy drama"                           
                    };
                    Noticia noticia2 = new Noticia()
                    {
                        Categoria = "ficcion",
                        Descripcion = "hola soy ficcion",
                        Fecha = new DateTime(),
                        Titulo = "soy ficcion"
                    };
                    Noticia noticia3 = new Noticia()
                    {
                        Categoria = "adrenalina",
                        Descripcion = "hola soy adrenalina",
                        Fecha = new DateTime(),
                        Titulo = "soy adrenalina"
                    }; Noticia noticia4 = new Noticia()
                    {
                        Categoria = "comedia",
                        Descripcion = "hola soy comedia",
                        Fecha = new DateTime(),
                        Titulo = "soy comedia"
                    };
                    Noticia noticia5 = new Noticia()
                    {
                        Categoria = "nada de nada",
                        Descripcion = "hola soy nada de nada",
                        Fecha = new DateTime(),
                        Titulo = "soy nada de nada"
                    };

                    data.Add(noticia1);
                    data.Add(noticia2);
                    data.Add(noticia3);
                    data.Add(noticia4);
                    data.Add(noticia5);
                }

                return data;
            }
            set
            {

            }
        }
        
    }
}
