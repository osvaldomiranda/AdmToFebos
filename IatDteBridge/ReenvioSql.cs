using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace IatDteBridge
{
    class ReenvioSql
    {
        String strConn = @"Data Source=C:/IatFiles/iatDB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public void addReenvio(String jsonName, String envunit, String pdft, String pdfc, String filecliente, String filefactura)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                String fecha = String.Format("{0:yyyyMMddTHHmmss}", thisDay);

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "insert into reenvio (fch, jsonname, envunit, pdft, pdfc, filecliente, filefactura, estado) values ('" + fecha + "' , '" + jsonName + "','" + envunit + "','" + pdft + "','" + pdfc + "','" + filecliente + "','" + filefactura + "', 'CREADO')";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
        }

        public List<String> sgteReenvio()
        {

            List<String> sgteEnv = new List<String>();

            try
            {
                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "select * from reenvio where estado = 'CREADO' order by fch";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sgteEnv.Add(reader["jsonname"].ToString());
                    sgteEnv.Add(reader["envunit"].ToString());
                    sgteEnv.Add(reader["pdft"].ToString());
                    sgteEnv.Add(reader["pdfc"].ToString());
                    sgteEnv.Add(reader["filecliente"].ToString());
                    sgteEnv.Add(reader["filefactura"].ToString());
                    break;
                }

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return sgteEnv;
            }

            return sgteEnv;
        }

        public void cambioEstadoReenvio(String estado, String jsonname)
        {
            try
            {
                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "update reenvio set estado = '" + estado + "' where jsonname = '" + jsonname + "'";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
        }

        public String verReenv()
        {
            String logRes = String.Empty;
            try
            {
                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "select * from reenvio order by fch";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine("Json: " + reader["jsonname"] + "\tXML: " + reader["envunit"] + "\tpdfT: " + reader["pdft"] + "\tpdfc: " + reader["pdfc"] + "\tFecha: " + reader["fch"] + "\testado: " + reader["estado"]);

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return logRes;
            }

            return logRes;
        }
    }
}
