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
    public partial class Conocimiento6 : PhoneApplicationPage
    {

        const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        //public string respuesta = "0";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "B";
        public Conocimiento6()
        {
            InitializeComponent();
            MessageBox.Show("En las preguntas abiertas se debe indicar el fin de la linea de código con ';' cuando sea necesario");
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se quiere enviar un dato entero almacenado en la variable 'x' mediante el puerto serial, se quiere hacerlo con un salto de línea, ¿Qué línea de código debe digitar?";
                rcorrecta = "Serial.println(x);";
                rcorrectaEspacio = "Serial.println(x); "; 

            }
            else if (x == 1)
            {
                Question.Text = "Se quiere enviar un dato tipo string almacenado en la cadena 'x' mediante el puerto serial, se quiere hacerlo sin salto de línea, ¿Qué línea de código debe digitar?";
                rcorrecta = "Serial.print(x);";
                rcorrectaEspacio = "Serial.print(x); "; 
            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "7";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "7");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 7 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento7.xaml", UriKind.Relative));
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