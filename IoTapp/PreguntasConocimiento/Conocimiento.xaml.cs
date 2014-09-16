using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace IoTapp
{
    public partial class Conocimiento : PhoneApplicationPage
    {
        public string  respuesta = "0";
        public Conocimiento()
        {
            InitializeComponent();
           
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
                if (respuesta == "A") {
                    MessageBox.Show("Correcto!, La variable int es muy usada");
                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento2.xaml", UriKind.Relative));
                }
                else if (respuesta == "B") {
                    MessageBox.Show("Incorrecto!");
                }
                else if (respuesta == "C") {
                    MessageBox.Show("Incorrecto!");
                }

            }
        }
    }
}