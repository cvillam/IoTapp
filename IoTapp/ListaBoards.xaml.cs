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


            }
        }
    }
}