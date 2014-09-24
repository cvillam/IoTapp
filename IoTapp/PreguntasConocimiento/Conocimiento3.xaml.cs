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

namespace IoTapp.PreguntasConocimiento
{
    public partial class Conocimiento3 : PhoneApplicationPage
    {

       const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        public string  respuesta = "0";
        public string rcorrecta="A" ;
        public Conocimiento3()
        {

          
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se desea conectar un sensor y obtener  la medida analógica de la salida, ¿Qué función podría usarse?";
                RadioA.Content = "Sensor.init();";
                RadioB.Content = "Sensor.read();";
                RadioC.Content = "Sensor.analogRead();";
                rcorrecta = "C";

            }
            else if (x == 1)
            {
                Question.Text = "Si la resolución del conversor analógico-digital de Arduino Uno es de 10 bits, ¿ entre que valores estarán las lecturas mediante la función analogRead();?";
                RadioA.Content = "1 y 99";
                RadioB.Content = "0 y 100";
                RadioC.Content = "0 y 1023";
                rcorrecta = "C";
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
        
                                IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "4";
                             }
                             else {
                             IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "4");

                                }
                    MessageBox.Show("Correcto!, Has avanzado al nivel 4 de 20");
                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento4.xaml", UriKind.Relative));
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