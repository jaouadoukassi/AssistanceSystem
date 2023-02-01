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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelbienvenido.Dock= DockStyle.Fill;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            
        }

        private void BTNpersonal_Click(object sender, EventArgs e)
        {
            panelPadre.Controls.Clear();
            Personal control= new Personal();
            control.Dock= DockStyle.Fill;
            panelPadre.Controls.Add(control);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblLogo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}
