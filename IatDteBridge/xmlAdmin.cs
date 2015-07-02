using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO;



namespace IatDteBridge
{
    class xmlAdmin
    {

        public String doc_to_xmlSii(Documento doc, String TED, String fch)
        {

            String dte = "<DTE version=\"1.0\">\n" +
                      "<Documento ID=\"F" + doc.Folio + "T" + doc.TipoDTE + "\">\n";

            String tipodespacho = "<TipoDespacho>" + doc.TipoDespacho + "</TipoDespacho>\n";
            if (doc.TipoDespacho == 0)
                tipodespacho = "";

            String indtraslado = "<IndTraslado>" + doc.IndTraslado + "</IndTraslado>\n";
            if (doc.IndTraslado == 0)
                indtraslado = "";

            String encabezado = "<Encabezado>\n" +
                "<IdDoc> \n" +
                    "<TipoDTE>" + doc.TipoDTE + "</TipoDTE>\n" +
                    "<Folio>" + doc.Folio + "</Folio> \n" +
                    "<FchEmis>" + doc.FchEmis + "</FchEmis>\n" +
                    tipodespacho +
                    indtraslado +
                "</IdDoc>\n";



            String emisor = "<Emisor>\n" +
                    "<RUTEmisor>" + doc.RUTEmisor + "</RUTEmisor>\n" +
                    "<RznSoc>" + doc.RznSoc + "</RznSoc>\n" +
                    "<GiroEmis>" + doc.GiroEmis + "</GiroEmis>\n" +
                    "<Acteco>" + doc.Acteco + "</Acteco>\n" +
                    "<CdgSIISucur>" + doc.CdgSIISucur + "</CdgSIISucur>\n" +
                    "<DirOrigen>" + doc.DirOrigen + "</DirOrigen>\n" +
                    "<CmnaOrigen>" + doc.CmnaOrigen + "</CmnaOrigen>\n" +
                    "<CiudadOrigen>" + doc.CiudadOrigen + "</CiudadOrigen>\n" +
                    "</Emisor>\n";



            String receptor = "<Receptor>\n" +
                    "<RUTRecep>" + doc.RUTRecep + "</RUTRecep>\n" +
                    "<RznSocRecep>" + doc.RznSocRecep + "</RznSocRecep>\n" +
                    "<GiroRecep>" + doc.GiroRecep + "</GiroRecep>\n" +
                    "<DirRecep>" + doc.DirRecep + "</DirRecep>\n" +
                    "<CmnaRecep>" + doc.CmnaRecep + "</CmnaRecep>\n" +
                    "<CiudadRecep>" + doc.CiudadRecep + "</CiudadRecep>\n" +
                "</Receptor>\n";

            String impreten = String.Empty;
            string impretenes = String.Empty;



            foreach (var imp in doc.imptoReten)
            {

                impreten = "<ImptoReten>\n" +
                "<TipoImp>" + imp.TipoImp + "</TipoImp>\n" +
                "<TasaImp>" + imp.TasaImp + "</TasaImp>\n" +
                "<MontoImp>" + imp.MontoImp + "</MontoImp>\n" +
                "</ImptoReten>\n";

                if (imp.TipoImp == "")
                    impreten = "";

                impretenes += impreten;
            }


            String mntneto = "<MntNeto>" + doc.MntNeto + "</MntNeto>\n";
            if (doc.MntNeto == 0)
                mntneto = "";
            String mntexe = "<MntExe>" + doc.MntExe + "</MntExe>\n";
            if (doc.MntExe == 0)
                mntexe = "";
            String tasaiva = "<TasaIVA>" + doc.TasaIVA + "</TasaIVA>\n";
            if (doc.TasaIVA == 0)
                tasaiva = "";
            String iva = "<IVA>" + doc.IVA + "</IVA>\n";
            if (doc.IVA == 0)
                iva = "";

            String totales = "<Totales>\n" +
                     mntneto +
                     mntexe +
                     tasaiva +
                     iva +
                    impretenes +
                     "<MntTotal>" + doc.MntTotal + "</MntTotal>\n" +
                 "</Totales>\n";
            String finencabezado = "</Encabezado>\n";

            //arma encabezado en documento
            String documento = dte + encabezado + emisor + receptor + totales + finencabezado;


            // for para crear detalles y agregarlos al documento
            String detalle;
            String firstNmbItem = String.Empty;
            int i = 0;

            foreach (var det in doc.detalle)
            {
                String indexe = "<IndExe>" + det.IndExe + "</IndExe>\n";
                if (det.IndExe == "0")
                    indexe = "";

                String qtyitem = "<QtyItem>" + det.QtyItem + "</QtyItem>\n";
                if (det.QtyItem == 0)
                    qtyitem = "";

                String unmditem = "<UnmdItem>" + det.UnmdItem + "</UnmdItem>\n";
                if (det.UnmdItem == "")
                    unmditem = "";

                String prcitem = "<PrcItem>" + det.PrcItem + "</PrcItem>\n";
                if (det.PrcItem == 0)
                    prcitem = "";

                //agrego el punto de float

                String conpunto = det.DescuentoPct.ToString("N1");


                String descuentopct = "<DescuentoPct>" + conpunto + "</DescuentoPct>\n";
                if (det.DescuentoPct == 0)
                    descuentopct = "";

                String descuentomonto = "<DescuentoMonto>" + det.DescuentoMonto + "</DescuentoMonto>\n";
                if (det.DescuentoMonto == 0)
                    descuentomonto = "";

                String codimpadic = "<CodImpAdic>" + det.CodImpAdic + "</CodImpAdic>\n";
                if (det.CodImpAdic == "" || det.CodImpAdic == "0")
                    codimpadic = "";

                String nmbItem = det.NmbItem.Replace("&", "&amp;");



                detalle = "<Detalle>\n" +
                "<NroLinDet>" + det.NroLinDet + "</NroLinDet>\n" +
                "<CdgItem>\n" +
                "<TpoCodigo>" + det.TpoCodigo + "</TpoCodigo>\n" +
                "<VlrCodigo>" + det.VlrCodigo + "</VlrCodigo>\n" +
                "</CdgItem>\n" +
                indexe +
                "<NmbItem>" + nmbItem + "</NmbItem>\n" +
                 qtyitem +
                 unmditem +
                 prcitem +
                 descuentopct +
                 descuentomonto +
                 codimpadic +
                "<MontoItem>" + det.MontoItem + "</MontoItem>\n" +
                "</Detalle>\n";

                documento = documento + detalle;
                if (i == 0) firstNmbItem = nmbItem;
                i++;
            }

            // for para crear descuento global y agregarlas al documento

            String descuentoglobal = String.Empty;


            foreach (var desglo in doc.dscRcgGlobal)
            {
                String nrolindr = "<NroLinDR>" + desglo.NroLinDR + "</NroLinDR>\n";
                if (desglo.NroLinDR == 0)
                    nrolindr = "";
                String tpomov = "<TpoMov>" + desglo.TpoMov + "</TpoMov>\n";
                if (desglo.TpoMov == "")
                    tpomov = "";
                String glosadr = "<GlosaDR>" + desglo.GlosaDR + "</GlosaDR>\n";
                if (desglo.GlosaDR == "")
                    glosadr = "";
                String tpovalor = "<TpoValor>" + desglo.TpoValor + "</TpoValor>\n";
                if (desglo.TpoValor == "")
                    tpovalor = "";
                String valordr = "<ValorDR>" + desglo.ValorDR + "</ValorDR>\n";
                if (desglo.ValorDR == 0)
                    valordr = "";

                descuentoglobal = "<DscRcgGlobal>\n" +
                    nrolindr +
                    tpomov +
                    glosadr +
                    tpovalor +
                    valordr +
                    "</DscRcgGlobal>\n";
                if (desglo.NroLinDR == 0)
                    descuentoglobal = "";

                documento = documento + descuentoglobal;
            }


            // for para crear referencias y agregarlas al documento
            String referencia;

            foreach (var refe in doc.Referencia)
            {
                String indglobal = "<IndGlobal>" + refe.IndGlobal + "</IndGlobal>\n";
                if (refe.IndGlobal == 0)
                    indglobal = "";
                String rutotr = "<RUTOtr>" + refe.RUTOtr + "</RUTOtr>\n";
                if (refe.RUTOtr == "")
                    rutotr = "";
                String codref = "<CodRef>" + refe.CodRef + "</CodRef>\n";
                if (refe.CodRef == 0)
                    codref = "";

                referencia = "<Referencia>\n" +
                  "<NroLinRef>" + refe.NroLinRef + "</NroLinRef>\n" +
                  "<TpoDocRef>" + refe.TpoDocRef + "</TpoDocRef>\n" +
                  indglobal +
                  "<FolioRef>" + refe.FolioRef + "</FolioRef>\n" +
                   rutotr +
                    // "<IdAdicOtr>" + refe.IdAdicOtr +  "</IdAdicOtr> \n" +
                  "<FchRef>" + refe.FchRef + "</FchRef>\n" +
                    codref +
                  "<RazonRef>" + refe.RazonRef + "</RazonRef>\n" +
                "</Referencia>\n";
                if (refe.NroLinRef == 0)

                    referencia = "";

                documento = documento + referencia;
            }


            String fechaFirma = "<TmstFirma>" + fch + "</TmstFirma>\r\n";
            String findocumenro = "</Documento>\r\n";

            String findte = "</DTE>\r\n";



            documento = documento + TED + fechaFirma + findocumenro + findte;

            X509Certificate2 cert = FuncionesComunes.obtenerCertificado(doc.NombreCertificado);



            String signDte = firmarDocumento(documento, cert);

            Log log = new Log();
            log.addLog("XML generado y firmado TipoDTE :" + doc.TipoDTE + " Folio :" + doc.Folio, "OK");
            return signDte;
        }


