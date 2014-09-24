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
    public partial class Conocimiento18 : PhoneApplicationPage
    {
                const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        //public string respuesta = "0";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "A";
        public string rcorrectaEspacio2 = "A";
        public string rcorrectaEspacio3 = "A";
        public Conocimiento18()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se tiene un pin número 7 con capacidad de PWM y se quiere enviar una señal de voltaje de 200 sobre 255 partes posibles. ¿Qué línea de código permite ejecutar esta acción?";
                rcorrecta = "analogWrite(7, 200);";
                rcorrectaEspacio = "analogWrite(7,200);";
                rcorrectaEspacio2 = "analogWrite(7, 200); ";
                rcorrectaEspacio3 = "analogWrite(7,200); ";
                

            }
            else if (x == 1)
            {
                Question.Text = "En el pin 7 con capacidad para PWM se quiere activar permanentemente la salida. ¿Cómo se realizaría esta acción?";
                rcorrecta = "analogWrite(7, 255);";
                rcorrectaEspacio = "analogWrite(7,255);";
                rcorrectaEspacio2 = "analogWrite(7, 255); ";
                rcorrectaEspacio3 = "analogWrite(7,255); ";
            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio || respuesta == rcorrectaEspacio2 || respuesta == rcorrectaEspacio3)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "19";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "19");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 19 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento19.xaml", UriKind.Relative));
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