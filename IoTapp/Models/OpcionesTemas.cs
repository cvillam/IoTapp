using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTapp.Models
{
    public class OpcionesTemas
    {
        ObservableCollection<OpcionTema> list;

        public ObservableCollection<OpcionTema> List
        {
            get
            {

                if (list == null)
                {
                    list = new ObservableCollection<OpcionTema>();
                    OpcionTema ot = new OpcionTema() { Titulo = "Variables", Descripcion ="Arduino"};
                    list.Add(ot);

                    ot = new OpcionTema() { Titulo = "Estructura", Descripcion = "Arduino" };
                    list.Add(ot);

                    ot = new OpcionTema() { Titulo = "Funciones", Descripcion = "Arduino" };
                    list.Add(ot);

                    ot = new OpcionTema() { Titulo = "Librerías", Descripcion = "Arduino" };
                    list.Add(ot);
                    ot = new OpcionTema() { Titulo = "Raspbian Básico", Descripcion = "Raspberry" };
                    list.Add(ot);


                   



                }
                return list;

            }
            set { list = value; }

        }
    }
}
