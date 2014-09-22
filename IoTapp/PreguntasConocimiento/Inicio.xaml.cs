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
    public partial class Inicio : PhoneApplicationPage
    {
        const string FILE_NAME = "texto.txt";
        //const string FILE_INTENTOS = "intentos.txt";
        public Inicio()
        {
            InitializeComponent();
            Continuar.Visibility = Visibility.Collapsed;
            //verificacion del nivel actual
            var text2 = "";
            if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
            {
                text2 = IsolatedStorageSettings.ApplicationSettings[FILE_NAME] as string;
                if (text2 == "")
                {
                    TB.Text = "Él nivel actual es 1";

                }else if(text2=="C"){
                    TB.Text = "Has superado todos los niveles";
                
                
                }
                else {
                    TB.Text = "Él nivel actual es "+text2;
                
                }

            }
            else
            {
                text2 = "";
                TB.Text = "Él nivel actual es 1";
            }
            int numintentos;
            //verificacion del numero de intentos restantes
            if (IsolatedStorageSettings.ApplicationSettings.Contains("FILE_INTENTOS"))
            {
                IsolatedStorageSettings.ApplicationSettings.TryGetValue("FILE_INTENTOS", out numintentos);
                if (numintentos == 0)
                {
                    TB2.Text = "No tienes más intentos, debes volver a iniciar";

                }
                else if(numintentos >=1 && numintentos <=5)
                {
                    TB2.Text = "Número de intentos restantes = "+numintentos;
                    Continuar.Visibility = Visibility.Visible;


                }
                

            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings.Add("FILE_INTENTOS", 5);
                TB2.Text = "Número de intentos restantes = 5";
                Continuar.Visibility = Visibility.Visible;
               
            }



        }

        private void Accion(object sender, RoutedEventArgs e){
            int numero;
            var x = sender as Button;
            if (x.Name == "Continuar") {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("FILE_INTENTOS")) {
                    if (IsolatedStorageSettings.ApplicationSettings.TryGetValue("FILE_INTENTOS", out numero)) {
                        if (numero > 0 && numero <= 5)
                        {
                            var text = "";
                            if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                            {
                                text = IsolatedStorageSettings.ApplicationSettings[FILE_NAME] as string;
                                if (text == "C")
                                {
                                    MessageBox.Show("Ya has superado todos los niveles si quieres volver a probar tus conocimientos reinicia el progreso!");
                                    NavigationService.Navigate(new Uri("/PreguntasConocimiento/Inicio.xaml", UriKind.Relative));
                                }

                            }
                            else
                            {
                                text = "";
                            }

                            NavigationService.Navigate(new Uri("/PreguntasConocimiento/Conocimiento" + text + ".xaml", UriKind.Relative));

                        }
                        else
                        {
                            Continuar.Visibility = Visibility.Collapsed;

                        }
                    }

                    
                }




            }
            else if (x.Name == "Borrar") { 
              

                 if (IsolatedStorageSettings.ApplicationSettings.Contains(FILE_NAME))
                                {

                                     IsolatedStorageSettings.ApplicationSettings[FILE_NAME] = "";
                                }
                                  else
                                 {
                                   IsolatedStorageSettings.ApplicationSettings.Add(FILE_NAME, "");

                                    }
                 if (IsolatedStorageSettings.ApplicationSettings.Contains("FILE_INTENTOS"))
                 {

                     IsolatedStorageSettings.ApplicationSettings["FILE_INTENTOS"] = 5;
                 }
                 else
                 {
                     IsolatedStorageSettings.ApplicationSettings.Add("FILE_INTENTOS", 5);

                 }

                
                              
               MessageBox.Show("Has regresado al nivel 1 en Prueba tus conocimientos!. El número de intentos restantes es 5");
               TB.Text = "Él nivel actual es 1";
               TB2.Text = "Número de intentos restantes = 5";
               Continuar.Visibility = Visibility.Visible;
            }

        }
    }
}