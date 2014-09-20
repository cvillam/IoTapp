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
    public partial class Conocimiento3 : PhoneApplicationPage
    {

        const string FILE_NAME = "texto.txt";
        public string respuesta = "0";
        public Conocimiento3()
        {
            InitializeComponent();
        }

        private void EnviarRespuesta(object sender, RoutedEventArgs e)
        {
            if (respuesta == "0")
            {
                MessageBox.Show("Selecciona una respuesta!");
            }
            else
            {
                if (respuesta == "C")
                {
                    if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                    {

                        IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "4";
                    }
                    else
                    {
                        IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "4");

                    }
                    MessageBox.Show("Correcto!, Has avanzado al nivel 4 de 5");
                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento4.xaml", UriKind.Relative));
                }
                else if (respuesta == "B")
                {
                    MessageBox.Show("Incorrecto!");
                }
                else if (respuesta == "A")
                {
                    MessageBox.Show("Incorrecto!");
                }

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
    }
}