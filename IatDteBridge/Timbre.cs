using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace IatDteBridge
{
    class Timbre
    {
        public void CreaTimbre(String dd)
        {
            BarcodePDF417 pdf417 = new BarcodePDF417();
            pdf417.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            pdf417.ErrorLevel = 8;
           //"<TED version='1.0'><DD><RE>97975000-5</RE><TD>33</TD><F>1</F><FE>2014-05-28</FE><RR>77777777-7</RR><RSR>Pc Factory</RSR><MNT>119000</MNT><IT1>Parlantes Multimedia 180W.</IT1><CAF version='1.0'><DA><RE>10207640-0</RE><RS>JUAN CARLOS AGUIRRE RODRIGUEZ</RS><TD>33</TD><RNG><D>1</D><H>50</H></RNG><FA>2014-05-26</FA><RSAPK><M>uJ+OZ5qO9diB/c9MoZuwPs9ltKGAS1IbEymF7W3X3ZTq6ElExVkrlfp7uDoGR0DiBndor6Vyc+X4MRbsk6KC9w==</M><E>Aw==</E></RSAPK><IDK>100</IDK></DA><FRMA algoritmo='SHA1withRSA'>SGKR9otZoN8/5sIaKFJIbo08Jbt95UBh76fcFv21lfNsgauAcyzUF0FARrMyphMagJ0zzChJzU7R/Q0mrDvYvQ==</FRMA></CAF><TSTED>2014-05-28T09:33:20</TSTED></DD><FRMT algoritmo='SHA1withRSA'>GK7FRnNjgHLyRspdygg2WudvqqJ+OQchn8k/6TUrndBBNHsFHInEN34+KLTy\nFgRG/bmDIjclV4VTlgs3TIg/7A==\n</FRMT></TED>";
          
            pdf417.Options = BarcodePDF417.PDF417_FORCE_BINARY;

            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            byte[] isoBytes = iso.GetBytes(dd);

            pdf417.Text = isoBytes;
            // pdf417.SetText(contenido);

            System.Drawing.Bitmap imagen = new Bitmap(pdf417.CreateDrawingImage(Color.Black, Color.White));
            imagen.Save("Timbre.jpg");
        }
    }
}
