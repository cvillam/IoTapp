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
    public partial class Conocimiento4 : PhoneApplicationPage
    {

        const string FILE_NAME = "texto.txt"; 
        public Conocimiento4()
        {
            InitializeComponent();
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string r = Answer.Text;
            if (r == "")
            {
                MessageBox.Show("Ingresa la respuesta!");

            }
            else if (r == "servo.read();")
            {

                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "5";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "5");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 5 de 5");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento5.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Incorrecto!");
            }
        }
    }
}