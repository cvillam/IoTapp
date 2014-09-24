using System;
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
    public partial class Conocimiento5 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        public string  respuesta = "0";
        public string rcorrecta="A" ;
        public Conocimiento5()
        {

          
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "¿Para indicar que el pin 12  es de salida digital, que función se usa?";
                RadioA.Content = "pinMode(12, OUTPUT);";
                RadioB.Content = "pinOutput(12);";
                RadioC.Content = "pin12.SetMode(OUTPUT);";
                rcorrecta = "A";

            }
            else if (x == 1)
            {
                Question.Text = "¿Para indicar que el pin 10  es una entrada digital, qué función se usa?";
                RadioA.Content = "pinMode(10, INPUT);";
                RadioB.Content = "pinInput(10);";
                RadioC.Content = "pin10.SetMode(INPUT);";
                rcorrecta = "A";
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
        
                                IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "6";
                             }
                             else {
                             IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "6");

                                }
                    MessageBox.Show("Correcto!, Has avanzado al nivel 6 de 20");
                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento6.xaml", UriKind.Relative));
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