        public String ted_to_xmlSii(Documento doc,String fch)
        {


            String firstNmbItem = String.Empty;

            int i = 0;

            foreach (var det in doc.detalle)
            {
                if (i == 0) firstNmbItem = det.NmbItem;
                i++;
            }


            String inicioTed = "<TED version=\"1.0\">\r\n";

            // nodo DD
            String ampersan = firstNmbItem.Replace("&", "&amp;");
            String rznsocrecep = doc.RznSocRecep.Substring(0, 39);

            if (ampersan.Length > 40)
            {
                ampersan = ampersan.Substring(0, 39);
            }

            if (rznsocrecep.Length > 40)
            {
                rznsocrecep = rznsocrecep.Substring(0, 39);
            }

            String dd = "<DD>" +
                    "<RE>" + doc.RUTEmisor + "</RE>" +
                    "<TD>" + doc.TipoDTE + "</TD>" +
                    "<F>" + doc.Folio + "</F>" +
                    "<FE>" + doc.FchEmis + "</FE>" +
                    "<RR>" + doc.RUTRecep + "</RR>" +
                    "<RSR>" + rznsocrecep + "</RSR>" +
                    "<MNT>" + doc.MntTotal + "</MNT>" +

                    "<IT1>" + ampersan +"</IT1>" +

                    getXmlFolio("CAF", doc.TipoDTE) +

                    "<TSTED>" + fch + "</TSTED>" +
                "</DD>";

            String firma = "<FRMT algoritmo=\"SHA1withRSA\">" + firmaNodoDD(dd, doc.TipoDTE) + "</FRMT>\r\n";
            String finTed = "</TED>\r\n";

            String ted =  inicioTed + dd + firma + finTed;

         
            return ted;

        }



