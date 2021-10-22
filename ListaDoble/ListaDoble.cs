using System;
using System.Windows.Forms;
using System.IO;

namespace ListaDoble
{
    class ListaDoble
    {
        private Nodo head;
       

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }
      

        public ListaDoble()
        {
            head = null;
           
        }

        public void Agregar(Nodo n)
        {
            if (head == null)
            {
                head = n;
               
                return;
            }
            if (n.Numero < head.Numero)
            {
                n.Siguiente = head;
                head = n;
                n.Siguiente.Anterior = n;
                return;

            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (n.Numero < h.Siguiente.Numero)
                {
                    break;
                }
                h = h.Siguiente;
            }
            n.Siguiente = h.Siguiente;
            n.Anterior = h;
            h.Siguiente = n;
            if (h.Siguiente.Siguiente != null)
            {
                h.Siguiente.Siguiente.Anterior = n;
            }
        }

        public void Eliminar(int num)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == num)
            {
                head = head.Siguiente;
                head.Anterior = null;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == num)
                {
                    break;
                }
                h = h.Siguiente;
            }
            if (h.Siguiente == null)
            {
                return;
            }
            h.Siguiente = h.Siguiente.Siguiente;
            if (h.Siguiente != null)
            {
                h.Siguiente.Anterior = h;
            }
        }

        public bool Buscar(int num, ref Nodo n)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Numero == num)
            {
                n = head;
                return true;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == num)
                {
                    n = h.Siguiente;
                    return true;
                }
                h = h.Siguiente;
            }
            return false;
        }

        public void Modificar(int num, string nom,int equipo, string tema)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == num)
            {
                head.Nombre = nom;
                head.Equipo = equipo;
                head.Tema = tema;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == num)
                {
                    h.Siguiente.Nombre = nom;
                    h.Siguiente.Equipo = equipo;
                    h.Siguiente.Tema = tema;

                    return;
                }
                h = h.Siguiente;
            }
            return;
        }

        public void Mostrar(ListView lista)
        {
            Nodo h = head;
            lista.Items.Clear();
            while (h != null)
            {
                ListViewItem lv = new ListViewItem(h.Numero + "");
                lv.SubItems.Add(h.Nombre);
                lv.SubItems.Add(h.Equipo+"");
                lv.SubItems.Add(h.Tema);
                lista.Items.Add(lv);
                h = h.Siguiente;
            }
        }

        public void Guardar(string nombreArchivo)
        {
            //string nombreArchivo = "ListaDoble";
            Nodo h = head;
            if (head == null)
            {
                return;
            }
            string path = @"D:\" + nombreArchivo + ".txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                do
                {
                    sw.WriteLine(h.Numero + "-" + h.Nombre + "-" + h.Equipo + "-" + h.Tema);
                    h = h.Siguiente;
                } while (h != null);
            }
            return;
        }

        public void Cargar(string nombreArchivo)
        {
           // string nombreArchivo = "ListaDoble";
            string path = @"D:\" + nombreArchivo + ".txt";
            if (!File.Exists(path))
            {
                return;
            }
            string[] lineas = File.ReadAllLines(path);
            foreach (string linea in lineas)
            {
                if (linea.Length == 0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int numero = int.Parse(datos[0]);
                string nombre = datos[1];
                int equipo = int.Parse(datos[2]);
                string tema = datos[3];
                Nodo n = new Nodo(numero, nombre, equipo, tema);
                Agregar(n);
            }
        }

    }
}
