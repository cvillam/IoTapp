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

namespace IoTapp
{
    public partial class MainPage : PhoneApplicationPage
    {
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
            }else if(boton.Name=="menu3"){

                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento.xaml", UriKind.Relative));
            }
        }

    }
}