using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IatDteBridge
{
    [DataContract]
    class LibroCompra
    {
        //Cabecera
	    [DataMember]
        public String RutEmisorLibro {get;set;}
        [DataMember]
	    public String RutEnvia{get;set;}
        [DataMember]
	    public String PeriodoTributario {get;set;}
        [DataMember]
	    public String FchResol {get;set;}
        [DataMember]
	    public int    NroResol {get;set;}
        [DataMember]
	    public String TipoOperacion {get;set;}
        [DataMember]
	    public String TipoLibro {get;set;}
        [DataMember]
	    public String TipoEnvio {get;set;}
        [DataMember]
        public int  FolioNotificacion{ get; set; }


        // Lista de Totales
        [DataMember]
        public List<Totales_periodo> TotalesPeriodo = new List<Totales_periodo>();


        // Lista de Detalles
        [DataMember]
        public List<Detalle_libro> Detalle = new List<Detalle_libro>();
    }

    [DataContract]
    class Totales_periodo {
        [DataMember]
        public int TpoDoc {get;set;}
        [DataMember]
        public int TotDoc { get; set; }
        [DataMember]
        public int TotMntExe { get; set; }
        [DataMember]
        public int TotMntNeto { get; set; }
        [DataMember]
		public int TotMntIVA {get;set;}
        [DataMember]
		public int TotOpIVAUsoComun {get;set;}
        [DataMember]
		public int TotIVAUsoComun {get;set;}
        [DataMember]
		public float FctProp {get;set;}
        [DataMember]
		public int TotCredIVAUsoComun {get;set;}
        [DataMember]
		public int TotIVAFueraPlazo {get;set;}
        [DataMember]
		public int TotMntTotal {get;set;}

        // Lista TotIVANoRec
        [DataMember]
        public List<TotIVANo_Rec> TotIVANoRec = new List<TotIVANo_Rec>();

        // Lista TotOtrosImp
        [DataMember]
        public List<TotOtros_Imp> TotOtrosImp = new List<TotOtros_Imp>();
    }

    [DataContract]
    class TotIVANo_Rec {
        [DataMember]
        public int CodIVANoRec {get;set;}
        [DataMember]
	    public int TotOpIVANoRec {get;set;}
        [DataMember]
        public int TotMntIVANoRec { get; set; }
	}
    [DataContract]
    class TotOtros_Imp
	{
        [DataMember]
        public int CodImp {get;set;}
        [DataMember]
		public int TotMntImp {get;set;}
    }
	


    [DataContract]
    class Detalle_libro
    {
        [DataMember]
        public int TpoDoc {get;set;}
        [DataMember]
        public int NroDoc {get;set;}
        [DataMember]
		public int TpoImp {get;set;}
        [DataMember]
		public int TasaImp {get;set;}
        [DataMember]
		public String FchDoc {get;set;}
        [DataMember]
		public String RUTDoc {get;set;}
        [DataMember]
		public String RznSoc {get;set;}
        [DataMember]
		public int MntExe {get;set;}
        [DataMember]
		public int MntNeto {get;set;}
        [DataMember]
	    public int IVAUsoComun {get;set;}
        [DataMember]
		public int MntIVA {get;set;}
        [DataMember]
		public int MntTotal {get;set;}

        // Lista OtrosImp
        [DataMember]
        public List<Otros_Imp> OtrosImp = new List<Otros_Imp>();
        
        // lista IVANoRec
        [DataMember]
        public List<IVANo_Rec> IVANoRec = new List<IVANo_Rec>();
    }

    [DataContract]
    class Otros_Imp
    {   
        [DataMember]
        public int CodImp {get;set;}
        [DataMember]
		public int TasaImp {get;set;}
        [DataMember]
		public int MntImp {get;set;}
        
    }

    [DataContract]
    class  IVANo_Rec	
    {
        [DataMember]
        public int CodIVANoRec {get;set;}
        [DataMember]
        public int MntIVANoRec { get; set; }
       
    }
    
}