        public String creaEnvio(String dte, String rutEmisor, String RutReceptor, String tipo)
        {
            Documento doc = new Documento();

            String envio_xml = "<EnvioDTE xmlns=\"http://www.sii.cl/SiiDte\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.sii.cl/SiiDte EnvioDTE_v10.xsd\" version=\"1.0\">\r\n";
            envio_xml += "<SetDTE ID=\"SetDoc\">\r\n";
            envio_xml += "<Caratula version=\"1.0\">\r\n";
            envio_xml += "<RutEmisor>" + rutEmisor + "</RutEmisor>\r\n";
            //TO DO: Rutenvia, obtener desde certificado
            envio_xml += "<RutEnvia>" + doc.RutEnvia + "</RutEnvia>\r\n";

            //TO DO: rut receptor SII
            envio_xml += "<RutReceptor>60803000-K</RutReceptor>\r\n";

            //TO DO: cambiar fecha de resolución
            envio_xml += "<FchResol>" + doc.FchResol + "</FchResol>\r\n";
            envio_xml += "<NroResol>80</NroResol>\r\n";
            //***********************

            envio_xml += "<TmstFirmaEnv>2014-10-22T22:25:00</TmstFirmaEnv>\r\n";
            envio_xml += "<SubTotDTE>\r\n";
            envio_xml += "<TpoDTE>" + tipo + "</TpoDTE>\r\n";
            envio_xml += "<NroDTE>1</NroDTE>\r\n";
            envio_xml += "</SubTotDTE>\r\n";
            envio_xml += "</Caratula>\r\n";

            envio_xml += dte;


            envio_xml += "</SetDTE>\r\n";
            envio_xml += "</EnvioDTE>\r\n";

            return envio_xml;

        }


