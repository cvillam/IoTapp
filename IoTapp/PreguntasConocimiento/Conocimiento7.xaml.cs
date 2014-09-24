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
    public partial class Conocimiento7 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "B";
        public Conocimiento7()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se tiene un servo motor instanciado como ‘servo’. ¿Qué linea de código debería escribirse para obtener su ángulo en un momento dado?";
                rcorrecta = "servo.read();";
                rcorrectaEspacio = "servo.read(); ";

            }
            else if (x == 1)
            {
                Question.Text = "Se tiene un servo motor instanciado como ‘servo’. ¿Qué linea de código debería escribirse para indicar un  ángulo de 90 en un momento dado?";
                rcorrecta = "servo.write(90);";
                rcorrectaEspacio = "servo.write(90); ";

            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "8";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "8");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 8 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento8.xaml", UriKind.Relative));
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