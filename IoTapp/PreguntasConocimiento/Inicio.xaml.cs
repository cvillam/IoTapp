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
    public partial class Inicio : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        public Inicio()
        {
            InitializeComponent();
            var text2 = "";
            if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
            {
                text2 = IsolatedStorageSettings.ApplicationSettings[FILE_NAME] as string;
                if (text2 == "")
                {
                    TB.Text = "Él nivel actual es 1";

                }else if(text2=="C"){
                    TB.Text = "Has superado todos los niveles";
                
                
                }
                else {
                    TB.Text = "Él nivel actual es "+text2;
                
                }

            }
            else
            {
                text2 = "";
                TB.Text = "Él nivel actual es 1";
            }
        }

        private void Accion(object sender, RoutedEventArgs e){
        
            var x = sender as Button;
            if (x.Name == "Continuar") {
                var text = "";
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {
                    text = IsolatedStorageSettings.ApplicationSettings[FILE_NAME] as string;
                    if (text == "C") {
                        MessageBox.Show("Ya has superado todos los niveles si quieres volver a continaur reinicia el progreso!");
                        NavigationService.Navigate(new Uri("/Inicio.xaml", UriKind.Relative));
                    }

                }
                else {
                     text = "";
                }

                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento"+text+".xaml", UriKind.Relative));
            }
            else if (x.Name == "Borrar") { 
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
              {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "");

               }
               MessageBox.Show("Has regresado al nivel 1 en Prueba tus conocimientos!");
               TB.Text = "Él nivel actual es 1";
            
            }

        }
    }
}