using System;
using System.Linq;
using System.Text;
using System.IO;



namespace IatDteBridge
{
    class GetTed
    {
        public String getTed(String fileName)
        {
            String ted = String.Empty;
            String xml = String.Empty;

            if (fileName != null)
            {
                StreamReader objReader = new StreamReader(fileName, System.Text.Encoding.Default, true);
                objReader.ToString();
                xml = objReader.ReadToEnd();
            }


            int start = xml.IndexOf("<TED");
            int end = xml.IndexOf("</TED>");

            int largo = (end+6) - start;

            ted = xml.Substring(start, largo);


            return ted;
        }
    }
}
