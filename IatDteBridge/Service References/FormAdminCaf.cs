using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IatDteBridge
{
    public partial class FormAdminCaf : Form
    {
        public FormAdminCaf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(openFileDialog1.FileName);
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                fileAdmin file = new fileAdmin();
                file.mvFile(fi.Name, fi.Directory.ToString()+@"\", @"c:\IatFiles\cafs\factura\");
              
            }
        }
    }
}
