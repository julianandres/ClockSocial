using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;

namespace ClockSocial.Models
{
    public class DespertadorDAOLocal
    {
        String pathDB = Path.Combine(ApplicationData
           .Current.LocalFolder.Path, "despertador3.sqlite"
           );
        SQLiteConnection con;

        public DespertadorDAOLocal() {
            con = new SQLiteConnection(pathDB);
            con.CreateTable<Alarma>();
            con.CreateTable<Historia>();
            con.CreateTable<Noticia>();
            con.CreateTable<Usuario>();
        }
        public void insertAlarma(Alarma alarma)
        {
            con.Insert(alarma);
        }

        public void updateAlarma(Alarma alarma)
        {
            con.Update(alarma);
        }

        public int deleteAlarma(Alarma alarma)
        {
            return con.Delete(alarma);
        }
        public void insertHistoria(Historia historia)
        {
            con.Insert(historia);
        }

        public void updateHistoria(Historia historia)
        {
            con.Update(historia);
        }

        public void deleteHistoria(Historia historia)
        {
            con.Delete(historia);
        }
        public void insertNoticia(Noticia noticia)
        {
            con.Insert(noticia);
        }

        public void updateNoticia(Noticia noticia)
        {
            con.Update(noticia);
        }

        public void deleteNoticia(Noticia noticia)
        {
            con.Delete(noticia);
        }
        public int insertUsuario(Usuario usuario)
        {
            int i=con.Insert(usuario);
            return i;
        }

        public void updateUsuario(Usuario usuario)
        {
            con.Update(usuario);
        }

        public void deleteUsuario(Usuario usuario)
        {
            con.Delete(usuario);
        }
        public List<Alarma> findAllAlarma()
        {
            List<Alarma> data = con.Table<Alarma>().ToList();
            return data;
        }
        public List<Alarma> findAllAlarmaByIduser(int iduser)
        {

            List<Alarma> data = con.Query<Alarma>("SELECT * FROM Alarma WHERE iduser="+iduser);
            return data;
        }
        public List<Noticia> findAllNoticia()
        {
            List<Noticia> data = con.Table<Noticia>().ToList();
            return data;
        }
        public List<Historia> findAllHistoria()
        {
            List<Historia> data = con.Table<Historia>().ToList();
            return data;
        }
        public List<Usuario> findAllUsuario()
        {
            List<Usuario> data = con.Table<Usuario>().ToList();
            return data;
        }
        

    }
}
