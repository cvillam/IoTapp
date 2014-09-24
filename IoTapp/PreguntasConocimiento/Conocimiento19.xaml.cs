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
    public partial class Conocimiento19 : PhoneApplicationPage
    {
                const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        //public string respuesta = "0";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "A";
        public Conocimiento19()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "¿Qué comando permite iniciar la configuración en Raspberry?";
                rcorrecta = "sudo raspi-config";
                rcorrectaEspacio = "sudo raspi-config ";

            }
            else if (x == 1)
            {
                Question.Text = "¿Qué comando permite iniciar la configuración en Raspberry?";
                rcorrecta = "sudo raspi-config";
                rcorrectaEspacio = "sudo raspi-config ";
            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "20";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "20");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 20 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento20.xaml", UriKind.Relative));
            }
            else
            {
                int intento;

                if (IsolatedStorageSettings.ApplicationSettings.Contains("FILE_INTENTOS"))
                {


                    IsolatedStorageSettings.ApplicationSettings.TryGetValue("FILE_INTENTOS", out intento);
                    intento = intento - 1;
                    if (intento == 0)
                    {
                        IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = 0;
                        MessageBox.Show("Incorrecto!.Te has quedado sin intentos!");
                        NavigationService.Navigate(new Uri("/PreguntasConocimiento/Inicio.xaml", UriKind.Relative));
                    }
                    else
                    {


                        IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = intento;
                        MessageBox.Show("Incorrecto!. Te quedan " + intento + " intentos");
                    }
                }


            }
        }
    }
}