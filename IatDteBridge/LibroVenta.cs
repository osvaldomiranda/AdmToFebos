using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IatDteBridge
{

    [DataContract]
    class LibroVenta
    {
        [DataMember]
        public String RutEmisorLibro{get;set;}
        [DataMember]
	    public String RutEnvia {get;set;}
        [DataMember]
	    public String PeriodoTributario{get;set;}
        [DataMember]
	    public String FchResol{get;set;}
        [DataMember]
	    public int    NroResol{get;set;}
        [DataMember]
	    public String TipoOperacion{get;set;}
        [DataMember]
	    public String TipoLibro {get;set;}
        [DataMember]
	    public String TipoEnvio {get;set;}
        [DataMember]
	    public int    NroSegmento{get;set;}
        [DataMember]
	    public int    FolioNotificacion{get;set;}
        [DataMember]
	    public String CodAutRec{get;set;}
             
        [DataMember]
        public List<resumenSeg> ResumenSegmento = new List<resumenSeg>();

        [DataMember]
        public List<totalesPer> TotalesPeriodo = new List<totalesPer>();
	 	     
        [DataMember]
        public List<detalle> Detalle = new List<detalle>();
	 	       
        [DataMember]
        public int MntTotal{get;set;}
        [DataMember]
	    public int IVANoRetenido {get;set;}
        [DataMember]
	    public int MntNoFact {get;set;}
        [DataMember]
	    public int MntPeriodo{get;set;}
        [DataMember]
	    public int PsjNac {get;set;}
        [DataMember]
	    public int PsjInt{get;set;}
        
    }

    [DataContract]
    class resumenSeg
    {
        [DataMember]
        public int TpoDoc{get;set;}
        [DataMember]
        public int TotDoc{get;set;}
        [DataMember] 
        public int TotAnulado{get;set;}
        [DataMember]
        public int TotMntExe{get;set;}
        [DataMember]
        public int TotMntNeto{get;set;}
        [DataMember]
        public int TotMntIVA{get;set;}
        [DataMember]
        public int TotIVAFueraPlazo{get;set;}
        [DataMember]
        public int TotIVAPropio{get;set;}
        [DataMember]
        public int TotIVATerceros{get;set;}
        [DataMember]
        public int TotLey18211{get;set;}
        

        [DataMember]
        public List<totOtrosImp> TotOtrosImp = new List<totOtrosImp>();
        
        [DataMember]
        public int TotOpIVARetTotal{get;set;}
        [DataMember]
        public int TotIVARetTotal{get;set;}
        [DataMember]
        public int TotOpIVARetParcial{get;set;}
        [DataMember]
        public int TotIVARetParcial{get;set;}
        [DataMember]
        public int TotCredEC{get;set;}
        [DataMember]
        public int TotDepEnvase{get;set;}
       
        [DataMember]
        public List<totLiqui> TotLiquidaciones = new List<totLiqui>();
        
        [DataMember]
        public int TotMntTotal{get;set;}
        [DataMember]
        public int TotOpIVANoRetenido{get;set;}
        [DataMember]
        public int TotIVANoRetenido{get;set;}
        [DataMember]
        public int TotMntNoFact{get;set;}
        [DataMember]
        public int TotMntPeriodo{get;set;}
        [DataMember]
        public int TotPsjNac{get;set;}
        [DataMember]
        public int TotPsjInt{get;set;}
        
            
    }

    [DataContract]
    class totOtrosImp
    {
        [DataMember]
        public int   CodImp{get;set;}
        [DataMember]
        public int TotMntImp{get;set;}
        
    }

    [DataContract]
    class totLiqui
    {
        [DataMember]
        public int TotValComNeto{get;set;}
        [DataMember] 
        public int TotValComExe{get;set;}
        [DataMember] 
        public int TotValComIVA{get;set;}
        
    }

    [DataContract]
    class totalesPer
    {
        [DataMember] 
        public int TpoDoc{get;set;}
        [DataMember] 
        public int TotDoc{get;set;}
        [DataMember] 
        public int TotAnulado{get;set;}
        [DataMember] 
        public int TotOpExe{get;set;}
        [DataMember] 
        public int TotMntExe{get;set;}
        [DataMember] 
        public int TotMntNeto{get;set;}
        [DataMember]  
        public int TotMntIVA{get;set;}
        [DataMember] 
        public int TotIVAFueraPlazo{get;set;}
        [DataMember] 
        public int TotIVAPropio{get;set;}
        [DataMember] 
        public int TotIVATerceros{get;set;}
        [DataMember] 
        public int TotLey18211{get;set;}
        
        [DataMember]
        public List<totOtrosImp> TotOtrosImp = new List<totOtrosImp>();
     

        [DataMember] 
        public int TotOpIVARetTotal{get;set;}
        [DataMember] 
        public int TotIVARetTotal{get;set;}
        [DataMember] 
        public int TotOpIVARetParcial{get;set;}
        [DataMember] 
        public int TotIVARetParcial{get;set;}
        [DataMember] 
        public int TotCredEC{get;set;}
        [DataMember] 
        public int TotDepEnvase {get;set;}
    
        [DataMember]
        public List<totLiqui> TotLiquidaciones = new List<totLiqui>();
    
        [DataMember] 
        public int TotMntTotal{get;set;}
        [DataMember] 
        public int TotOpIVANoRetenido{get;set;}
        [DataMember] 
        public int TotIVANoRetenido{get;set;}
        [DataMember] 
        public int TotMntNoFact{get;set;}
        [DataMember] 
        public int TotMntPeriodo{get;set;}
        [DataMember] 
        public int TotPsjNac{get;set;}
        [DataMember] 
        public int TotPsjInt {get;set;}
        
	        
    }

    [DataContract]
    class detalle 
    {
        [DataMember]
        public int   TpoDoc{get;set;}
        [DataMember] 
        public int   Emisor{get;set;}
        [DataMember] 
        public int   NroDoc {get;set;}
        [DataMember] 
        public String Anulado {get;set;}
        [DataMember] 
        public int   Operacion {get;set;}
        [DataMember] 
        public int TasaImp{get;set;}
        [DataMember] 
        public int   NumInt{get;set;}
        [DataMember] 
        public int   IndServicio{get;set;}
        [DataMember] 
        public int   IndSinCosto{get;set;}
        [DataMember] 
        public String FchDoc{get;set;}
        [DataMember] 
        public int CdgSIISucur{get;set;}
        [DataMember] 
        public String RUTDoc{get;set;}
        [DataMember] 
        public String RznSoc{get;set;}
        [DataMember] 
        public String    NumId{get;set;}
        [DataMember] 
        public String Nacionalidad{get;set;}
        [DataMember] 
        public int    TpoDocRef{get;set;}
        [DataMember] 
        public int    FolioDocRef{get;set;}
        [DataMember] 
        public int MntExe{get;set;}
        [DataMember] 
        public int MntNeto{get;set;}
        [DataMember] 
        public int MntIVA{get;set;}
        [DataMember] 
        public int IVAFueraPlazo {get;set;}
        [DataMember] 
        public int IVAPropio{get;set;}
        [DataMember] 
        public int IVATerceros{get;set;}
        [DataMember] 
        public int Ley18211{get;set;}
        
        [DataMember]
        public List<detOtrosImp> OtrosImp = new List<detOtrosImp>();
        
        public int IVARetTotal{get;set;}
        [DataMember] 
        public int IVARetParcial{get;set;}
        [DataMember] 
        public int CredEC{get;set;}
        [DataMember] 
        public int DepEnvase{get;set;}
         
        [DataMember]
        public List<detLiqui> Liquidaciones = new List<detLiqui>();
        
        [DataMember]
        public int MntTotal { get; set; }

	             
    }

    [DataContract]
    class detOtrosImp
    {
        [DataMember] 
        public int CodImp {get;set;}
        [DataMember] 
        public int TasaImp{get;set;}
        [DataMember] 
        public int MntImp{get;set;}
        
    }

    [DataContract]
    class detLiqui
    {
        [DataMember] 
        public String RutEmisor{get;set;}
        [DataMember]  
        public int ValComNeto{get;set;}
        [DataMember]  
        public int ValComExe{get;set;}
        [DataMember]  
        public int ValComIVA{get;set;}
         
    }
}
