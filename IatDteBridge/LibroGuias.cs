using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace IatDteBridge
{

    [DataContract]
    class LibroGuias
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
	    public String TipoLibro {get;set;}
        [DataMember]
	    public String TipoEnvio {get;set;}
        [DataMember]
	    public int    FolioNotificacion{get;set;}
             

        [DataMember] 
        public List<resumenPeriodo> ResumenPeriodo = new List<resumenPeriodo>();

        [DataMember]
        public List<detalleGuia> Detalle = new List<detalleGuia>();
      
    }

    [DataContract]
    class resumenPeriodo
    {
        [DataMember] 
        public int TotFolAnulado {get;set;}
        [DataMember]
        public int TotGuiaAnulada {get;set;}
        [DataMember]
        public int TotGuiaVenta {get;set;}
        [DataMember]
        public float TotMntGuiaVta {get;set;}
        [DataMember]
        public float TotMntModificado {get;set;}
        
        [DataMember] 
        public List<totTraslado> TotTraslado = new List<totTraslado>();
        
    }

    [DataContract]
    class totTraslado
    {
        [DataMember]
        public int TpoTraslado {get;set;}
        [DataMember]
        public int CantGuia {get;set;}
        [DataMember]
        public float MntGuia {get;set;}
        
    }

    [DataContract]
    class detalleGuia
    {
        [DataMember]
        public int Folio{get;set;}
        [DataMember]
        public int Anulado{get;set;}
        [DataMember]
        public int Operacion{get;set;}
        [DataMember]
        public int TpoOper{get;set;}
        [DataMember]
        public String FchDoc{get;set;}
        [DataMember]
        public String RUTDoc{get;set;}
        [DataMember]
        public String RznSoc{get;set;}
        [DataMember]
        public float MntNeto{get;set;}
        [DataMember]
        public float TasaImp{get;set;}
        [DataMember]
        public float IVA{get;set;}
        [DataMember]
        public float MntTotal{get;set;}
        [DataMember]
        public float MntModificado{get;set;}
        
    }

}