        public String firmaNodoDD(String DD, int tipo)
        {


            string pk = getXmlFolio("RSA", tipo);

            Encoding ByteConverter = Encoding.GetEncoding("ISO-8859-1");

            byte[] bytesStrDD = ByteConverter.GetBytes(DD);
            byte[] HashValue = new SHA1CryptoServiceProvider().ComputeHash(bytesStrDD);

            RSACryptoServiceProvider rsa = FuncionesComunes.crearRsaDesdePEM(pk);
          
            byte[] bytesSing = rsa.SignHash(HashValue, "SHA1");
    
            
            string FRMT1 = Convert.ToBase64String(bytesSing);

            return FRMT1;

        }


        public String getXmlFolio(String nodo, int tipo)
        {

            string nodoValue = string.Empty;

            string caf = string.Empty;
            string rsa = string.Empty;
            string line = string.Empty;
            bool cafline = false;
            bool rsaline = false;
            /*   Documento docu = new Documento();
               int tipo = Convert.ToInt32(docu.TipoDTE);
               string xmlCaf = String.Empty;*/

            try
            {
                fileAdmin file = new fileAdmin();
                String cafDir = String.Empty;
                switch (tipo)
                {
                    case 33: cafDir = @"C:\IatFiles\cafs\factura\";

                        break;
                    case 61: cafDir = @"C:\IatFiles\cafs\notacredito\";
                        break;
                    case 56: cafDir = @"C:\IatFiles\cafs\notadebito\";
                        break;
                    case 52: cafDir = @"C:\IatFiles\cafs\Guia\";
                        break;
                    case 34: cafDir = @"C:\IatFiles\cafs\facturaexenta\";
                        break;
                }

               String xmlCaf = file.nextFile(cafDir, "*.xml");
           

                using (StreamReader sr = new StreamReader(xmlCaf)) 
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "<CAF version=\"1.0\">") cafline = true;
                        if (line == "</CAF>")
                        {
                            caf += line;
                            cafline = false;
                        }

                        if (line == "<RSASK>-----BEGIN RSA PRIVATE KEY-----")
                        {
                            rsaline = true;
                            line = sr.ReadLine();
                        }
                        if (line == "-----END RSA PRIVATE KEY-----") rsaline = false;

                        if (cafline) caf += line;
                        if (rsaline) rsa += line;
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            if (nodo == "CAF") { nodoValue = caf; } else { nodoValue = rsa; }

            System.Console.WriteLine(nodoValue);

            return nodoValue;
        }



        public static string firmarDocumento(string documento, X509Certificate2 certificado)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            String documento2 = documento;

            doc.LoadXml(documento);
            SignedXml signedXml = new SignedXml(doc);

            signedXml.SigningKey = certificado.PrivateKey;

            Signature XMLSignature = signedXml.Signature;

            Reference reference = new Reference("");

            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            XMLSignature.SignedInfo.AddReference(reference);

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));

            keyInfo.AddClause(new KeyInfoX509Data(certificado));

            XMLSignature.KeyInfo = keyInfo;

            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();

            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            return doc.InnerXml;

        }
    }
}
