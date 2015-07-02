using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace IatDteBridge
{
    class Empresa
    {
        // Rut de la empresa
        public String RutEmisor { get; set; } 
        // Razon social de la empresa
        public String RznSoc { get; set; }
        //Giro de la Empresa
        public String GiroEmis { get; set; }
        //Telefonos de la empresa
        public String Telefono { get; set; }
        //Correo de la empresa
        public String CorreoEmisor { get; set; }
        // Actividad economica de la empresa
        public String Acteco { get; set; }
        //Codigo de sucursal de la empresa
        public String CdgSIISucur { get; set; }
        //Dirección de la casa matriz
        public String DirMatriz { get; set; }
        //Ciudad de Origen de la sucursal
        public String CiudadOrigen { get; set; }
        // Comuna de origen de la sucursal
        public String CmnaOrigen { get; set; }
        // Sucursal del SII
        public String SucurSII { get; set; }
        // Nombre del Certificado Electronico
        public String NomCertificado { get; set; }
        // Direccion de la Sucursal de origen
        public String DirOrigen { get; set; }
        //Fecha de Resolución de la empresa
        public String FchResol { get; set; }
        // Rut del Certificado
        public String RutCertificado { get; set; }
        // Numero de Resolución
        public String NumResol { get; set; }
        // Estado de la condiciónd e entrega en pdf
        public String CondEntrega { get; set; }


        public void creaTabla() 
        {
            String strConn = @"Data Source=C:/IatFiles/iatDB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

          try
            {
                if (!System.IO.File.Exists("C:/IatFiles/iatDB.sqlite"))
                {
                    MessageBox.Show("La Base de Datos no Existe");
                }
                else
                {
                    SQLiteConnection myConn = new SQLiteConnection(strConn);
                    myConn.Open();

                    String sql1 = "CREATE TABLE IF NOT EXISTS empresa (RutEmisor VARCHAR(10), RznSoc VARCHAR(255), GiroEmis VARCHAR(255), Telefono VARCHAR(255), CorreoEmisor VARCHAR(255), Acteco VARCHAR(50), CdgSIISucur VARCHAR(50), DirMatriz VARCHAR(255), CiudadOrigen VARCHAR(255), CmnaOrigen VARCHAR(255), SucurSII VARCHAR(100), NomCertificado VARCHAR(255), DirOrigen VARCHAR(255), FchResol VARCHAR(50), RutCertificado VARCHAR(10), NumResol VARCHAR(20)) ";


                    SQLiteCommand cmd = new SQLiteCommand(sql1, myConn);
                    cmd.ExecuteNonQuery();

                    myConn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
               
            }
                   


        }
    }
}
