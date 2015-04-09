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
using ClockSocial.Net;

namespace ClockSocial
{
    public partial class IniciarSesion : PhoneApplicationPage, Mongo<User>.IMongo
    {
        Mongo<User> mongo;  
        List<User> users;
        public IniciarSesion()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            mongo = new Mongo<User>("iL8g940yMf5r2ghhXgG_vA6VxI_dMcpj", "despertador12345", "users");
            mongo.findAllDocuments(this);
        }

        private void iniciarSesion(object sender, RoutedEventArgs e)
        {
            mongo.findAllDocuments(this);
            DespertadorDAOLocal local = new DespertadorDAOLocal();
            bool validacion = true;
            Usuario us = new Usuario();
            
            for (int i = 0; i < users.Count; i++) {
                if (login.Text.Equals(users.ElementAt(i).Login))
                {
                    if (login.Text.Equals(users.ElementAt(i).Contrasena))
                    {
                        validacion = true;
                        us.Contrasena = users.ElementAt(i).Contrasena;
                        us.Login = users.ElementAt(i).Login;
                        us.Nombre = users.ElementAt(i).Nombre;
                        us.Email = users.ElementAt(i).Email;
                        i = users.Count;
                    }
                    else
                    {
                        validacion = false;
                    }
                }
                else {
                    validacion = false;
                }
            }
                //aqui poner la validacion de inicio de sesion


                if (validacion)
                {
                    int i;
                     i=local.insertUsuario(us);
                     if (i == 1)
                     {
                         MessageBox.Show("Sesión iniciada como: " + us.Nombre);
                         NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                     }
                     else {
                         MessageBox.Show("Error, revise sus datos");                     
                     }
                }
                else
                {
                    MessageBox.Show("Login o password Incorrectos");
                }
        }
        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.

            ApplicationBarIconButton registerButton = new ApplicationBarIconButton(new Uri("/Assets/Icons/add.png", UriKind.Relative));
            registerButton.Text = "Registro";
            registerButton.Click += registerButton_Click;


            ApplicationBar.Buttons.Add(registerButton);
        
        
        }

        void registerButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registro.xaml",UriKind.Relative));
        }

        public void loadDocuments(List<User> documents)
        {
            users = documents;
        }



        public void insertar(int i)
        {
            throw new NotImplementedException();
        }
    }
}