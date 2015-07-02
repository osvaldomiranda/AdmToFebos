using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace IatDteBridge
{
    class ConnectDb
    {
        String strConn = @"Data Source=C:/IatFiles/iatDB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public String GetUrl()
        {
            String url = "";         
            try
            {
                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();
                string sql = "SELECT * FROM EMPRESA";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    url = reader["UrlCore"].ToString();
                }

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                
            }

            return url;
        }
        
    }
}
