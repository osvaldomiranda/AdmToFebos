using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Data.SQLite;



namespace IatDteBridge
{
    class TxtReader
    {
        String strConn = @"Data Source=C:/IatFiles/iatDB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
       
        public Documento lectura(String fileJson, bool moveFile, String dirOrigen)
        {
            Documento doc = new Documento();
            fileAdmin file = new fileAdmin();
            String fileName = String.Empty;

            if (dirOrigen == "")
            {
                dirOrigen = @"C:\AdmToFebosFiles\files";
            }
            

            if (fileJson == "")
            {
                fileName = file.nextFile(dirOrigen, "*.json");
            }
            else
            {
                fileName = dirOrigen + fileJson;
            }


            if (fileName != null)
            {
                StreamReader objReader = new StreamReader(fileName,System.Text.Encoding.Default,true);
                objReader.ToString();
                String data = objReader.ReadToEnd();
        
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Documento));
                
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

                try
                {
                    doc = (Documento)js.ReadObject(ms);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    MessageBox.Show("Error de lectura JSON"+ e.Message);
                }
  
                // Datos del Emisor
                // Cargo datos en laclase Documento desde sqlite

                if (doc.RUTEmisor == null)
                {
                    try
                    {

                        SQLiteConnection myConn = new SQLiteConnection(strConn);
                        myConn.Open();

                        string sql = "select * from empresa";
                        SQLiteCommand command = new SQLiteCommand(sql, myConn);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            doc.RUTEmisor = reader["RutEmisor"].ToString();
                            doc.RznSoc = reader["RznSoc"].ToString();
                            doc.GiroEmis = reader["GiroEmis"].ToString();
                            doc.Telefono = reader["Telefono"].ToString();
                            doc.CorreoEmisor = reader["CorreoEmisor"].ToString();
                            doc.Acteco = Convert.ToInt32(reader["Acteco"]);
                            doc.CdgSIISucur = Convert.ToInt32(reader["CdgSIISucur"]);
                            doc.DirMatriz = reader["DirMatriz"].ToString();
                            doc.CmnaOrigen = reader["CmnaOrigen"].ToString();
                            doc.CiudadOrigen = reader["CiudadOrigen"].ToString();
                            doc.DirOrigen = reader["DirOrigen"].ToString();
                            doc.NombreCertificado = reader["NomCertificado"].ToString();
                            doc.SucurEmisor = reader["SucurEmisor"].ToString();
                            doc.FchResol = reader["FchResol"].ToString();
                            doc.RutEnvia = reader["RutCertificado"].ToString();
                            doc.NumResol = reader["NumResol"].ToString();
                            doc.CondEntrega = reader["CondEntrega"].ToString();

                        }
                        myConn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: {0}", e.ToString());
                    }
                }
                else
                {
                    try
                    {

                        SQLiteConnection myConn = new SQLiteConnection(strConn);
                        myConn.Open();

                        string sql = "select * from empresa where empresa.RutEmisor = '"+ doc.RUTEmisor.ToString() +"'";
                        SQLiteCommand command = new SQLiteCommand(sql, myConn);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            doc.Telefono = reader["Telefono"].ToString();
                            doc.CorreoEmisor = reader["CorreoEmisor"].ToString();
                            doc.Acteco = Convert.ToInt32(reader["Acteco"]);
                            doc.DirRegionalSII = reader["sucurSII"].ToString();
                            doc.DirMatriz = reader["DirMatriz"].ToString();
                            doc.NombreCertificado = reader["NomCertificado"].ToString();
                            doc.SucurEmisor = reader["SucurEmisor"].ToString();
                            doc.FchResol = reader["FchResol"].ToString();
                            doc.RutEnvia = reader["RutCertificado"].ToString();
                            doc.NumResol = reader["NumResol"].ToString();
                            doc.CondEntrega = reader["CondEntrega"].ToString();
                        }

                        myConn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: {0}", e.ToString());
                    }
               }

                objReader.Close();
                ms.Close();
                if (moveFile)
                {
                    file.mvFile(fileName, dirOrigen, "C:/AdmToFebosFiles/fileProcess/");
                }
                
                Caf caf = new Caf();

                if(!caf.isValid(doc))
                {
                    doc = null;
                }

                if (fileJson == "")
                {
                    doc.fileName = fileName;
                }
                else
                {
                    doc.fileName = fileJson;
                }
                return doc;
            }
            else
            {
                return null;
            }
            


        }

        public string createTxtFbos(Documento doc, String fileName)
        {

            String file = String.Empty;
            file += "            XXX INICIO DOCUMENTO\n";
            file += "========== AREA IDENTIFICACION DEL DOCUMENTO\n";
            file += "Tipo Documento Tributario Electronico            : " + doc.TipoDTE +"\n";
            file += "Folio Documento                                  : " +"\n";
            file += "Fecha de Emision                                 : " + doc.FchEmis + "\n";
            file += "Indicador de No Rebaja                           : " + vacioSiCero(doc.IndNoRebaja.ToString()) + "\n";
            file += "Tipo de despacho                                 : " + vacioSiCero(doc.TipoDespacho.ToString()) + "\n";
            file += "Indicador de traslado                            : " + vacioSiCero(doc.IndTraslado.ToString()) + "\n";
            file += "Tipo Impresion                                   : " + "\n";
            file += "Indicador de servicio                            : " + vacioSiCero(doc.IndServicio.ToString()) + "\n";
            file += "Indicador de Montos Brutos                       : " + "\n";
            file += "Indicador de Montos Netos                        : " + "\n";
            if (doc.TipoDTE == 39)
            {
                file += "Forma de Pago                                    : " + "\n";
            }
            else
            {
                file += "Forma de Pago                                    : " + doc.FmaPago + "\n";
            }

            file += "Forma de Pago Exportacion                        : " + "\n";
            file += "Fecha de Cancelacion                             : " + "\n";
            file += "Monto Cancelado                                  : " + "\n";
            file += "Saldo Insoluto                                   : " + "\n";
            file += "Fecha Monto y Glosa                              :                                                                     " + "\n";
            file += "Fecha Monto y Glosa                              :                                                                     " + "\n";
            file += "Fecha Monto y Glosa                              :                                                                     " + "\n";
            file += "Fecha Monto y Glosa                              :                                                                     " + "\n";
            file += "Periodo Desde                                    : " + "\n";
            file += "Periodo Hasta                                    : " + "\n";
            file += "Medio de Pago                                    : " + "\n";
            file += "Tipo de Cuenta de Pago                           : " + "\n";
            file += "Numero de Cuenta de Pago                         : " + "\n";
            file += "Banco de Pago                                    : " + "\n";
            file += "Codigo Terminos de Pago                          : " + "\n";
            file += "Glosa del Termino de Pago                        : " + "\n";
            file += "Dias del Termino de Pago                         : " + "\n";
            if (doc.TipoDTE == 52)
            {
                file += "Fecha de Vencimiento                             : " + "\n";
            }
            else
            {
                file += "Fecha de Vencimiento                             : " + doc.FchVenc + "\n";
            }
            
            file += "========== AREA EMISOR" + "\n";
            file += "Rut emisor                                       : " + doc.RUTEmisor + "\n";
            file += "Razon Social Emisor                              : " + doc.RznSoc + "\n";
            file += "Giro Emisor                                      : " + doc.GiroEmis + "\n";
            file += "Telefono                                         : " + doc.Telefono + "\n";
            file += "Correo Emisor                                    : " + doc.CorreoEmisor + "\n";
            file += "ACTECO                                           : 151110"+ "\n";
            file += "Codigo Emisor Traslado Excepcional               : " + "\n";
            file += "Folio Autorizacion                               : " + "\n";
            file += "Fecha Autorizacion                               : " + "\n";
            file += "Direccion de origen emisor                       : " + doc.DirOrigen + "\n";
            file += "Comuna de Origen Emisor                          : " + doc.CmnaOrigen + "\n";
            file += "Ciudad de Origen Emisor                          : " + doc.CiudadOrigen + "\n";
            file += "Nombre Sucursal                                  : " + doc.Sucursal + "\n";
            file += "Codigo Sucursal                                  : " + "\n";
            file += "Codigo Adicional Sucursal                        : " + "\n";
            file += "Codigo Vendedor                                  : " + doc.CdgVendedor + "\n";
            file += "Identificador Adicional del Emisor               : " + "\n";
            file += "Rut Mandante                                     : " + doc.RUTMandante + "\n";
            file += "========== AREA RECEPTOR" + "\n";
            if (doc.TipoDTE == 39)
            {
                file += "Rut Receptor                                     : 66666666-6" + "\n";
            }
            else
            {
                file += "Rut Receptor                                     : " + doc.RUTRecep + "\n";
            }

            file += "Codigo interno Receptor                          : " + "\n";
            file += "Nombre o Razon Social Receptor                   : " + doc.RznSocRecep + "\n";
            file += "Numero Identificador Receptor Extranjero         : " + "\n";
            file += "Nacionalidad del Receptor Extranjero             : " + "\n";
            file += "Identificador Adicional Receptor Extranjero      : " + "\n";
            file += "Giro del negocio del receptor                    : " + doc.GiroRecep + "\n";
            file += "Contacto                                         : " + doc.Contacto + "\n";
            file += "Correo Receptor                                  : " + doc.CorreoRecep + "\n";
            file += "Direccion Receptor                               : " + doc.DirRecep + "\n";
            file += "Comuna Receptor                                  : " + doc.CmnaRecep + "\n";
            file += "Ciudad Receptor                                  : " + doc.CiudadRecep + "\n";
            file += "Direccion Postal Receptor                        : " + doc.DirPostal + "\n";
            file += "Comuna Postal Receptor                           : " + doc.CmnaPostal + "\n";
            file += "Ciudad Postal Receptor                           : " + doc.CiudadPostal + "\n";
            file += "Rut Solicitante de Factura                       : " + doc.RUTSolicita + "\n";
            file += "========== AREA TRANSPORTE" + "\n";
            file += "Patente                                          : " + doc.Patente + "\n";
            file += "Rut Transportista                                : " + doc.RUTCiaTransp + "\n";
            file += "Rut Chofer                                       : " + doc.RUTChofer + "\n";
            file += "Nombre Chofer                                    : " + doc.NombreChofer + "\n";
            file += "Direccion Destino                                : " + doc.DirDest + "\n";
            file += "Comuna Destino                                   : " + doc.CmnaDest + "\n";
            file += "Ciudad Destino                                   : " + "\n";
            file += "Modalidad De Ventas                              : " + "\n";
            file += "Clausula de Venta Exportacion                    : " + "\n";
            file += "Total Clausula de Venta Exportacion              : " + "\n";
            file += "Via de Transporte                                : " + "\n";
            file += "Nombre del Medio de Transporte                   : " + "\n";
            file += "RUT Compania de Transporte                       : " + doc.RUTCiaTransp + "\n";
            file += "Nombre Compania de Transporte                    : " + doc.NomCiaTransp + "\n";
            file += "Identificacion Adicional Compania de Transporte  : " + "\n";
            file += "Booking                                          : " + "\n";
            file += "Operador                                         : " + "\n";
            file += "Puerto de Embarque                               : " + "\n";
            file += "Identificador Adicional Puerto de Embarque       : " + "\n";
            file += "Puerto Desembarque                               : " + "\n";
            file += "Identificador Adicional Puerto de Desembarque    : " + "\n";
            file += "Tara                                             : " + vacioSiCero(doc.Tara.ToString()) + "\n";
            file += "Unidad de Medida Tara                            : " + vacioSiCero(doc.CodUnidMedTara.ToString()) + "\n";
            file += "Total Peso Bruto                                 : " + vacioSiCero(doc.PesoBruto.ToString()) + "\n";
            file += "Unidad de Peso Bruto                             : " + vacioSiCero(doc.CodUnidPesoBruto.ToString()) + "\n";
            file += "Total Peso Neto                                  : " + vacioSiCero(doc.PesoNeto.ToString()) + "\n";
            file += "Unidad de Peso Neto                              : " + vacioSiCero(doc.CodUnidPesoNeto.ToString()) + "\n";
            file += "Total Items                                      : " + vacioSiCero(doc.TotItems.ToString()) + "\n";
            file += "Total Bultos                                     : " + vacioSiCero(doc.TotBultos.ToString()) + "\n";
            file += "Informacion de Bultos                            :                                                                                                                                                                                                                                                                                                                                                                                                " + "\n";
            file += "Informacion de Bultos                            :                                                                                                                                                                                                                                                                                                                                                                                                " + "\n";
            file += "Informacion de Bultos                            :                                                                                                                                                                                                                                                                                                                                                                                                " + "\n";
            file += "Informacion de Bultos                            :                                                                                                                                                                                                                                                                                                                                                                                                " + "\n";
            file += "Flete                                            : " + "\n";
            file += "Seguro                                           : " + "\n";
            file += "Codigo Pais Receptor                             : " + "\n";
            file += "Codigo Pais Destino                              : " + "\n";
            file += "========== AREA TOTALES" + "\n";
            file += "Tipo Moneda Transaccion                          : " + doc.TpoMoneda + "\n";
            file += "Monto Neto                                       : " + doc.MntNeto + "\n";
            file += "Monto Exento                                     : " + vacioSiCero(doc.MntExe.ToString()) + "\n";
            file += "Monto Base Faenamiento de Carne                  : " + "\n";
            file += "Monto Base de Margen de  Comercializacion        : " + vacioSiCero(doc.MntMargenCom.ToString()) + "\n";
            file += "Tasa IVA                                         : " + doc.TasaIVA + "\n";
            file += "IVA                                              : " + doc.IVA + "\n";
            file += "Iva Propio                                       : " + vacioSiCero(doc.IVAProp.ToString()) + "\n";
            file += "Iva terceros                                     : " + vacioSiCero(doc.IVATerc.ToString()) + "\n";

            // 6 lineas de impuestos adicionales
     
            for (int i = 0; i < 6 ; i++)
            {
                file += "Codigo Impuesto Adicional y Monto                : " + "\n";
            }

            file += "IVA no Retenido                                  : " + vacioSiCero(doc.IVANoRet.ToString()) + "\n";
            file += "Credito Especial Emp. Constructoras              : " + "\n";
            file += "Garantia Deposito Envases                        : " + "\n";
            file += "Valor Neto Comisiones                            : " + "\n";
            file += "Valor Exento Comisiones                          : " + "\n";
            file += "IVA Comisiones                                   : " + "\n";
            file += "Monto Total                                      : " + doc.MntTotal + "\n";
            file += "Monto No Facturable                              : " + "\n";
            file += "Monto Periodo                                    : " + "\n";
            file += "Saldo Anterior                                   : " + "\n";
            file += "Valor a Pagar                                    : " + "\n";
            file += "========== OTRA MONEDA" + "\n";
            file += "Tipo Moneda                                      : " + "\n";
            file += "Tipo Cambio                                      : " + "\n";
            file += "Monto Neto Otra Moneda                           : " + "\n";
            file += "Monto Exento Otra Moneda                         : " + "\n";
            file += "Monto Base Faenamiento de Carne Otra Moneda      : " + "\n";
            file += "Monto Margen Comerc. Otra Moneda                 : " + "\n";
            file += "IVA Otra Moneda                                  : " + "\n";
            file += "Tipo Imp. Otra Moneda                            : " + "\n";
            file += "Tasa Imp. Otra Moneda                            : " + "\n";
            file += "Valor Imp. Otra Moneda                           : " + "\n";
            file += "IVA No Retenido Otra Moneda                      : " + "\n";
            file += "Monto Total Otra Moneda                          : " + "\n";
            file += "========== DETALLE DE PRODUCTOS Y SERVICIOS" + "\n";

            // 30 lineas de detalle

            foreach (var det in doc.detalle)
            {
                file += lineaDetalle(det) + "\n"; 
            }

            for (int i = 0; i < 30 - doc.detalle.Count(); i++)
            {
                file += "" + "\n";
            }

            file += "========== FIN DETALLE" + "\n";
            file += "========== SUB TOTALES INFORMATIVO" + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "                                                                                                                                        " + "\n";
            file += "========== DESCUENTOS Y RECARGOS" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "========== INFORMACION DE REFERENCIA" + "\n";
            
            // 40 lineas de referencia

            if (doc.TipoDTE != 39)
            {

                foreach (var referencia in doc.Referencia)
                {
                    file += lineaReferencia(referencia) + "\n";
                }

                Console.WriteLine("LINEAS DE REFERENCIA ******************" + doc.Referencia.Count());

                for (int i = 0; i < 40 - doc.Referencia.Count(); i++)
                {
                    file += "                                                                                                                                           " + "\n";
                }
            }
            else
            {
                for (int i = 0; i < 40; i++)
                {
                    file += "                                                                                                                                           " + "\n";
                }

            }

            file += "========== COMISIONES Y OTROS CARGOS" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "" + "\n";
            file += "========== CAMPOS PERSONALIZADOS" + "\n";
            file += "Monto Palabras                                   : " + "\n";
            file += "Condicion Venta                                  : " + "\n";
            file += "OC o GD                                          : " + "\n";
            file += "Vendedor                                         : " + doc.NomVendedor + "\n";
            file += "CodigoSAP                                        : 1" + "\n";
            file += "Observaciones                                    : " + "\n";
            file += "Impresora                                        : 192.168.1.33" + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "                                                 : " + "\n";
            file += "XXX FIN DOCUMENTO" + "\n";

            using (System.IO.StreamWriter fileDisc = new System.IO.StreamWriter(fileName, false, Encoding.GetEncoding("ISO-8859-1")))
            {
                fileDisc.WriteLine(file);
            }

            return file;
        }



        private String vacioSiCero(String valor)
        {
            String vacio = String.Empty;
            if (valor == "0")
            {
                return vacio;
            }

            return valor;
        }
        private String lineaDetalle(Detalle det)
        {
            List<PosLinea> pos = new List<PosLinea>();
            pos = posDetalle();

            String linea = String.Empty;
            String filler;
            int i = 0;
            foreach(var p in pos){
                filler = String.Empty;
                i++;
                if (i == 1) { linea += espacios(p.posicion); }   
                switch (i)
                {
                    case 1: linea += det.TpoCodigo;
                        break;
                    case 2: linea += det.VlrCodigo;
                        break;
                    case 3: linea += det.NmbItem;
                        break;
                    case 4: linea += det.QtyItem;
                        break;
                    case 5: linea += det.PrcItem;
                        break;
                    case 6: linea += det.UnmdItem;
                        break;
                    case 7: linea += vacioSiCero( det.DescuentoPct.ToString());
                        break;
                    case 8: linea += vacioSiCero( det.DescuentoMonto.ToString());
                        break;
                    case 9: linea += det.MontoItem;
                        break;
                    }
                
                int posx = linea.Length;
                filler += espacios(p.siguiente - posx);
                
               // Console.WriteLine(" posicion:" + p.posicion + " siguiente:" + p.siguiente + " linea:" + linea.Length+" filer:"+filler.Length);
               
                linea += filler;
            }
            return linea;
        }

        private String espacios(int cantidad)
        {
            String espacios = String.Empty;
            for(int i=1; i<cantidad; i++){
                espacios+=" ";
            }
            return espacios;
        }

        public List<PosLinea> posDetalle() {

            List<PosLinea> pos = new List<PosLinea>();

         // "NroLinDet": 1, 
         // "TpoCodigo": "PLU", 
            PosLinea pos1 = new PosLinea();
            pos1.posicion = 50;
            pos1.siguiente = 60;
            pos1.largo = 10;
            pos.Add(pos1);

         // "VlrCodigo": 2388, 
            PosLinea pos2 = new PosLinea();
            pos2.posicion = 60;
            pos2.siguiente = 440;
            pos2.largo = 35;
            pos.Add(pos2);

         // "TpoDocLiq": " ",

         // "IndExe": 0, 

         // "NmbItem": "AGUA MINERAL ANDINA C/G VITAL BT 600CC", 
            PosLinea pos5 = new PosLinea();
            pos5.posicion = 440;
            pos5.siguiente = 1560;
            pos5.largo = 80;
            pos.Add(pos5);

         // "QtyItem": 12,
            PosLinea pos6 = new PosLinea();
            pos6.posicion = 1560;
            pos6.siguiente = 1893;
            pos6.largo = 18;
            pos.Add(pos6);

         // "PrcItem": 197.479,
            PosLinea pos7 = new PosLinea();
            pos7.posicion = 1893;
            pos7.siguiente = 1931;
            pos7.largo = 18;
            pos.Add(pos7);
         
         // "UnmdItem": "C/U"
            PosLinea pos8 = new PosLinea();
            pos8.posicion = 1931;
            pos8.siguiente = 2105;
            pos8.largo = 4;
            pos.Add(pos8);

        // "DescuentoPct": 0,
            PosLinea pos9 = new PosLinea();
            pos9.posicion = 2105;
            pos9.siguiente = 2110; 
            pos9.largo = 5;
            pos.Add(pos9);

         // "DescuentoMonto": 0,
            PosLinea pos10 = new PosLinea();
            pos10.posicion = 2110;
            pos10.siguiente = 2353;
            pos10.largo = 18;
            pos.Add(pos10);


         // "MontoItem": 2370},
            PosLinea pos12 = new PosLinea();
            pos12.posicion = 2353;
            pos12.siguiente = 7000;
            pos12.largo = 18;
            pos.Add(pos12);
   
            return pos;
        }

        // *********************************************


        private String lineaReferencia(ReferenciaDoc refe)
        {
            List<PosLinea> pos = new List<PosLinea>();
            pos = posReferencia();

            String linea = String.Empty;
            String filler;
            int i = 0;
            foreach (var p in pos)
            {
                filler = String.Empty;
                i++;
                if (i == 1) { linea += espacios(p.posicion); }
                switch (i)
                {
                    case 1: linea += refe.TpoDocRef;
                        break;
                    case 2: linea += " "; //indicador de globalidad
                        break;
                    case 3: linea += refe.FolioRef;
                        break;
                    case 4: linea += refe.FchRef;
                        break;
                    case 5: linea += refe.CodRef;
                        break;
                    case 6: linea += refe.RazonRef;
                        break;
                  
                }

                int posx = linea.Length;
                filler += espacios(p.siguiente - posx);

                // Console.WriteLine(" posicion:" + p.posicion + " siguiente:" + p.siguiente + " linea:" + linea.Length+" filer:"+filler.Length);

                linea += filler;
            }
            return linea;
        }


        public List<PosLinea> posReferencia()
        {

            List<PosLinea> pos = new List<PosLinea>();
             
            // Tipo de Documento de Referencia 
            PosLinea pos1 = new PosLinea();
            pos1.posicion = 1;
            pos1.siguiente = 4;
            pos1.largo = 3;
            pos.Add(pos1);

            // Indicador de Referencia Global 
            PosLinea pos2 = new PosLinea();
            pos2.posicion = 4;
            pos2.siguiente = 5;
            pos2.largo = 1;
            pos.Add(pos2);

            // FOLIO de Referencia 
            PosLinea pos3 = new PosLinea();
            pos3.posicion = 5;
            pos3.siguiente = 23;
            pos3.largo = 22;
            pos.Add(pos3);

            // FECHA de la Referencia
            PosLinea pos4 = new PosLinea();
            pos4.posicion = 23;
            pos4.siguiente = 33;
            pos4.largo = 32;
            pos.Add(pos4);

            // Código de Referencia
            PosLinea pos5 = new PosLinea();
            pos5.posicion = 33;
            pos5.siguiente = 34;
            pos5.largo = 1;
            pos.Add(pos5);

            // Razón Referencia
            PosLinea pos6 = new PosLinea();
            pos6.posicion = 34;
            pos6.siguiente = 123;
            pos6.largo = 90;
            pos.Add(pos6);

            return pos;
        }
    }

    class PosLinea
    {
        public int posicion {set; get;}
        public int largo { set; get; }
        public int siguiente { set; get; }
    }






}
