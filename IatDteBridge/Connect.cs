using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using AdmToFebos.cl.febos.cert;
using AdmToFebos.cl.febos.cert1;
using System.Data.Odbc;



namespace IatDteBridge
{
    class Connect
    {

        public User login(String user, String password)
        {
          
            User userFebos = new User();
            UsersService userService = new UsersService();

            try
            {
            
                loginResponseResponse response = new loginResponseResponse();
                response = userService.login(user, password);

                List<loginResponseResponseVariable> data = response.data.ToList();
                foreach (var d in data)
                {
                    if (d.name == "token") { userFebos.token = d.value; }
                    if (d.name == "uid") { userFebos.uid = d.value; }
                }

                return userFebos;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return userFebos;
            }  
        }


        public string sendInvoice(String fileName, User user, String internalId)
        {
            String febosID = String.Empty;
            try
            {
                if (user.token != null)
                {

                    String dataSend = readFile(fileName);
                    IntegracionService integracion = new IntegracionService();
                    uploadTxtDte2ResponseResponse response = integracion.uploadTxtDte2(user.token, user.uid, dataSend, internalId);

                    Console.WriteLine("Respuesta Status " + response.status);
                    Console.WriteLine("Respuesta Error  " + response.error);
                    Console.WriteLine("Respuesta Messs  " + response.message);
                    Console.WriteLine("Respuesta Data   " + response.febosid);
                    febosID = response.febosid;
                    Console.WriteLine("Respuesta        " + response.ToString());
                }
                return febosID;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return "";
            }   
        }

        public String getFolioFiscal(User user, String febosid)
        {
            String folio = String.Empty;
            IntegracionService integracion = new IntegracionService();

            getDteInfoResponseResponse response = integracion.getDteInfo(user.token,user.uid, febosid);
            Console.WriteLine("Respuesta Status " + response.status);
            Console.WriteLine("Respuesta Error  " + response.error);
            Console.WriteLine("Respuesta Messs  " + response.message);
            Console.WriteLine("Respuesta FebosId " + response.febosid);
            Console.WriteLine("Respuesta Data   " + response.data);
            Console.WriteLine("Respuesta        " + response.ToString());

            getDteInfoResponseResponseVariable[] detResponse = response.data;

            foreach (getDteInfoResponseResponseVariable det in detResponse ){
                Console.WriteLine("Respuesta name " + det.name);
                Console.WriteLine("Respuesta value " + det.value);

                if (det.name.ToString() == "Folio")
                {
                    folio = det.value.ToString();
                }
            }

            return folio;
        }

        public String readFile(String fileName)
        {
            StreamReader objReader = new StreamReader(fileName, System.Text.Encoding.Default, true);
            objReader.ToString();
            String data = objReader.ReadToEnd();
            String dataSend = setEncodeString(data);

            return dataSend;
        }

        public String setEncodeString(String data)
        {
            Encoding ByteConverter = Encoding.GetEncoding("ISO-8859-1");
            byte[] bytesData = ByteConverter.GetBytes(data);
            String dataSend = Convert.ToBase64String(bytesData);

            return dataSend;
        }

        public void updFolioAdm(Documento doc, String febosID, String folioFebos)
        {
            String server = "localhost";
            String database = "cotillon";
            String user = "adm";
            string pass = "admsistemas143";
            String stringConn = "DRIVER={MySQL ODBC 3.51 Driver}; SERVER=" + server + "; PORT=3306; DATABASE=" + database + "; USER=" + user + "; PASSWORD=" + pass + "; OPTION=0;";
            OdbcConnection conn = new OdbcConnection(stringConn);

            String updateSql = " update cabezalventas " +
                                " set nro_fiscal= " + folioFebos +", id_febos = '"+ febosID +"' " +
                                " where cod_empresa=1 and cod_sucursal="+ "1" +" and tipo_cargo="+doc.TipoDTE+" and nro_cargo="+ doc.Folio +
                                " and nro_abono=0;";

                                    /*
                #Para notas de credito
                update cabezalventas    
                set nro_abono=2222, id_febos = '335656898sdasdfd546546'
                where cod_empresa=1 and cod_sucursal_abono=1 and tipo_abono=61 and
                nro_abono=1111 and tipodefactura > 0;"
                                    */

            OdbcCommand command = new OdbcCommand(updateSql, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error update adm \n - verifique los datos ingresados", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message + "\n\n" + "*********************StackTrace: \n\n" + ex.StackTrace);
                //Environment.Exit(0);

            }
        }
    }

    class User
    {
        public String token { get; set; }
        public String uid { get; set; } 
    }
}
