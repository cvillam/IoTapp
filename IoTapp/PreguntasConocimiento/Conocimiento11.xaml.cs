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
    public partial class Conocimiento11 : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";  
        public string  respuesta = "0";
        public string rcorrecta="A" ;
        public Conocimiento11()
        {

          
            InitializeComponent();
            Random ran = new Random();
            int x = ran.Next(2);
            if (x == 0)
            {
                Question.Text = "Se desea ejecutar una acción si se da al menos una de las dos siguientes condiciones. La primera, que la variable entera x tenga un valor menor o igual a 18, y la segunda condición, que la variable flotante y sea igual a 0.42. ¿Cómo se debería evaluar la condición?";
                RadioA.Content = "If(x<=18 || y ==0.42){}";
                RadioB.Content = "If(x>=18 || y ==0.42){}";
                RadioC.Content = "If(x==18 || y >=0.42){}";
                RadioD.Content = "If(x<=18 ==  y >=0.42){}";
                rcorrecta = "A";

            }
            else if (x == 1)
            {
                Question.Text = "Se desea ejecutar una acción si se da la siguiente condición, La cadena de caracteres S tenga almacenado el nombre: Carlos ¿Cómo se debería evaluar la condición?";
                RadioA.Content = "If(S ='Carlos'){}";
                RadioB.Content = "If(S =='Carlos'){}";
                RadioC.Content = "If(S == Carlos){}";
                RadioD.Content = "If(S  as 'Carlos'){}";
                rcorrecta = "B";
            }

           
        }

        private void CambioRespuesta(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            switch (radio.Name)
            {
                case "RadioA":
                    respuesta = "A";

                    break;
                case "RadioB":
                    respuesta = "B";

                    break;

                case "RadioC":
                    respuesta = "C";
                    
                    break;
                case "RadioD":
                    respuesta = "D";
                    break;
            }

        }

        private void EnviarRespuesta(object sender, RoutedEventArgs e)
        {
            if (respuesta == "0")
            {
                MessageBox.Show("Selecciona una respuesta!");
            }
            else
            {
                if (respuesta == rcorrecta) {
                         if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                            {
        
                                IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "12";
                             }
                             else {
                             IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "12");

                                }
                    MessageBox.Show("Correcto!, Has avanzado al nivel 12 de 20");
                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento12.xaml", UriKind.Relative));
                }
                else {
                    int intento;

                    if (IsolatedStorageSettings.ApplicationSettings.Contains("FILE_INTENTOS")) {

                      
                        IsolatedStorageSettings.ApplicationSettings.TryGetValue("FILE_INTENTOS", out intento);
                        intento = intento - 1;
                        if (intento == 0)
                        {
                            IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = 0;
                            MessageBox.Show("Incorrecto!.Te has quedado sin intentos!");
                            NavigationService.Navigate(new Uri("/PreguntasConocimiento/Inicio.xaml", UriKind.Relative));
                        }
                        else {
                            
                            
                            IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = intento;
                            MessageBox.Show("Incorrecto!. Te quedan " + intento + " intentos");
                        }
                    }

                   
                }
           
                }

            }
    }
}