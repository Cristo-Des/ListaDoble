using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDoble
{
    public partial class Form1 : Form
    {
        ListaDoble miLista;
        public Form1()
        {
            InitializeComponent();
            miLista = new ListaDoble();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            miLista.Cargar();
            miLista.Mostrar(lstDatos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                string nombre = txtNombre.Text;
                Nodo n = new Nodo(numero, nombre);

                miLista.Agregar(n);
                txtNumero.Clear();
                txtNombre.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
                miLista.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);

                miLista.Eliminar(numero);
                txtNumero.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
                miLista.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                Nodo b = new Nodo();
                if (miLista.Buscar(numero, ref b))
                {
                    txtNombre.Text = b.Nombre;
                }
                else
                {
                    MessageBox.Show("No Existe");
                    txtNumero.Clear();
                    txtNumero.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);

                miLista.Modificar(numero, txtNombre.Text);
                txtNumero.Clear();
                txtNombre.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
                miLista.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
