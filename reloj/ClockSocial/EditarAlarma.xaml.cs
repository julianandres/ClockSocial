﻿using System;
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
    public partial class EditarAlarma : PhoneApplicationPage
    {
        int idalarma;
        Alarma al;
        public EditarAlarma()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            
        }
        private void BuildLocalizedApplicationBar()
        {

            // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
            ApplicationBar = new ApplicationBar();

            //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.

            ApplicationBarIconButton saveButton = new ApplicationBarIconButton(new Uri("/Assets/Icons/save.png", UriKind.Relative));
            saveButton.Text = "Guardar";
            saveButton.Click += saveButton_Click;

            ApplicationBarIconButton deleteButton = new ApplicationBarIconButton(new Uri("/Assets/Icons/delete.png", UriKind.Relative));
            deleteButton.Text = "Cancelar";
            //deleteButton.Click += procesarAccion;


            ApplicationBar.Buttons.Add(saveButton);
            ApplicationBar.Buttons.Add(deleteButton);

            //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        }
        void saveButton_Click(object sender, EventArgs e)
        {
            DespertadorDAOLocal local = new DespertadorDAOLocal();
            TimeSpan time = hora.Value.Value;
            int horas = time.Hours;
            int minutos = time.Minutes;
            int segundos = time.Seconds;
            DateTime fechaHoy = DateTime.Now;
            DateTime config = new DateTime(fechaHoy.Date.Year, fechaHoy.Date.Month, fechaHoy.Day, horas, minutos, segundos);
            TimeSpan ts;
            int modo = cmbCurrFrom.SelectedIndex;
            al.mode = modo;
            if (modo == 0)
                al.Modo = "Basico";
            if (modo == 1)
                al.Modo = "Matematicas";
            if (modo == 2)
                al.Modo = "Ovejas";
            bool bandera = false;
            bool bandera2 = false;
            bool rec = repeat.IsChecked.Value;
            al.lunes = lunes.IsChecked.Value;
            al.martes = martes.IsChecked.Value;
            al.miercoles = miercoles.IsChecked.Value;
            al.jueves = jueves.IsChecked.Value;
            al.viernes = viernes.IsChecked.Value;
            al.sabado = sabado.IsChecked.Value;
            al.domingo = domingo.IsChecked.Value;
            al.recurrente = rec;
            if (rec)
            {
                al.Recur = "Recurrente";
                switch ((int)fechaHoy.DayOfWeek)
                {
                    case 1:
                        if (al.lunes)
                        {
                            ts = fechaHoy - config;
                            if (ts.TotalMilliseconds < 0)
                                al.Hora = config;
                            else
                                al.Hora = config.AddDays(7);
                        }
                        else
                            if (al.martes)
                                al.Hora = config.AddDays(1);
                            else
                                if (al.miercoles)
                                    al.Hora = config.AddDays(2);
                                else
                                    if (al.jueves)
                                        al.Hora = config.AddDays(3);
                                    else
                                        if (al.viernes)
                                            al.Hora = config.AddDays(4);
                                        else
                                            if (al.sabado)
                                                al.Hora = config.AddDays(5);
                                            else
                                                if (al.domingo)
                                                    al.Hora = config.AddDays(6);
                                                else
                                                    bandera = true;

                        break;

                    case 2:
                        if (al.martes)
                        {
                            ts = fechaHoy - config;
                            if (ts.TotalMilliseconds < 0)
                                al.Hora = config;
                            else
                                al.Hora = config.AddDays(7);
                        }
                        else
                            if (al.miercoles)
                                al.Hora = config.AddDays(1);
                            else
                                if (al.jueves)
                                    al.Hora = config.AddDays(2);
                                else
                                    if (al.viernes)
                                        al.Hora = config.AddDays(3);
                                    else
                                        if (al.sabado)
                                            al.Hora = config.AddDays(4);
                                        else
                                            if (al.domingo)
                                                al.Hora = config.AddDays(5);
                                            else
                                                if (al.lunes)
                                                    al.Hora = config.AddDays(6);
                                                else
                                                    bandera = true;

                        break;
                    case 3:
                        if (al.miercoles)
                        {
                            ts = fechaHoy - config;
                            if (ts.TotalMilliseconds < 0)
                                al.Hora = config;
                            else
                                al.Hora = config.AddDays(7);
                        }
                        else
                            if (al.jueves)
                                al.Hora = config.AddDays(1);
                            else
                                if (al.viernes)
                                    al.Hora = config.AddDays(2);
                                else
                                    if (al.sabado)
                                        al.Hora = config.AddDays(3);
                                    else
                                        if (al.domingo)
                                            al.Hora = config.AddDays(4);
                                        else
                                            if (al.lunes)
                                                al.Hora = config.AddDays(5);
                                            else
                                                if (al.martes)
                                                    al.Hora = config.AddDays(6);
                                                else
                                                    bandera = true;

                        break;
                    case 4:
                        if (al.jueves)
                        {
                            ts = fechaHoy - config;
                            if (ts.TotalMilliseconds < 0)
                                al.Hora = config;
                            else
                                al.Hora = config.AddDays(7);
                        }
                        else
                            if (al.viernes)
                                al.Hora = config.AddDays(1);
                            else
                                if (al.sabado)
                                    al.Hora = config.AddDays(2);
                                else
                                    if (al.domingo)
                                        al.Hora = config.AddDays(3);
                                    else
                                        if (al.lunes)
                                            al.Hora = config.AddDays(4);
                                        else
                                            if (al.martes)
                                                al.Hora = config.AddDays(5);
                                            else
                                                if (al.miercoles)
                                                    al.Hora = config.AddDays(6);
                                                else
                                                    bandera = true;

                        break;
                    case 5:
                        if (al.viernes)
                        {
                            ts = fechaHoy - config;
                            if (ts.TotalMilliseconds < 0)
                                al.Hora = config;
                            else
                                al.Hora = config.AddDays(7);
                        }
                        else
                            if (al.sabado)
                                al.Hora = config.AddDays(1);
                            else
                                if (al.domingo)
                                    al.Hora = config.AddDays(2);
                                else
                                    if (al.lunes)
                                        al.Hora = config.AddDays(3);
                                    else
                                        if (al.martes)
                                            al.Hora = config.AddDays(4);
                                        else
                                            if (al.miercoles)
                                                al.Hora = config.AddDays(5);
                                            else
                                                if (al.jueves)
                                                    al.Hora = config.AddDays(6);
                                                else
                                                    bandera = true;

                        break;
                    case 6:
                        if (al.sabado)
                        {
                            ts = fechaHoy - config;
                            if (ts.TotalMilliseconds < 0)
                                al.Hora = config;
                            else
                                al.Hora = config.AddDays(7);
                        }
                        else
                            if (al.domingo)
                                al.Hora = config.AddDays(1);
                            else
                                if (al.lunes)
                                    al.Hora = config.AddDays(2);
                                else
                                    if (al.martes)
                                        al.Hora = config.AddDays(3);
                                    else
                                        if (al.miercoles)
                                            al.Hora = config.AddDays(4);
                                        else
                                            if (al.jueves)
                                                al.Hora = config.AddDays(5);
                                            else
                                                if (al.viernes)
                                                    al.Hora = config.AddDays(6);
                                                else
                                                    bandera = true;

                        break;
                    case 7:
                        if (al.domingo)
                        {
                            ts = fechaHoy - config;
                            if (ts.TotalMilliseconds < 0)
                                al.Hora = config;
                            else
                                al.Hora = config.AddDays(7);
                        }
                        else
                            if (al.lunes)
                                al.Hora = config.AddDays(1);
                            else
                                if (al.martes)
                                    al.Hora = config.AddDays(2);
                                else
                                    if (al.miercoles)
                                        al.Hora = config.AddDays(3);
                                    else
                                        if (al.jueves)
                                            al.Hora = config.AddDays(4);
                                        else
                                            if (al.viernes)
                                                al.Hora = config.AddDays(5);
                                            else
                                                if (al.sabado)
                                                    al.Hora = config.AddDays(6);
                                                else
                                                    bandera = true;

                        break;

                }



            }
            else
            {
                al.Recur = "No Recurrente";
                ts = fechaHoy - config;
                if (ts.TotalMilliseconds < 0)
                {
                    al.Hora = config;
                }
                else
                {
                    MessageBox.Show("Hora invalida");
                    bandera2 = true;
                }
            }
            if(!bandera2)
            if (nombre.Text != "")
            {
                if (!bandera)
                {
                    al.Nombre = nombre.Text;
                    local.updateAlarma(al);
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Debe seleccionar por lo menos un día");
                }

            }
            else
            {
                MessageBox.Show("Agregar un nombre");
            }

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (al == null)
            {
                if (NavigationContext.QueryString.ContainsKey("idal"))
                {
                    String dato1 = NavigationContext.QueryString["idal"];
                    idalarma = int.Parse(dato1);
                }
                else
                {
                }
                DespertadorDAOLocal dao = new DespertadorDAOLocal();
                List<Alarma> alarmas = dao.findAllAlarma();
                for (int i = 0; i < alarmas.Count; i++)
                {
                    if (alarmas.ElementAt(i).ID == idalarma)
                        al = alarmas.ElementAt(i);
                }
                nombre.Text = al.Nombre;
                hora.Value = new TimeSpan(al.Hora.Hour, al.Hora.Minute, al.Hora.Second);
                int a = 0;
                if (al.Modo.Equals("Ovejas"))
                {
                    a = 2;
                }
                if (al.Modo.Equals("Matematicas"))
                {
                    a = 1;
                } if (al.Modo.Equals("Basico"))
                {
                    a = 0;
                }

                repeat.IsChecked = al.recurrente;
                lunes.IsChecked = al.lunes;
                martes.IsChecked = al.martes;
                miercoles.IsChecked = al.miercoles;
                jueves.IsChecked = al.jueves;
                viernes.IsChecked = al.viernes;
                sabado.IsChecked = al.sabado;
                domingo.IsChecked = al.domingo;
                if (repeat.IsChecked == true)
                {
                    gridDias.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {

                    gridDias.Visibility = System.Windows.Visibility.Collapsed;
                }
                cmbCurrFrom.SelectedIndex = a;
            }
        }
        private void recurrentCheck(object sender, RoutedEventArgs e)
        {
            if (repeat.IsChecked.Value == true)
            {
                gridDias.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                gridDias.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}