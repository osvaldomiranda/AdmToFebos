using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IatDteBridge
{
    class Caf
    {
        public bool isValid(Documento doc)
        {
            bool valid = true;

            String xmlCaf = String.Empty;
            String cafDir = String.Empty;

            fileAdmin file = new fileAdmin();

            string rut = doc.RUTEmisor;

            try
            {
                switch (doc.TipoDTE)
                {
                    case 33: cafDir = @"C:\IatFiles\cafs\" + rut + @"\factura\";
                        break;
                    case 61: cafDir = @"C:\IatFiles\cafs\" + rut + @"\notacredito\";
                        break;
                    case 56: cafDir = @"C:\IatFiles\cafs\" + rut + @"\notadebito\";
                        break;
                    case 52: cafDir = @"C:\IatFiles\cafs\" + rut + @"\Guia\";
                        break;
                    case 34: cafDir = @"C:\IatFiles\cafs\" + rut + @"\facturaexenta\";
                        break;
                }

                xmlCaf = file.nextFile(cafDir, "*.xml");

                String xml = String.Empty;

                if (xmlCaf != null)
                {
                    StreamReader objReader = new StreamReader(xmlCaf, System.Text.Encoding.Default, true);
                    objReader.ToString();
                    xml = objReader.ReadToEnd();
                }


                int start = xml.IndexOf("<TD") + 4;
                int end = xml.IndexOf("</TD>");
                int largo = end - start;

                // Valida tipo de documento
                String td = xml.Substring(start, largo);
                if (td != doc.TipoDTE.ToString()) valid = false;


                start = xml.IndexOf("<FA>") + 4;
                end = xml.IndexOf("</FA>");
                largo = end - start;
                // Valida FECHA de documento
                String fch = xml.Substring(start, largo);

                DateTime fchCaf = DateTime.ParseExact(fch, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

                DateTime fEmis = DateTime.ParseExact(fch, "yyyy-MM-dd",
                       System.Globalization.CultureInfo.InvariantCulture);

                if (fEmis > fchCaf)
                {
                    valid = false;
                }


                start = xml.IndexOf("<D>") + 3;
                end = xml.IndexOf("</D>");
                largo = end - start;
                String d = xml.Substring(start, largo);

                start = xml.IndexOf("<H>") + 3;
                end = xml.IndexOf("</H>");
                largo = end - start;
                String h = xml.Substring(start, largo);


                // Valida Folio del documento dentro del rango CAF 
                int ds = Convert.ToInt32(d);
                int hs = Convert.ToInt32(h);

                // TO DO: Descomentar esta linea para el proceso de producción
            //    if (!((folio < hs) && (folio >ds)) ) valid = false;


                // OTRAS VALIDACIONES
                if (doc.CiudadRecep == null || doc.CiudadRecep == String.Empty ) valid = false;
                if (doc.CmnaRecep == null || doc.CmnaRecep == String.Empty) valid = false;
                

            }
            catch (Exception e)
            {
                Console.WriteLine("The file CAF could not be read:");
                Console.WriteLine(e.Message);
            }


            return valid;
        }
    }
}
