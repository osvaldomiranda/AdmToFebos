using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace IatDteBridge
{
    class UltimoDteSql
    {
        String strConn = @"Data Source=C:/IatFiles/iatDB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public void addUltmoDte(Documento doc)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                String fecha = String.Format("{0:yyyyMMddTHHmmss}", thisDay);

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "insert into ultimodte (RutEmisor, RznSoc, CdgSIISucur, RutRecep, RznSocRecep, Folio, TipoDTE, fch) values ('" +
                              doc.RUTEmisor+"','"+doc.RznSoc+"',"+doc.CdgSIISucur+",'"+ doc.RUTRecep+"','"+ doc.RznSocRecep+"',"+ doc.Folio +","+ doc.TipoDTE +",'"+ fecha +"')";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
        }


        public String getUltimoDte()
        {
            String dteRes = String.Empty;
            try
            {
                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "select * from ultimodte order by fch";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    dteRes = "{\"RutEmisor\"=>\"" + reader["RutEmisor"] + "\", \"RznSoc\"=>\"" + reader["RznSoc"] +
                              "\",\"CdgSIISucur\"=>\"" + reader["CdgSIISucur"] + "\",\"RutRecep\"=>\"" + reader["RutRecep"] +
                              "\",\"RznSocRecep\"=>\"" + reader["RznSocRecep"] + "\",\"Folio\"=>" + reader["Folio"] +
                              ",\"TipoDTE\"=>" + reader["TipoDTE"] + ",\"fch\"=>\"" + reader["fch"] + "\"}";


                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return dteRes;
            }

            return dteRes;
        }

    }
}
