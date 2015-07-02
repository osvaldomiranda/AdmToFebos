using System;
using System.IO;
using System.Collections;

namespace IatDteBridge
{
    class File
    {
        public void OpenFile()
        {
            StreamReader objReader = new StreamReader("c://file/test.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText)
                Console.WriteLine(sOutput);
            Console.ReadLine();
        }

        public ArrayList FileToArray()
        {
            StreamReader objReader = new StreamReader("c://file/test.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();
            return arrText;
        }
    }


}

/*


--9022632e1130lc4
Content-Disposition: form-data; name="rutSender"
Content-Type: text/plain; charset=US-ASCII
Content-Transfer-Encoding: 8Bit

05682509
--9022632e1130lc4
Content-Disposition: form-data; name="dvSender"
Content-Type: text/plain; charset=US-ASCII
Content-Transfer-Encoding: 8Bit

6
--9022632e1130lc4
Content-Disposition: form-data; name="ruCompany"
Content-Type: text/plain; charset=US-ASCII
Content-Transfer-Encoding: 8Bit

77398570
--9022632e1130lc4
Content-Disposition: form-data; name="dvCompany"
Content-Type: text/plain; charset=US-ASCII
Content-Transfer-Encoding: 8Bit

7

*/