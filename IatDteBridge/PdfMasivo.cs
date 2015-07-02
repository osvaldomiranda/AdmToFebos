using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IatDteBridge
{
    class PdfMasivo
    {

        public void pdfMasivo()
        {
            Documento docLectura = new Documento();
            // inatancia txt_reader
            TxtReader lec = new TxtReader();
            // Ejecuta metodo de txt_reader que llena y obtienen Clase Documento

            docLectura = lec.lectura("",false,"");



            while (docLectura != null)
            {
                String fileNameXML = @"DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_";

                System.Console.WriteLine("Nombre de Archivo leido " + fileNameXML);

                fileAdmin f = new fileAdmin();

                String fileXml = f.fileAprox(fileNameXML, @"C:/IatFiles/file/xml/", "*.xml");

                if (fileXml !=null )
                {
                    ProcesoPaqueteXml procesa = new ProcesoPaqueteXml();
                    procesa.procesoPaqueteXml(@"C:/IatFiles/file/" + docLectura.fileName,  @"C:/IatFiles/file/xml/"+ fileXml);
                }

                f.mvFile(docLectura.fileName, "C:/IatFiles/file/", "C:/IatFiles/fileProcess/");

                docLectura = lec.lectura("", false,"");
            }


            
        }

    }
}
