using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models
{
   public class Historias
    {
        private ObservableCollection<Historia> data;

        public ObservableCollection<Historia> Data
        {
            get
            {
                if (data == null)
                {
                    data = new ObservableCollection<Historia>();
                    Historia historia1 = new Historia()
                    {
                        Categoria = "drama",
                        Fecha = new DateTime(2012,12,12),
                        Titulo = "soy drama"
                    };
                    Historia historia2 = new Historia()
                    {
                        Categoria = "ficcion",
                        Fecha = new DateTime(),
                        Titulo = "soy ficcion"
                    };
                    Historia historia3 = new Historia()
                    {
                        Categoria = "adrenalina",
                        Fecha = new DateTime(),
                        Titulo = "soy adrenalina"
                    }; Historia historia4 = new Historia()
                    {
                        Categoria = "comedia",
                        Fecha = new DateTime(),
                        Titulo = "soy comedia"
                    };
                    Historia historia5 = new Historia()
                    {
                        Categoria = "nada de nada",
                        Fecha = new DateTime(),
                        Titulo = "soy nada de nada"
                    };

                    data.Add(historia1);
                    data.Add(historia2);
                    data.Add(historia3);
                    data.Add(historia4);
                    data.Add(historia5);
                }

                return data;
            }
            set
            {

            }
        }
    }
}
