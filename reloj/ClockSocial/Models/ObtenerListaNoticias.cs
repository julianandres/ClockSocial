using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockSocial.Models
{
    public class ObtenerListaNoticias : GestionNoticias.Inoticias
    {
        List<Noticia> noticia;
        GestionNoticias gnot= new GestionNoticias();
        public ObtenerListaNoticias(int i) { // el parámetro i va a ser para seleccionar el tipo de noticia que se desea
            noticia = new List<Noticia>();
            if (i == 0)
            {
                gnot.getNoticiasPaisUltimas(this);
                gnot.getNoticiasCaracolPrincipales(this);
                gnot.getNoticiasMundoPortada(this);
            }
            if (i == 1)
            {
                gnot.getNoticiasPaisTecnologia(this);
                gnot.getNoticiasMinutosTecnologia(this);
            }
            if (i == 2)
            {
                gnot.getNoticiasPaisCiencia(this);
                gnot.getNoticiasMundoCiencia(this);
            }
            if (i == 3)
            {
                gnot.getNoticiasPaisEconomia(this);
                gnot.getNoticiasCaracolEconomia(this);
            }
        }
        public List<Noticia> encontrarNoticia() {
            return noticia;        
        }
        public void getNoticias(List<Noticia> not)
        {
            for (int i = 0; i < not.Count;i++)
            {
                noticia.Add(not.ElementAt(i));
            }
        }
    }
}
