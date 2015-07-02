using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IatDteBridge
{
    class ProcesoContingencia
    {

        public void procesoContingencia()
        {

            while (!_shouldStop)
            {
                
             //   Thread.Sleep(60000); // Duerme 10 minutos
                Thread.Sleep(120000);
                Console.WriteLine("ProcessContingencia thread: working...");

                Connect conn = new Connect();
                Log log = new Log();
                String ping = String.Empty;

                String envunit = String.Empty;
                String pdft = String.Empty;
                String pdfc = String.Empty;
                String jsonName = String.Empty;
                String filecliente = String.Empty;
                String filefactura = String.Empty;

                if (ping == "{\"status\":\"Ok\"}")
                {

                    ReenvioSql reenv = new ReenvioSql();
                    // saco el nombres de los archivos  json, enviomasivo.xml pdfT y pdfC

                    List<String> listaReenvio = new List<string>();

                    listaReenvio = reenv.sgteReenvio();
                    // cargo clase Documento
                    Documento doc = new Documento();
                    TxtReader json = new TxtReader();

                    int i = 0;
                    foreach (var reenvio in listaReenvio)
                    {
                        i++;
                        switch (i)
                        {
                            case 1:
                                {
                                    doc = json.lectura(reenvio, false, @"c:\IatFiles\fileprocess\");
                                    jsonName = reenvio;
                                }
                                break;
                            case 2: envunit = reenvio;
                                break;
                            case 3: pdft = reenvio;
                                break;
                            case 4: pdfc = reenvio;
                                break;
                            case 5: filecliente = reenvio;
                                break;
                            case 6: filefactura = reenvio;
                                break;

                        }
                    }
                    // llamo clase connect para reenviar
                    if (listaReenvio.Count() > 0)
                    {

                       // conn.sendInvoice(doc, pdft, pdfc, envunit,filecliente,filefactura, "S");

                        // Cambio estado del registro de reenvio 
                        reenv.cambioEstadoReenvio("PROCESADO", jsonName);
                    }
                }
                else
                {
                    log.addLog("ERROR Proceso Contingencia Ping no responde Json:" + jsonName , "ERROR");
                }
            }
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }

        private volatile bool _shouldStop;


        public void StartProcessConting()
        {
            // Create the thread object. This does not start the thread.

            Thread processIatThread = new Thread(procesoContingencia);

            // Start the worker thread.
            processIatThread.Start();
            Console.WriteLine("main thread: Starting ProcessContingencia thread...");

            // Loop until worker thread activates. 
            while (!processIatThread.IsAlive) ;


        }

        public void StopProcessConting()
        {

            RequestStop();

            Console.WriteLine("main thread: ProcessContingencia thread has terminated.");

        }
    }
}
