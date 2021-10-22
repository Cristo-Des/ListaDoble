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
        private int equipo;
        private string tema;
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
        public int Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

        public string Tema
        {
            get { return tema; }
            set { tema = value; }
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
            equipo = 0;
            tema = "";
            siguiente = null;
            anterior = null;
        }

        public Nodo(int d, string n, int e, string t)
        {
            numero = d;
            nombre = n;
            equipo = e;
            tema = t;
            siguiente = null;
            anterior = null;
        }

        public override string ToString()
        {
            return numero + " - " + nombre + " - " + equipo + " - " + tema;
        }

    }
}
