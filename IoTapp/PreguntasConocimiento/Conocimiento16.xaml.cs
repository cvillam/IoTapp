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
    public partial class Conocimiento16 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        public string rcorrecta = "A";
        public string rcorrectaEspacio = "A";
        public string rcorrectaEspacio2 = "A";
        public string rcorrectaEspacio3 = "A";
        public string rcorrectaEspacio4 = "A";
        public string rcorrectaEspacio5 = "A";
        public string rcorrectaEspacio6 = "A";


        public Conocimiento16()
        {
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se desea ejecutar una acción 3 veces mediante una estructura de control, para ello se cuenta con una variable entera i, ya declarada e inicializada en cero. ¿Cómo sería la sentencia solo de la estructura de control?";
                rcorrecta = "for(i=0; i<3; i++)";
                rcorrectaEspacio = "for(i=0; i<3; i++) ";
                rcorrectaEspacio2 = "for(i=0;i<3;i++)";
                rcorrectaEspacio3 = "for(i=0; i<3;i++)";
                rcorrectaEspacio4 = "for(i=0;i<3; i++)";
                rcorrectaEspacio5 = "for(i=0;i<3;i++) ";
                rcorrectaEspacio6 = "for(i=0; i<3; i++)";

            }
            else if (x == 1)
            {
                Question.Text = "Se desea ejecutar una acción 8 veces mediante una estructura de control, para ello se cuenta con una variable entera x, ya declarada e inicializada en cero. ¿Cómo sería la sentencia solo de la estructura de control?";
                rcorrecta = "for(x=0; x<8; x++)";
                rcorrectaEspacio = "for(x=0; x<8; x++) ";
                rcorrectaEspacio2 = "for(x=0;x<8;x++)";
                rcorrectaEspacio3 = "for(x=0; x<8;x++)";
                rcorrectaEspacio4 = "for(x=0;x<8; x++)";
                rcorrectaEspacio5 = "for(x=0;x<8;i++) ";
                rcorrectaEspacio6 = "for(x=0; x<8;x++)";
            }
        }

        private void EnviarRes(object sender, RoutedEventArgs e)
        {
            string respuesta = Answer.Text;
            if (respuesta == rcorrecta || respuesta == rcorrectaEspacio || respuesta == rcorrectaEspacio2 || respuesta == rcorrectaEspacio3 || respuesta == rcorrectaEspacio4 || respuesta == rcorrectaEspacio5 || respuesta == rcorrectaEspacio6)
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                {

                    IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "17";
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "17");

                }
                MessageBox.Show("Correcto!, Has avanzado al nivel 17 de 20");
                NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento17.xaml", UriKind.Relative));
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