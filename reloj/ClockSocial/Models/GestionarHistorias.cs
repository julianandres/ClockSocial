using ClockSocial.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models
{
    public class GestionarHistorias: Mongo<Historia>.IMongo
    {
        Mongo<Historia> mongo;
        List<Historia> historias;
        public GestionarHistorias()
        {
            historias = new List<Historia>();
            mongo = new Mongo<Historia>("iL8g940yMf5r2ghhXgG_vA6VxI_dMcpj", "despertador12345", "historias");
            mongo.findAllDocuments(this);
        }
        public List<Historia> obtenerHistorias() {
            return historias;        
        }

        public void loadDocuments(List<Historia> documents)
        {
            for (int i = 0; i < documents.Count; i++)
            {
                historias.Add(documents.ElementAt(i));
            }
        }

        public void insertar(int i)
        {
            throw new NotImplementedException();
        }
    }
}
