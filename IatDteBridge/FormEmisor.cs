using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace IatDteBridge
{
    public partial class FormEmisor : Form
    {

        String strConn = @"Data Source=C:/IatFiles/iatDB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public FormEmisor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormEmisor_Load(object sender, EventArgs e)
        {
            //abrir archivo empresa.txt si existe recuperar datos en textbox
            String lineEmisor = String.Empty;




            try
            {

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "select * from empresa";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    textBox_RUTEmisor.Text = reader["RutEmisor"].ToString();
                    textBox_RznSoc.Text = reader["RznSoc"].ToString();
                    textBox_GiroEmis.Text = reader["GiroEmis"].ToString();
                    textBox_Telefono.Text = reader["Telefono"].ToString();
                    textBox_CorreoEmisor.Text = reader["CorreoEmisor"].ToString();
                    textBox_Acteco.Text = Convert.ToString(reader["Acteco"]);
                    textBox_CdgSIISucur.Text = Convert.ToString(reader["CdgSIISucur"]);
                    textBox_DirMatriz.Text = reader["DirMatriz"].ToString();
                    textBox_CdadOrigen.Text = reader["CiudadOrigen"].ToString();
                    textBox_CmnaOrigen.Text = reader["CmnaOrigen"].ToString();
                    textBox_DirOrigen.Text = reader["DirOrigen"].ToString();
                    textBox_ScsalSII.Text = reader["SucurSII"].ToString();
                    textBox_NbreCertificado.Text = reader["NomCertificado"].ToString();
                    textBox_Sucursales.Text = reader["SucurEmisor"].ToString();
                    textBox_FchResol.Text = reader["FchResol"].ToString();
                    textBox_RutCertificado.Text = reader["RutCertificado"].ToString();
                    textBox_NumResol.Text = reader["NumResol"].ToString();
                    textBox_UrlCore.Text = reader["UrlCore"].ToString();
                    checkBox_condEntrega.Checked = Convert.ToBoolean(reader["CondEntrega"]);

                }
                myConn.Close();
            }
            catch (Exception s)
            {
                Console.WriteLine("ERROR: {0}"+ s.ToString());
                MessageBox.Show("ERROR: {0}"+ s.ToString());
            }

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            // guardar información del FormEmisor
            try
            {


                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "UPDATE empresa set " +
                               "RutEmisor = '" + textBox_RUTEmisor.Text + "', " +
                               "RznSoc = '" + textBox_RznSoc.Text + "', " +
                               "GiroEmis = '" + textBox_GiroEmis.Text + "', " +
                               "Telefono = '" + textBox_Telefono.Text + "', " +
                               "CorreoEmisor= '" + textBox_CorreoEmisor.Text + "', " +
                               "Acteco = " + Convert.ToInt32(textBox_Acteco.Text) + "," +
                               "CdgSIISucur = " + Convert.ToInt32(textBox_CdgSIISucur.Text) + ", " +
                               "DirMatriz = '" + textBox_DirMatriz.Text + "', " +
                               "CiudadOrigen = '" + textBox_CdadOrigen.Text + "', " +
                               "CmnaOrigen = '" + textBox_CmnaOrigen.Text + "', " +
                               "DirOrigen = '" + textBox_DirOrigen.Text + "', " +
                               "SucurSII = '" + textBox_ScsalSII.Text + "', " +
                               "NomCertificado = '" + textBox_NbreCertificado.Text + "', " +
                               "SucurEmisor = '" + textBox_Sucursales.Text + "', " +
                               "FchResol = '" + textBox_FchResol.Text + "', " +
                               "RutCertificado = '" + textBox_RutCertificado.Text + "', " +
                               "NumResol = '" + textBox_NumResol.Text + "', " +
                               "CondEntrega = '" + checkBox_condEntrega.Checked.ToString() + "', "+
                                "UrlCore = '" + textBox_UrlCore.Text + "';";

                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception empUpdate)
            {
                Console.WriteLine("ERROR: {0}"+ empUpdate.ToString());
                MessageBox.Show("ERROR: {0}"+ empUpdate.ToString());
            }


            MessageBox.Show("Guardado con exito");
         }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_condEntrega_CheckedChanged(object sender, EventArgs e)
        {

        }




     }
}

