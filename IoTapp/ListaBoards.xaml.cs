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
    public partial class ListaBoards : PhoneApplicationPage
    {
        public ListaBoards()
        {
            InitializeComponent(); 
            MessageBox.Show("Esta es una referencia básica de consulta rápida, algunos temas especializados pueden no encontrarse ");

        }

        private void GoBoard(object sender, SelectionChangedEventArgs e)
        {
            OpcionBoard opcb = LLSBoard.SelectedItem as OpcionBoard;

            switch(opcb.Titulo){

                case "Yún":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanYun.xaml", UriKind.Relative));
                    break;
                case "UNO":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanUNO.xaml", UriKind.Relative));
                    break;
                case "Tre":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanTre.xaml", UriKind.Relative));
                    break;
                case "Galileo":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanGalileo.xaml", UriKind.Relative));
                    break;
                case "Ethernet":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanEthernet.xaml", UriKind.Relative));
                    break;
                case "Due":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanDue.xaml", UriKind.Relative));
                    break;
                case "Mega":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanMega.xaml", UriKind.Relative));
                    break;
                case "B Model":
                    NavigationService.Navigate(new Uri("/PanoramasBoard/PanRasp.xaml", UriKind.Relative));
                    break;


            }
        }
    }
}