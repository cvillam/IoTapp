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
    public partial class Conocimiento9 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "A";
      
        public Conocimiento9()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se quiere saber si el pin digital 4 digital está en un estado de 1 lógico, ¿Qué función permite obtener la lectura lógica de este pin?";
                rcorrecta = "digitalRead(4);";
                rcorrectaEspacio = "digitalRead(4); ";

            }
            else if (x == 1)
            {
                Question.Text = "Se quiere saber si el pin digital 7 digital está en un estado de 0 lógico, ¿Qué función permite obtener la lectura lógica de este pin?";
                rcorrecta = "digitalRead(7);";
                rcorrectaEspacio = "digitalRead(7); ";
            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || rcorrecta == rcorrectaEspacio)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "10";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "10");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 10 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento10.xaml", UriKind.Relative));
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