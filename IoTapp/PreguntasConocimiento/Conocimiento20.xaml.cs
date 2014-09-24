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
using Windows.UI.Core;
using System.Windows.Input;
using System.Diagnostics;


namespace IoTapp.PreguntasConocimiento
{
    public partial class Conocimiento20 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
     
    
        public string rcorrecta;
        public string rcorrectaEspacio;
        public string rcorrectaEspacio2;
        public string rcorrectaEspacio3;

        public string respuesta =  "0";
   

        public Conocimiento20()
        {
            InitializeComponent();
            Question.Text = "Se desea iniciar la conexión a la red WiFi de nombre 'red', este nombre se encuentra almacenado en la cadena de caracteres N, y cuya contraseña es '123', la cual está almacenada en la cadena de caracteres C. ¿Cómo se realizaría esta acción?";
            rcorrecta = "WiFi.begin(N, C);";
            rcorrectaEspacio = "WiFi.begin(N, C); ";
            rcorrectaEspacio2 = "WiFi.begin(N,C);";
            rcorrectaEspacio3 = "WiFi.begin(N,C); ";
           
        }
        
       
        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio || respuesta == rcorrectaEspacio2 || respuesta == rcorrectaEspacio3)
     
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "C";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "C");

                }
                MessageBox.Show("Correcto!, Has completado todos los niveles");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Inicio.xaml", UriKind.Relative));
            }
            else
            {
                int intento;
     
                if (IsolatedStorageSettings.ApplicationSettings.Contains("FILE_INTENTOS"))
                {


                    IsolatedStorageSettings.ApplicationSettings.TryGetValue("FILE_INTENTOS", out intento);
                    intento = intento - 1;
                    if (intento == 0)
                    {
                        IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = 0;
                        MessageBox.Show("Incorrecto!.Te has quedado sin intentos!");
                        NavigationService.Navigate(new Uri("/PreguntasConocimiento/Inicio.xaml", UriKind.Relative));
                    }
                    else
                    {


                        IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = intento;
                        MessageBox.Show("Incorrecto!. Te quedan " + intento + " intentos");
                    }
                }


            }
        }

        
    }
}