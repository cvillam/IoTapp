using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IoTapp.Models;

namespace IoTapp
{
    public partial class ListaTemas : PhoneApplicationPage
    {
        public ListaTemas()
        {
            InitializeComponent();
        }

        private void GoTema(object sender, SelectionChangedEventArgs e)
        {
            OpcionTema opct = LLSTema.SelectedItem as OpcionTema;

            switch (opct.Titulo)
            {

                case "Variables":
                    NavigationService.Navigate(new Uri("/PanoramasTemas/PanVar.xaml", UriKind.Relative));
                    break;
                case "Estructura":
                    NavigationService.Navigate(new Uri("/PanoramasTemas/PanEst.xaml", UriKind.Relative));
                    break;
                case "Funciones":
                    NavigationService.Navigate(new Uri("/PanoramasTemas/PanFun.xaml", UriKind.Relative));
                    break;
                case "Librerías":
                    NavigationService.Navigate(new Uri("/PanoramasTemas/PanLib.xaml", UriKind.Relative));
                    break;
                case "Raspbian Básico":
                    NavigationService.Navigate(new Uri("/PanoramasTemas/PanRaspbian.xaml", UriKind.Relative));
                    break;
                


            }
        }
    }
}