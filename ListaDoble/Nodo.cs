using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDoble
{
    class Nodo
    {
        private int numero;
        private string nombre;
        private Nodo siguiente;
        private Nodo anterior;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        public Nodo Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }
        public Nodo()
        {
            numero = 0;
            nombre = "";
            siguiente = null;
            anterior = null;
        }

        public Nodo(int d, string n)
        {
            numero = d;
            nombre = n;
            siguiente = null;
            anterior = null;
        }

        public override string ToString()
        {
            return numero + " - " + nombre;
        }

    }
}
