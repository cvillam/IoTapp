﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace IoTapp
{
    public partial class Conocimiento : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        public string  respuesta = "0";
        public string rcorrecta="A" ;
        public Conocimiento()
        {

          
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Juan requiere tu ayuda para finalizar su proyecto. Quiere iniciar a transmitir datos a su PC a través del puerto serial. ¿Qué linea de código debe ejecutar en primer lugar?";
                RadioA.Content = "Serial.begin(9600)";
                RadioB.Content = "Serial.begin()";
                RadioC.Content = "Serial.flush()";
                rcorrecta = "A";

            }
            else if (x == 1)
            {
                Question.Text = "Juan requiere tu ayuda para finalizar su proyecto. Quiere iniciar a transmitir datos a su PC a través del puerto serial, a una tasa de 44700 baudios. ¿Qué linea de código debe ejecutar en primer lugar?";
                RadioA.Content = "Serial.begin(9600)";
                RadioB.Content = "Serial.begin(44700)";
                RadioC.Content = "Serial.begin()";
                rcorrecta = "B";
            }

           
        }

        private void CambioRespuesta(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            switch (radio.Name)
            {
                case "RadioA":
                    respuesta = "A";

                    break;
                case "RadioB":
                    respuesta = "B";

                    break;

                case "RadioC":
                    respuesta = "C";

                    break;
            }

        }

        private void EnviarRespuesta(object sender, RoutedEventArgs e)
        {
            if (respuesta == "0")
            {
                MessageBox.Show("Selecciona una respuesta!");
            }
            else
            {
                if (respuesta == rcorrecta) {
                         if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                            {
        
                                IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "2";
                             }
                             else {
                             IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "2");

                                }
                    MessageBox.Show("Correcto!, Has avanzado al nivel 2 de 20");
                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento2.xaml", UriKind.Relative));
                }
                else {
                    int intento;

                    if (IsolatedStorageSettings.ApplicationSettings.Contains("FILE_INTENTOS")) {

                      
                        IsolatedStorageSettings.ApplicationSettings.TryGetValue("FILE_INTENTOS", out intento);
                        intento = intento - 1;
                        if (intento == 0)
                        {
                            IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = 0;
                            MessageBox.Show("Incorrecto!.Te has quedado sin intentos!");
                            NavigationService.Navigate(new Uri("/PreguntasConocimiento/Inicio.xaml", UriKind.Relative));
                        }
                        else {
                            
                            
                            IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = intento;
                            MessageBox.Show("Incorrecto!. Te quedan " + intento + " intentos");
                        }
                    }

                   
                }
           
                }

            }
        }
    }
