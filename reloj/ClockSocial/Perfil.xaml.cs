using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClockSocial.Models;

namespace ClockSocial
{
    public partial class Perfil : PhoneApplicationPage
    {
        DespertadorDAOLocal local;
        Usuario us;
        public Perfil()
        {
            InitializeComponent();
            local = new DespertadorDAOLocal();
            us = local.findAllUsuario().ElementAt(0);
            user.Text = us.Nombre;
        }

        private void sincronizar(object sender, RoutedEventArgs e)
        {
            //agregar sincronía
            NavigationService.Navigate(
                   new Uri("/MainPage.xaml", UriKind.Relative)
                   );
        }

        private void cerrarSesion(object sender, RoutedEventArgs e)
        {
            DespertadorDAOLocal dao = new DespertadorDAOLocal();
            Usuario us = new Usuario();
            try
            {
                us = dao.findAllUsuario().ElementAt(0);
            }
            catch (Exception E)
            {

            }
            dao.deleteUsuario(us);
            var alarmas = App.Current.Resources["alarmas"] as Alarmas;
            alarmas.Data = null;
            NavigationService.Navigate(
                   new Uri("/MainPage.xaml", UriKind.Relative)
                   );
        }
    }
}