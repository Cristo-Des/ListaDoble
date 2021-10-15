using System;
using System.Windows.Forms;
using System.IO;

namespace ListaDoble
{
    class ListaDoble
    {
        private Nodo head;
        //private Nodo feet;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }
        //public Nodo Feet
        //{
        //    get { return feet; }
        //    set { feet = value; }
        //}

        public ListaDoble()
        {
            head = null;
            //feet = null;
        }

        public void Agregar(Nodo n)
        {
            if (head == null)
            {
                head = n;
                //feet = head;
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

        public void Eliminar(int d)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == d)
            {
                head = head.Siguiente;
                head.Anterior = null;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
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
            h.Siguiente.Anterior = h;

            /*
            Nodo actual = new Nodo();
            Nodo anterior = new Nodo();
            actual = head;
            bool encontrado = false;
            int nodoBuscado = int.Parse(Console.ReadLine());
            while (actual != null && encontrado == false)
            {
                if (actual.Numero == nodoBuscado)
                {
                    if (actual == head)
                    {
                        head = head.Siguiente;
                        head.Anterior = null;
                    }
                    else if (actual == feet)
                    {
                        anterior.Siguiente = null;
                        feet = anterior;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = anterior;
                    }
                    Console.WriteLine("nodo con el Numero ((0)) encontrado", actual.Numero);

                    encontrado = true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
            */
        }

        public bool Buscar(int d, ref Nodo b)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Numero == d)
            {
                b = head;
                return true;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    b = h.Siguiente;
                    return true;
                }
                h = h.Siguiente;
            }
            return false;

            /*
            Nodo actual = new Nodo();
            actual = head;
            bool encontrado = false;
            Console.Write("ingrese el nodo a buscar");
            int nodoBuscado = int.Parse(Console.ReadLine());
            while (actual != null && encontrado == false)
            {
                if (actual.Numero == nodoBuscado)
                {
                    Console.WriteLine("nodo con el Numero ((0)) encontrado", actual.Numero);
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }
            */
        }

        public void Modificar(int d, string n)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == d)
            {
                head.Nombre = n;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    h.Siguiente.Nombre = n;
                    return;
                }
                h = h.Siguiente;
            }
            return;

            /*
            Nodo actual = new Nodo();
            actual = head;
            bool encontrado = false;
            Console.Write("ingrese el Numero del nodo a modificar");
            int nodoBuscado = int.Parse(Console.ReadLine());
            while (actual != null && encontrado == false)
            {
                if (actual.Numero == nodoBuscado)
                {
                    Console.WriteLine("nodo con el Numero ((0)) encontrado", actual.Numero);
                    Console.Write("ingrese el nuevo Numero para este nodo");
                    actual.Numero = int.Parse(Console.ReadLine());   // 90
                    Console.WriteLine("nodo modificado");
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }
            if (!encontrado)
            {
                Console.WriteLine("nodo no encontrado");
            }
            */
        }

        public void Mostrar(ListBox lista)
        {
            Nodo h = head;
            lista.Items.Clear();
            while (h != null)
            {
                lista.Items.Add(h.Numero+ " - " + h.Nombre);
                h = h.Siguiente;
            }
        }

        public void Guardar()
        {
            string nombreArchivo = "ListaDoble";
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
                    sw.WriteLine(h.Numero + "-" + h.Nombre);
                    h = h.Siguiente;
                } while (h != null);
            }
            return;
        }

        public void Cargar()
        {
            string nombreArchivo = "ListaDoble";
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
                Nodo n = new Nodo(numero, nombre);
                Agregar(n);
            }
        }

        /*
        public void DesplegarListaPU()
        {
            Nodo actual = new Nodo();
            actual = head;
            while (actual != null)
            {
                Console.WriteLine(" " + actual.Numero);
                actual = actual.Siguiente;
            }
        }

        public void DesplegarListaUP()
        {
            Nodo actual = new Nodo();
            actual = feet;
            while (actual != null)
            {
                Console.WriteLine(" " + actual.Numero);
                actual = actual.Anterior;
            }
        }
        */

    }
}
