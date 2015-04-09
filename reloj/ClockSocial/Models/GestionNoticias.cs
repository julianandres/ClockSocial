using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Web.Http;

namespace ClockSocial.Models
{

    public class GestionNoticias
    {
        public interface Inoticias
        {
            void getNoticias(List<Noticia> noticia);
        }
        HttpClient cliente;
        XDocument document;

        const String URL_ELPAISCIENCIA = "http://ep00.epimg.net/rss/elpais/ciencia.xml";// ya 
        const String URL_ELPAISULTIMAS = "http://ep00.epimg.net/rss/tags/ultimas_noticias.xml";//ya
        const String URL_ELPAISTECNOLOGIA = "http://ep00.epimg.net/rss/tecnologia/portada.xml";//ya
        const String URL_ELPAISECONOMIA = "http://ep00.epimg.net/rss/economia/portada.xml";//ya

        const String URL_CARACOLPRINCIPALES = "http://www.caracol.com.co/feed.aspx?id=INICIO";//ya
        const String URL_CARACOLECONOMIA = "http://www.caracol.com.co/feed.aspx?id=200";//ya

        const String URL_ELMUNDOPORTADA = "http://estaticos.elmundo.es/elmundo/rss/portada.xml";//ya
        const String URL_ELMUNDOCIENCIA = "http://estaticos.elmundo.es/elmundo/rss/ciencia.xml"; // ya
        const String URL_20MINUTOSTECNOLOGIA = "http://20minutos.feedsportal.com/c/32489/f/478292/index.rss";//ya

        public GestionNoticias()
        {
            cliente = new HttpClient();
        }
        public async void getNoticiasMinutosTecnologia(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_20MINUTOSTECNOLOGIA));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            Noticia temp = new Noticia();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                temp.Titulo = item.Element("title").Value;
                temp.Fecha = item.Element("pubDate").Value;
                temp.Categoria = "Tecnologia";
                noticia.Add(temp);
            }


            intnoticas.getNoticias(noticia);
        }

        public async void getNoticiasMundoPortada(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_ELMUNDOPORTADA));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            Noticia temp = new Noticia();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                temp.Descripcion = item.Element("description").Value;
                temp.Titulo = item.Element("title").Value;
                temp.Fecha = item.Element("pubDate").Value;
                temp.Categoria = "Todas";
                noticia.Add(temp);
            }
            intnoticas.getNoticias(noticia);
        }
        public async void getNoticiasCaracolEconomia(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_CARACOLECONOMIA));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            Noticia temp = new Noticia();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                temp.Descripcion = item.Element("description").Value;
                temp.Titulo = item.Element("title").Value;
                temp.Fecha = item.Element("pubDate").Value;
                temp.Categoria = "Todas";
                noticia.Add(temp);
            }
            intnoticas.getNoticias(noticia);
        }
        public async void getNoticiasCaracolPrincipales(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_CARACOLPRINCIPALES));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            Noticia temp = new Noticia();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                temp.Descripcion = item.Element("description").Value;
                temp.Titulo = item.Element("title").Value;
                temp.Fecha = item.Element("pubDate").Value;
                temp.Categoria = "Todas";
                noticia.Add(temp);
            }
            intnoticas.getNoticias(noticia);
        }

        public async void getNoticiasMundoCiencia(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_ELMUNDOCIENCIA));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            Noticia temp = new Noticia();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                temp.Descripcion = item.Element("description").Value;
                temp.Titulo = item.Element("title").Value;
                temp.Fecha = item.Element("pubDate").Value;
                temp.Categoria = "Ciencia";
                noticia.Add(temp);
            }


            intnoticas.getNoticias(noticia);
        }
        public async void getNoticiasPaisCiencia(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_ELPAISCIENCIA));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            Noticia temp = new Noticia();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                temp.Descripcion = item.Element("description").Value;
                temp.Titulo = item.Element("title").Value;
                temp.Fecha = item.Element("pubDate").Value;
                temp.Imagen = item.Element("enclosure").Attribute("url").Value;
                temp.Categoria = "Ciencia";
                noticia.Add(temp);
            }
            intnoticas.getNoticias(noticia);
        }
        public async void getNoticiasPaisEconomia(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_ELPAISECONOMIA));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                Noticia noticiaw = new Noticia();
                noticiaw.Categoria = "economia";
                noticiaw.Descripcion = item.Element("description").Value;
                noticiaw.Titulo = item.Element("title").Value;
                noticiaw.Fecha = item.Element("pubDate").Value;
                try
                {
                    noticiaw.Imagen = item.Element("enclosure").Attribute("url").Value;
                }
                catch (Exception e) { 
                
                }
                noticia.Add(noticiaw);
            }
            intnoticas.getNoticias(noticia);
        }
        public async void getNoticiasPaisTecnologia(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_ELPAISTECNOLOGIA));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                Noticia noticiaw = new Noticia();
                noticiaw.Categoria = "tecnologia";
                noticiaw.Descripcion = item.Element("description").Value;
                noticiaw.Titulo = item.Element("title").Value;
                noticiaw.Fecha = item.Element("pubDate").Value;
                try
                {
                    noticiaw.Imagen = item.Element("enclosure").Attribute("url").Value;
                }
                catch (Exception e)
                {
                    noticiaw.Imagen = "Assets/blanco.jpg";
                }
                noticia.Add(noticiaw);
            }
            intnoticas.getNoticias(noticia);
        }
        public async void getNoticiasPaisUltimas(Inoticias intnoticas)
        {
            HttpResponseMessage rta = await cliente.GetAsync(new Uri(URL_ELPAISULTIMAS));
            String xml = rta.Content.ToString();
            document = XDocument.Parse(xml);
            List<Noticia> noticia = new List<Noticia>();
            Noticia temp;
            XElement rss = document.Element("rss");
            XElement channel2 = rss.Element("channel");
            for (int i = 0; i < 10; i++)
            {
                XElement item = channel2.Element("item");
                channel2.Element("item").Remove();
                Noticia noticiaw = new Noticia();
                noticiaw.Categoria = "Todas";
                noticiaw.Descripcion = item.Element("description").Value;
                noticiaw.Titulo = item.Element("title").Value;
                noticiaw.Fecha = item.Element("pubDate").Value;
                try
                {
                    noticiaw.Imagen = item.Element("enclosure").Attribute("url").Value;
                }
                catch (Exception e) {
                    noticiaw.Imagen = "Assets/blanco.jpg";
                }
                noticia.Add(noticiaw);
            }
            intnoticas.getNoticias(noticia);
        }

    }

}


