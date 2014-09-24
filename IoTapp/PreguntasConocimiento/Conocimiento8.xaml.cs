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
    public partial class Conocimiento8 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "B";
        public string rcorrectaEspacio2 = "B";
        public string rcorrectaEspacio3 = "B";
        public Conocimiento8()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se desea encender un LED ubicado en el pin 2, el cual ya ha sido declarado como salida digital, ¿Con qué instrucción debería encenderse?";
                rcorrecta = "digitalWrite(2, HIGH);";
                rcorrectaEspacio = "digitalWrite(2,HIGH);";
                rcorrectaEspacio2 = "digitalWrite(2,HIGH) ;";
                rcorrectaEspacio3 = "digitalWrite(2, HIGH); ";

            }
            else if (x == 1)
            {
                Question.Text = "Se desea apagar un LED ubicado en el pin 2, el cual ya ha sido declarado como salida digital, ¿Con qué instrucción debería apagarse?";
                rcorrecta = "digitalWrite(2, LOW);";
            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio || respuesta == rcorrectaEspacio2 || respuesta == rcorrectaEspacio3)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "9";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "9");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 9 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento9.xaml", UriKind.Relative));
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