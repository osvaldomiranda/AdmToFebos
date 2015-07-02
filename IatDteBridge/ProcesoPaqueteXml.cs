using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace IatDteBridge
{
    class ProcesoPaqueteXml
    {
        public void procesoPaqueteXml(String fileJson, String fileXml)
        {

            // inatancia txt_reader
            TxtReader lec = new TxtReader();

            Documento docLectura = new Documento();

            // Ejecuta metodo de txt_reader que llena y obtienen Clase Documento
            docLectura = lec.lectura(fileJson, true, " ");
            // instancia XML_admin
            xmlPaquete xml = new xmlPaquete();

            DateTime thisDay = DateTime.Now;
            String fchName = String.Format("{0:yyyyMMddTHHmmss}", thisDay);
            
   
            String firsRut = String.Empty;
            if (docLectura != null)
            {

                GetTed ted = new GetTed();

                String TimbreElec = ted.getTed(fileXml);

                //Generar PDF                   
                Pdf docpdf = new Pdf();

                String fileNamePDF = @"C:/IatFiles/file/pdf/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + ".pdf";
                docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDF, " ");

                docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDF, " ");


                String fileNamePDFCed = @"C:/IatFiles/file/pdf/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + "CEDIBLE.pdf";
  
                if (docLectura.TipoDTE == 33 || docLectura.TipoDTE == 34)
                {
                    docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDFCed, "CEDIBLE");
                }

                if (docLectura.TipoDTE == 52)
                {
                    docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDFCed, "CEDIBLE CON SU FACTURA");
                }
 
            }


        }

        public void firmaxml(String fileXml)
        {

           

        }
    }
}
