using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTapp.Models
{
    public class OpcionesBoards
    {
        ObservableCollection<OpcionBoard> list;

        public ObservableCollection<OpcionBoard> List
        {
            get {

                if (list == null)
                {
                    list = new ObservableCollection<OpcionBoard>();
                    OpcionBoard ob = new OpcionBoard() { Titulo = "Yún", Descripcion = "Arduino - Preparado para IoT" };
                    list.Add(ob);

                    ob = new OpcionBoard() { Titulo = "Tre", Descripcion = "Arduino - Preparado para IoT" };
                    list.Add(ob);


                   ob = new OpcionBoard() { Titulo = "Galileo", Descripcion = "Arduino - Preparado para IoT" };
                    list.Add(ob);

                    ob = new OpcionBoard() { Titulo = "Ethernet", Descripcion = "Arduino - Preparado para IoT" };
                    list.Add(ob);

                    ob = new OpcionBoard() { Titulo = "Due", Descripcion = "Arduino - Preparado para IoT" };
                    list.Add(ob);

                    ob = new OpcionBoard() { Titulo = "UNO", Descripcion = "Arduino" };
                    list.Add(ob);

                    ob = new OpcionBoard() { Titulo = "Mega", Descripcion = "Arduino" };
                    list.Add(ob);
       
                    ob = new OpcionBoard() { Titulo = "B Model", Descripcion = "Raspberry - Preparado para IoT" };
                    list.Add(ob);

                

                }
                return list;
            
            }
            set { list = value; }
    
        }
    }
}
