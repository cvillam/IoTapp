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
    public partial class Conocimiento14 : PhoneApplicationPage
    {
         const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        public string  respuesta = "0";
        public string rcorrecta="A" ;
        public Conocimiento14()
        {

          
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se tiene una pantalla LCD de dos filas y 16 columnas. Se desea ubicar el cursor para escribir en la fila 2 y columna 13. ¿Qué instrucción permite esto?";
                RadioA.Content = "Lcd.setCursor(2, 13);";
                RadioB.Content = "Lcd.setCursor(13, 2);";
                RadioC.Content = "Lcd.setCursor(12, 1);";
                RadioD.Content = "Lcd.setCursor(1, 12);";
                rcorrecta = "C";

            }
            else if (x == 1)
            {
                Question.Text = "Se tiene una pantalla LCD en la que se quiere limpiar la pantalla, ¿Cómo se realizaría esta acción?";
                RadioA.Content = "Lcd.clean();";
                RadioB.Content = "Lcd.flush();";
                RadioC.Content = "Lcd.stop();";
                RadioD.Content = "Lcd.noCursor();";
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
                case "RadioD":
                    respuesta = "D";
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
        
                                IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "15";
                             }
                             else {
                             IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "15");

                                }
                    MessageBox.Show("Correcto!, Has avanzado al nivel 15 de 20");
                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento15.xaml", UriKind.Relative));
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