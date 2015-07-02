using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IatDteBridge
{
    public partial class Administracion : Form
    {

        public Administracion()
        {
            InitializeComponent();
        }

        private void datosEmisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmisor formemisor = new FormEmisor();
            formemisor.MdiParent = this;
            formemisor.Show();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Administracion_Load(object sender, EventArgs e)
        {

        }

        private void procesaPaqueteToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void libroVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void libroComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void libroGuiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
