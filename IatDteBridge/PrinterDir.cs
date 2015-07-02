using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace IatDteBridge
{
    class PrinterDir
    {
        public String printerName;
        public String directory;

        public List<PrinterDir> printerList()
        {
            String strConn = @"Data Source=C:/IatFiles/iatDB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            List<PrinterDir> printers = new List<PrinterDir>();

            try
            {
                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "select * from printers";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    PrinterDir printer = new PrinterDir();
                    printer.printerName = reader["printername"].ToString();
                    printer.directory = reader["directory"].ToString();
                    printers.Add( printer);
    
                }

                myConn.Close();

                return printers;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return printers;
            }

            
        }
    }
}
