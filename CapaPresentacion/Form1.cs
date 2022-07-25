using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion;
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FormAgenda : Form
    {
        private string Id;
        private bool Edit = false;
        E_class obEntidad = new E_class();
        N_class obNegocio = new N_class();
        public FormAgenda()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionTabla();
        }

        public void accionTabla()
        {
            dgv.ClearSelection();
        }

        public void mostrarBuscarTabla(string buscar)
        {
            
            dgv.DataSource = obNegocio.ListarDatos(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtOcupacion.Text = "";
            txtNombre.Focus();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                Edit = true;
                Id = dgv.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                txtTelefono.Text = dgv.CurrentRow.Cells[3].Value.ToString();
                txtOcupacion.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila a editar");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    obEntidad.Nombre = txtNombre.Text.ToUpper();
                    obEntidad.Apellidos = txtApellido.Text.ToUpper();
                    obEntidad.Telefono = txtTelefono.Text.ToUpper();
                    obEntidad.Ocupacion = txtOcupacion.Text.ToUpper();
                
                    obNegocio.InsertarDatos(obEntidad);

                    MessageBox.Show("Registro guardado");
                    mostrarBuscarTabla("");
                    Limpiar();

                    Edit = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
            else if (Edit == true)
            {
                try
                {
                    obEntidad.Id = Convert.ToInt32(Id);
                    obEntidad.Nombre = txtNombre.Text.ToUpper();
                    obEntidad.Apellidos = txtApellido.Text.ToUpper();
                    obEntidad.Telefono = txtTelefono.Text.ToUpper();
                    obEntidad.Ocupacion = txtOcupacion.Text.ToUpper();

                    obNegocio.EditarDatos(obEntidad);

                    MessageBox.Show("Registro editado");
                    mostrarBuscarTabla("");
                    Limpiar();

                    Edit = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                obEntidad.Id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
                obNegocio.EliminarDatos(obEntidad);

                MessageBox.Show("Registro eliminado correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona la fila que deseas eliminar");
            }
        }
    }
}