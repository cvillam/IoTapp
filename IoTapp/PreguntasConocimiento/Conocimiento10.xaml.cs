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
    public partial class Conocimiento10 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "A";
        public string rcorrectaEspacio2 = "A";
        public string rcorrectaEspacio3 = "A";

        public Conocimiento10()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se desea escribir un valor entero de 10 en la dirección 2 de la memoria EEPROM, ¿Qué instrucción permite realizar esta acción?";
                rcorrecta = "EEPROM.write(2, 10);";
                rcorrectaEspacio = "EEPROM.write(2,10);";
                rcorrectaEspacio2 = "EEPROM.write(2,10); ";
                rcorrectaEspacio3 = "EEPROM.write(2, 10); ";

            }
            else if (x == 1)
            {
                Question.Text = "Se desea leer el valor almacenado en la dirección 4 de la memoria EEPROM, ¿Qué instrucción permite realizar esta acción?";
                rcorrecta = "EEPROM.read(4);";
            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio || respuesta == rcorrectaEspacio2 || respuesta == rcorrectaEspacio3)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "11";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "11");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 11 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento11.xaml", UriKind.Relative));
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