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
    public partial class Conocimiento17 : PhoneApplicationPage
    {
                const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        //public string respuesta = "0";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "B";
        public string rcorrectaEspacio2 = "B";
        public string rcorrectaEspacio3 = "B";

        
        public Conocimiento17()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se desea evaluar una condición si anteriormente otra condición no se cumplió. ¿Qué estructura permite esto?";
                rcorrecta = "else if";
                rcorrectaEspacio = "else if ";
                rcorrectaEspacio2 = "else if ";
                rcorrectaEspacio3 = "else if ";
            }
            else if (x == 1)
            {
                Question.Text = "Se desea evaluar una condición para varios casos posibles sobre el valor de una variable. ¿Cuál es el nombre de la estructura más adecuada?";
                rcorrecta = "switch";
                rcorrectaEspacio = "switch case";
                rcorrectaEspacio2 = "switch case ";
                rcorrectaEspacio3 = "switch-case";

            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio || respuesta == rcorrectaEspacio2 || respuesta == rcorrectaEspacio3)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "18";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "18");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 18 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento18.xaml", UriKind.Relative));
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