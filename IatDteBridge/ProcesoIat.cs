using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace IatDteBridge
{
    class ProcesoIat
    {

        public void DoProcessIat()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("ProcessIat thread: working...");
                Thread.Sleep(5000);

                DateTime thisDay = DateTime.Now;
                String fch = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", thisDay);
                String fchName = String.Format("{0:yyyyMMddTHHmmss}", thisDay);

                String dirCurrentFile = String.Empty;
                TxtReader lec = new TxtReader();
                Documento doc = new Documento();
                doc = lec.lectura("", true, dirCurrentFile);
                if (doc != null)
                {
                    Connect conn = new Connect();
                    User user = new User();
                    user = conn.login("10207640-0@febos.cl", "10207640-0");
                    Console.WriteLine("Token " + user.token);
                    Console.WriteLine("Uid  " + user.uid);
                    String fileName = @"C:/AdmToFebosFiles/files/DTE_" + doc.RUTEmisor + "_" + doc.TipoDTE + "_" + doc.Folio + "_" + fchName + ".txt";
                    lec.createTxtFbos(doc, fileName);
                    String febosID = conn.sendInvoice(fileName, user, doc.Folio.ToString());

                    String folioFiscal = conn.getFolioFiscal(user, febosID);
                    Thread.Sleep(2000);
                    conn.updFolioAdm(doc, febosID, folioFiscal);
                }
            } 
            Console.WriteLine("ProcessIat thread: terminating gracefully.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        private volatile bool _shouldStop;


        public void StartProcessIat()
        {
            // Create the thread object. This does not start the thread.

            Thread processIatThread = new Thread(DoProcessIat);

            // Start the worker thread.
            processIatThread.Start();
            Console.WriteLine("main thread: Starting ProcessIat thread...");

            // Loop until worker thread activates. 
            while (!processIatThread.IsAlive) ;


        }

        public void StopProcessIat()
        {

            RequestStop();

            Console.WriteLine("main thread: ProcessIat thread has terminated.");

        }


    }
}
