using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IoTapp.Resources;
using System.IO.IsolatedStorage;

namespace IoTapp
{
    public partial class MainPage : PhoneApplicationPage
    {


        const string FILE_NAME = "texto.txt";       
        // Constructor
        public MainPage()
        {
            InitializeComponent();

                   
                       
        }
   

        private void GoPage(object sender, RoutedEventArgs e)
        {
            var boton = sender as Button;
            if (boton.Name == "menu1")
            {
                NavigationService.Navigate(new Uri("/ListaBoards.xaml", UriKind.Relative));
            }
            else if (boton.Name == "menu2")
            {

                NavigationService.Navigate(new Uri("/ListaTemas.xaml", UriKind.Relative));
            }
            else if (boton.Name == "menu3") {
                //var text = "";
                //if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                //{
                //     text = IsolatedStorageSettings.ApplicationSettings[FILE_NAME] as string;


                //}
                //else {
                //     text = "";
                //}

                //NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento"+text+".xaml", UriKind.Relative));
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Inicio.xaml", UriKind.Relative));
            }
            else if (boton.Name == "menu4")
            {

                NavigationService.Navigate(new Uri("/Iot.xaml", UriKind.Relative));
            }
            //else if (boton.Name == "menu5")
            //{
            //    if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
            //    {

            //        IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "";
            //    }
            //    else
            //    {
            //        IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "");

            //    }
            //    MessageBox.Show("Has regresado al nivel 1 en Prueba tus conocimientos!");
                
            //}
        }

    }
}