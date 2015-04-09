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
using System.Threading;

namespace ClockSocial
{
    public partial class Registro : PhoneApplicationPage, Mongo<User>.IMongo
    {
        Mongo<User> mongo;  
        List<User> usuarios = new List<User>();
        int i;
        public Registro()
        {
            InitializeComponent();
            mongo = new Mongo<User>("iL8g940yMf5r2ghhXgG_vA6VxI_dMcpj", "despertador12345", "users");
            mongo.findAllDocuments(this);
        }

        private void register(object sender, RoutedEventArgs e)
        {
            String pass = password.Text;
            String conpass = conpassword.Text;
            bool val = false;
            bool arroba = false;
            if (email.Text != "" || pass != "" || conpass != "" || name.Text != "" || login.Text != "")
            {
                for (int i = 0; i < email.Text.Length; i++)
                {
                    String a = email.Text.Substring(i, 1);
                    if (a.Equals("@"))
                    {
                        arroba = true;
                    }
                }
                if (arroba)
                {

                    if (pass.Equals(conpass))
                    {
                        val = true;
                    }
                    else
                    {
                        val = false;
                    }
                    if (val)
                    {
                        for (int i = 0; i < usuarios.Count; i++)
                        {

                            if (usuarios.ElementAt(i).Login.Equals(login.Text))
                            {
                                val = false;
                            }
                            MessageBox.Show(login.Text + "      " + usuarios.ElementAt(i).Login);
                        }
                        if (val)
                        {
                            User us = new User()
                             {
                                 Contrasena = password.Text,
                                 Email = email.Text,
                                 Login = login.Text,
                                 Nombre = name.Text
                             };
                            mongo.insertDocument(us,this);
                            
                            if(i==1){
                                NavigationService.Navigate(new Uri("/IniciarSesion.xaml", UriKind.Relative));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login Existente, intentelo de nuevo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contraseñas distintas");
                    }
                }
                else
                {
                    MessageBox.Show("Email Incorrecto");

                }

            }
            else {
                MessageBox.Show("Verifique los campos obligatorios");
            }
        }

        public void loadDocuments(List<User> documents)
        {
            usuarios = documents;
        }


        public void insertar(int i)
        {
            this.i = i;
        }
    }
}