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
    public partial class Conocimiento2 : PhoneApplicationPage
    {
        
        public Conocimiento2()
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
            else if (r == "lcd.print(x);")
            {
                MessageBox.Show("Correcto!");
            }
            else
            {
                MessageBox.Show("Incorrecto!");
            }
        }
    }
}