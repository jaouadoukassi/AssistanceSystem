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
        int idCargo =0;
        int desde = 1;
        int hasta = 10;
        int contador;
        int Idpersonal;
        private int items_por_pagina = 10;
        string estado;
        int totalPaginas;


        public Personal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LocalizarDtvCargos();
            panelCargos.Visible = false;
            panelPaginado.Visible = false;
            panelRegistros.Visible = true;
            panelRegistros.Dock= DockStyle.Fill;// para que expanda todo el espacio
            btnGuardarPersonal.Visible = true;
            btnGuardarCambiosPersonal.Visible = false;
            Limpiar();
        }

        private void LocalizarDtvCargos()
        {
            dataListCargos.Location = new Point(txtSueldoPorHora.Location.X, txtSueldoPorHora.Location.Y);
            dataListCargos.Size = new Size(562, 132);
            dataListCargos.Visible = true;
            lblSueldo.Visible = false;
            PanelBtnGuardarPer.Visible = false;
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
            if (!string.IsNullOrEmpty(txtNombres.Text))
            {
                if (!string.IsNullOrEmpty(txtIdentificacion.Text))
                {
                    if (!string.IsNullOrEmpty(cmbPais.Text))
                    {
                        if (idCargo > 0)
                        {
                            if (!string.IsNullOrEmpty(txtSueldoPorHora.Text))
                            {
                                Insertar_Personal();
                            }
                        }
                    }
                }
            }
        }

        private void MostrarPersonal()
        {
            DataTable dataTable= new DataTable();   
            Dpersonal funcion = new Dpersonal();
            funcion.mostrarPersonal(ref dataTable, desde, hasta);
            dataListPersonal.DataSource = dataTable;
            DesingDTVPersonal();
        }

        private void DesingDTVPersonal()
        {
            Bases.DiseñoDtv(ref dataListPersonal);
            panelPaginado.Visible = true;
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
            parametros.Id_cargo = idCargo;
            parametros.SueldoPorHora = Convert.ToDouble(txtSueldoHoraG.Text);
            if(funcion.InsertarPersonal(parametros) == true)
            {
                MostrarPersonal(); 
                panelRegistros.Visible = false;
            }
        }

        private void InsertarCargos()
        {
            if (!string.IsNullOrEmpty(txtCargoG.Text))
            {
                if (!string.IsNullOrEmpty(txtSueldoHoraG.Text))
                {
                    Lcargo parametros = new Lcargo();
                    Dcargos funcion = new Dcargos();
                    parametros.Cargo = txtCargoG.Text;
                    parametros.SueldoPorHora = Convert.ToDouble(txtSueldoHoraG.Text);
                    if (funcion.insertar_Cargo(parametros) == true)
                    {
                        txtcargo.Clear();
                        BuscarCargo();
                        panelCargos.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Agrege el Sueldo", "Falta El Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Agrege el Cargo", "Falta El Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void BuscarCargo()
        {
            DataTable dt = new DataTable();
            Dcargos funcion = new Dcargos();
            funcion.buscarCargos(ref dt, txtcargo.Text);
            dataListCargos.DataSource = dt;// Pasar Datos al elemento dataGridView = dataListCargos.
            Bases.DiseñoDtv(ref dataListCargos);
            dataListCargos.Columns[1].Visible= false;
            dataListCargos.Columns[3].Visible = false;
            dataListCargos.Visible=true;
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

        private void btnAgregarCargo_Click(object sender, EventArgs e)
        {
            panelCargos.Visible = true;
            panelCargos.Dock = DockStyle.Fill;
            panelCargos.BringToFront(); //le digamos venga al frente.
            btnGuardarC.Visible= true;
            btnGuardarCambiosC.Visible= false;
            txtCargoG.Clear();
            txtSueldoHoraG.Clear();
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            InsertarCargos();
        }

        private void txtSueldoHoraG_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSueldoHoraG, e);
        }

        private void txtSueldoPorHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSueldoPorHora, e);
        }      

        private void dataListCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataListCargos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //MessageBox.Show("You clicked cell: " + cell.Value.ToString());
                ObtenerCargosEditar();

            }
            //ColumnIndex representa el numero de culomna a nivel de DataGridView
            //if (e.ColumnIndex == dataListCargos.Columns["EditarC"].Index)
            //{
            //    ObtenerCargosEditar();
            //}
            if (e.ColumnIndex == dataListCargos.Columns["Cargo"].Index)
            {
                ObtenerDatosCargo();
            }
        }
        private void ObtenerDatosCargo()
        {
            idCargo = Convert.ToInt32(dataListCargos.SelectedCells[1].Value);
            txtcargo.Text = dataListCargos.SelectedCells[2].Value.ToString();
            txtSueldoPorHora.Text = dataListCargos.SelectedCells[3].Value.ToString();
            dataListCargos.Visible = false;
            PanelBtnGuardarPer.Visible = true;
            lblSueldo.Visible = true;
        }


        private void ObtenerCargosEditar()
        {
            idCargo = Convert.ToInt32(dataListCargos.SelectedCells[1].Value);
            txtCargoG.Text = dataListCargos.SelectedCells[2].Value.ToString();
            txtSueldoHoraG.Text = dataListCargos.SelectedCells[3].Value.ToString();
            btnGuardarC.Visible = false;
            btnGuardarCambiosC.Visible = true;
            txtCargoG.Focus();
            txtCargoG.SelectAll();
            panelCargos.Visible = true;
            panelCargos.Dock = DockStyle.Fill;
            panelCargos.BringToFront();
        }

        private void btnVolverCargos_Click(object sender, EventArgs e)
        {
            panelCargos.Visible = false;
        }

        private void panelVolverPersonal_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = false;
        }

        private void btnGuardarCambiosC_Click(object sender, EventArgs e)
        {
            editarCargos();
        }
        private void editarCargos()
        {
            Lcargo parametros = new Lcargo();
            Dcargos funcion = new Dcargos();
            parametros.Id_Cargo = idCargo;
            parametros.Cargo = txtCargoG.Text;
            parametros.SueldoPorHora = Convert.ToDouble(txtSueldoHoraG.Text);
            if (funcion.editar_Cargo(parametros) == true)
            {
                txtcargo.Clear();
                BuscarCargo();
                editarCargos();
            }
        }

        
    }
}
