﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrusProject.LOGICA
{
    public class Bases
    {
        public static void DiseñoDtv(ref DataGridView Listado)
        {
            Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Listado.BackgroundColor = Color.FromArgb(29,29,29);
            Listado.EnableHeadersVisualStyles= false;
            Listado.BorderStyle= BorderStyle.None;
            Listado.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Listado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Listado.RowHeadersVisible= false;
            DataGridViewCellStyle cabecera = new DataGridViewCellStyle();
            cabecera.BackColor = Color.FromArgb(29, 29, 29);
            cabecera.ForeColor = Color.White;
            cabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Listado.ColumnHeadersDefaultCellStyle = cabecera;
        }
        public static object Decimales(TextBox CajaTexto, KeyPressEventArgs e)
        {
            if((e.KeyChar == ',') || (e.KeyChar == '.'))
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }
            if(char.IsDigit(e.KeyChar))
            {
                e.Handled = false; // la propiedad Handled si está en false te permite escribir y si está en true no te permite.
            }
            else if(char.IsControl(e.KeyChar)) //si tocas la tecla borrar te permite a borrar
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == ',') && (~CajaTexto.Text.IndexOf(","))!=0)
            {
                e.Handled = true;
            }
            else if(e.KeyChar=='.')
            {
                e.Handled= false;
            }
            else if(e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return null;
            
        }
    }
}
