using OrusProject.DATOS;
using OrusProject.LOGICA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrusProject.Presentación
{
    public partial class Personal : UserControl
    {
        public Personal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelCargos.Visible = false;
            panelPaginado.Visible = false;
            panelRegistros.Visible = true;
            panelRegistros.Dock= DockStyle.Fill;// para que expanda todo el espacio
            btnGuardarPersonal.Visible = true;
            btnGuardarCambiosPersonal.Visible = false;
            Limpiar();
        }

        private void Limpiar()
        {
            txtcargo.Clear();
            txtNombres.Clear();
            txtIdentificacion.Clear();
            txtSueldoPorHora.Clear();
            BuscarCargo();
        }
        private void btnGuardarPersonal_Click(object sender, EventArgs e)
        {

        }

        private void Insertar_Personal()
        {
            //Instanciar un objeto de la clase Lpersonal para llamar a los parametros
            Lpersonal parametros = new Lpersonal();
            // igual a la clase Dpersonal 
            Dpersonal funcion = new Dpersonal();
            parametros.Nombres = txtNombres.Text;
            parametros.Identificación = txtIdentificacion.TabIndex;
            parametros.Pais = cmbPais.Text;
        }

        private void InsertarCargos()
        {
            Lcargo parametros = new Lcargo();
            Dcargos funcion = new Dcargos();
            parametros.Cargo = txtCargoG.Text;
            parametros.SueldoPorHora = Convert.ToDouble(txtSueldoHoraG.Text);
            if(funcion.insertar_Cargo(parametros) == true)
            {
                txtcargo.Clear();
                BuscarCargo();
            }
        }

        private void BuscarCargo()
        {
            DataTable dt = new DataTable();
            Dcargos funcion = new Dcargos();
            funcion.buscarCargos(ref dt, txtcargo.Text);
            dataListCargos.DataSource = dt;// Pasar Datos al elemento dataGridView = dataListCargos.
            Bases.DiseñoDtv(ref dataListCargos);
        }

        private void txtcargo_TextChanged(object sender, EventArgs e)
        {
            BuscarCargo();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
