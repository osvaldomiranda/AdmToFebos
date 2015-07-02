using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using PrinterClassDll;



namespace IatDteBridge
{
    class ThermalPrinter
    {
        public void printTest()
        {
            try
            {
                Win32Print thermalPrinter = new Win32Print();

               thermalPrinter.SetPrinterName("BIXOLON SAMSUNG RP-350");

                thermalPrinter.SetDeviceFont(9.5f, "FontA1x1", false, true);
                thermalPrinter.PrintText("IMPRIMIENDO desde IAT DteBridge");
                thermalPrinter.PrintImage("Timbre.bmp");
                thermalPrinter.EndDoc();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error de Impresora :" + e);
            }
        }
        	
    }
}
