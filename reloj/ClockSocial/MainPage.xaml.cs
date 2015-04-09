using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClockSocial.Resources;
using ClockSocial.Models;
using System.Collections.ObjectModel;
using System.Threading;

namespace ClockSocial
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Código de ejemplo para traducir ApplicationBar
            BuildLocalizedApplicationBar(items.SelectedIndex);
            cargarAlarmasPre();
            cargarNoticias(0);
        }

        // Código de ejemplo para compilar una ApplicationBar traducida
        private void BuildLocalizedApplicationBar(int i)
        {
            if (i == 0)
            {
                if(list.SelectedItem!=null){
                // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
                ApplicationBar = new ApplicationBar();

                //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
           
                ApplicationBarIconButton editButton = new ApplicationBarIconButton(new Uri("/Assets/Icons/edit.png", UriKind.Relative));
                editButton.Text = "Editar";
                editButton.Click += editButton_Click;

                ApplicationBarIconButton deleteButton = new ApplicationBarIconButton(new Uri("/Assets/Icons/delete.png", UriKind.Relative));
                deleteButton.Text = "Editar";
                deleteButton.Click += deleteButton_Click;


                ApplicationBar.Buttons.Add(editButton);
                ApplicationBar.Buttons.Add(deleteButton);

                //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
                }else {
                    ApplicationBar = new ApplicationBar();
                    ApplicationBarIconButton addButton = new ApplicationBarIconButton(new Uri("/Assets/Icons/add.png", UriKind.Relative));
                    addButton.Text = "Agregar";
                    addButton.Click += addButton_Click;
                    ApplicationBar.Buttons.Add(addButton);
                
                }
            }
            else {
                if (i == 2)
                {
                    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
                    ApplicationBar = new ApplicationBar();

                    //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
                    ApplicationBarIconButton configButton = new ApplicationBarIconButton(new Uri("/Assets/Icons/feature.settings.png", UriKind.Relative));
                    configButton.Text = "Configurar";
                    //addButton.Click += procesarAccion;

                    ApplicationBar.Buttons.Add(configButton);
                }
                else {
                    ApplicationBar = new ApplicationBar();
                    ApplicationBarMenuItem tecnologia = new ApplicationBarMenuItem("Tecnología");
                    tecnologia.Click += tecnologia_Click;
                    ApplicationBarMenuItem ciencia = new ApplicationBarMenuItem("Ciencia");
                    ciencia.Click += tecnologia_Click;
                    ApplicationBarMenuItem economia = new ApplicationBarMenuItem("Economía");
                    economia.Click += tecnologia_Click;

                    ApplicationBar.MenuItems.Add(tecnologia);
                    ApplicationBar.MenuItems.Add(ciencia);
                    ApplicationBar.MenuItems.Add(economia);
                }
            }
        }

        void deleteButton_Click(object sender, EventArgs e)
        {
            DespertadorDAOLocal dao = new DespertadorDAOLocal();
            var alarma = list.SelectedItem as Alarma;
            int i=dao.deleteAlarma(alarma);
            if (i == 1)
            {
                MessageBox.Show("Alarma Eliminada Correctamente");
            }
            else {
                MessageBox.Show("Error al eliminar Alarma");
            }
            cargarAlarmasPre();
        }

        void editButton_Click(object sender, EventArgs e)
        {
            var alarma = list.SelectedItem as Alarma;
            int idalarma = alarma.ID;
            NavigationService.Navigate(new Uri("/EditarAlarma.xaml?idal="+idalarma, UriKind.Relative));            
        }

        void tecnologia_Click(object sender, EventArgs e)
        {
            var obj= sender as ApplicationBarMenuItem;
            if (obj.Text.Equals("Economía"))
            {
                cargarNoticias(3);
            }
            else {
                if (obj.Text.Equals("Ciencia"))
                {
                    cargarNoticias(2);
                }
                else
                {
                    if (obj.Text.Equals("Tecnología"))
                    {
                        cargarNoticias(1);
                    }
                    else
                    {
                        cargarNoticias(0);
                    }


                }
            
            }

            MessageBox.Show("filtrado por "+obj.Text); 
           
        }

        void addButton_Click(object sender, EventArgs e)
        {
             DespertadorDAOLocal dao = new DespertadorDAOLocal();
            List<Usuario> us = dao.findAllUsuario();
            int iduser;
            try{
                iduser=us.ElementAt(0).ID;
            }catch(Exception E){
               iduser=-1;
            }
            NavigationService.Navigate(new Uri("/NuevaAlarma.xaml?iduser="+iduser, UriKind.Relative));
        }

        private void cambioPestana(object sender, SelectionChangedEventArgs e)
        {
            BuildLocalizedApplicationBar(items.SelectedIndex);
            list.SelectedItem = null;
        }

        private void cargarMenu(object sender, SelectionChangedEventArgs e)
        {
           
                BuildLocalizedApplicationBar(items.SelectedIndex);
                
            
        }

        private void enableAlarma(object sender, RoutedEventArgs e)
        {
          

           
        }
        void cargarNoticias(int i) {
            ObtenerListaNoticias oln = new ObtenerListaNoticias(i);
            Thread.Sleep(1000);
            List<Noticia> lista = oln.encontrarNoticia();
            int a = 0;
            if (lista == null)
            {
                while (a < 2&&lista==null)
                {
                    oln = new ObtenerListaNoticias(i);
                    Thread.Sleep(100);
                    lista = oln.encontrarNoticia();
                    a++;
                }
            }
            var noticias = App.Current.Resources["noticias"] as Noticias;

            try
            {
                oln = new ObtenerListaNoticias(i);
                Thread.Sleep(1000);
                lista = oln.encontrarNoticia();
                 
                ObservableCollection<Noticia> myCollection = new ObservableCollection<Noticia>(lista);
                noticias.Data = myCollection;
            }catch(Exception e){
                try
                {
                    oln = new ObtenerListaNoticias(i);
                    Thread.Sleep(1000);
                    lista = oln.encontrarNoticia();
                    ObservableCollection<Noticia> myCollection = new ObservableCollection<Noticia>(lista);
                    noticias.Data = myCollection;
                }
                catch (Exception m)
                {
                    oln = new ObtenerListaNoticias(i);
                    Thread.Sleep(1000);
                    lista = oln.encontrarNoticia();
                    try
                    {
                        ObservableCollection<Noticia> myCollection = new ObservableCollection<Noticia>(lista);
                        noticias.Data = myCollection;
                    }catch(Exception al){
                        MessageBox.Show("error al cargar las noticias");
                    }
                }        
           }
    
        }
        void cargarHistorias(int i)
        {
            GestionarHistorias gi = new GestionarHistorias();
            Thread.Sleep(1000);
            List<Historia> lista = gi.obtenerHistorias();
            int a = 0;
            if (lista == null)
            {
                while (a < 2 && lista == null)
                {
                    gi = new GestionarHistorias();
                    Thread.Sleep(100);
                    lista = gi.obtenerHistorias();
                    a++;
                }
            }
            var historias = App.Current.Resources["historias"] as Historias;

            try
            {
                gi = new GestionarHistorias();
                ObservableCollection<Historia> myCollection = new ObservableCollection<Historia>(lista);
                historias.Data = myCollection;
            }
            catch (Exception al)
                    {
                        MessageBox.Show("error al cargar las noticias");
                    }
        }

        private void verificarPerfil(object sender, RoutedEventArgs e)
        {
            DespertadorDAOLocal dao = new DespertadorDAOLocal();
            List<Usuario> us = dao.findAllUsuario();
            try
            {
                if (dao.findAllUsuario().Count!=0)
                {
                    NavigationService.Navigate( new Uri("/Perfil.xaml", UriKind.Relative));
                }
                else
                {
                    NavigationService.Navigate(
                      new Uri("/IniciarSesion.xaml", UriKind.Relative)
                      );
                }
            }
            catch (Exception E) {
              //  andres.Text = "hola  " + E;
            }
        }
        private void cargarAlarmasPre() {
            var alarmas = App.Current.Resources["alarmas"] as Alarmas;
            DespertadorDAOLocal dao = new DespertadorDAOLocal();
            List<Usuario> us = dao.findAllUsuario();
            List<Alarma> lista = new List<Alarma>();// aqui se debe colocar el llamado de la base de datos.
            try
            {
                int iduser = us.ElementAt(0).ID;
                lista = dao.findAllAlarmaByIduser(iduser);
                ObservableCollection<Alarma> myCollection = new ObservableCollection<Alarma>(lista);
                alarmas.Data = myCollection;
            }
            catch (Exception e) {
                lista = dao.findAllAlarmaByIduser(-1);
                ObservableCollection<Alarma> myCollection = new ObservableCollection<Alarma>(lista);
                alarmas.Data = myCollection;
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cargarAlarmasPre();
        }
    }
    
}