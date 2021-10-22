using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDoble
{
    public partial class Form1 : Form
    {
        ListaDoble miLista;
        Graphics graficos;
        public Form1()
        {
            InitializeComponent();
            miLista = new ListaDoble();
            this.WindowState = FormWindowState.Maximized;
            graficos = this.CreateGraphics();

            //Color c = new Color();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string nombreArchivo = "ListaDoble";
            miLista.Cargar(nombreArchivo);
            miLista.Mostrar(lstvDatos);

          
           
            for (int i = 0; i < lstvDatos.Items.Count; i++)
            {
                DibujarRectangulo(i);
            }
        }
        public void DibujarRectangulo(int x)
        {

            Pen pluma = new Pen(Color.Black, 2);
            Rectangle rectangulo = new Rectangle(10 + (x * 120), 400, 100, 50);
            graficos.DrawRectangle(pluma, rectangulo);
            graficos.DrawLine(pluma, 80 + (x * 120), 400, 80 + (x * 120), 450);
            graficos.DrawLine(pluma, 40 + (x * 120), 400, 40 + (x * 120), 450);

            graficos.DrawLine(pluma, 95 + (x * 120), 410, 130 + (x * 120), 410);
            graficos.DrawLine(pluma, 110 + (x * 120), 440, 142 + (x * 120), 440);
        }
       
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                string nombre = txtNombre.Text;
                int equipo = int.Parse(txtEquipo.Text);
                string tema = txtTema.Text;
                string nombreArchivo = "ListaDoble";
                Nodo n = new Nodo(numero, nombre, equipo, tema);

                miLista.Agregar(n);
                txtNumero.Clear();
                txtNombre.Clear();
                txtEquipo.Clear();
                txtTema.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstvDatos);
                miLista.Guardar(nombreArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
          
            for (int i = 0; i < lstvDatos.Items.Count; i++)
            {
                DibujarRectangulo(i);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                string nombreArchivo = "ListaDoble";
                miLista.Eliminar(numero);
                txtNumero.Clear();
                txtNumero.Focus();
                txtEquipo.Clear();
                txtTema.Clear();
                miLista.Mostrar(lstvDatos);
                miLista.Guardar(nombreArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            graficos.Clear(Color.Coral);
            for (int i = 0; i < lstvDatos.Items.Count; i++)
            {
                DibujarRectangulo(i);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                Nodo n = new Nodo();
                if (miLista.Buscar(numero, ref n))
                {
                    txtNombre.Text = n.Nombre;
                    txtEquipo.Text = n.Equipo+"";
                    txtTema.Text = n.Tema;
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
                int equipo = int.Parse(txtEquipo.Text);
                string nombreArchivo = "ListaDoble";
                miLista.Modificar(numero, txtNombre.Text, equipo, txtTema.Text);
                txtNumero.Clear();
                txtNombre.Clear();
                txtEquipo.Clear();
                txtTema.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstvDatos);
                miLista.Guardar(nombreArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
