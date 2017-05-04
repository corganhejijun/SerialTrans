using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerialTrans
{
    class Writer
    {
        string fileName = "index.html";
        string outFile = "D:/index.html";
        public void writeFile(string msg)
        {
            StreamReader stream = File.OpenText(fileName);
            string fileStream = stream.ReadToEnd();
            string newText = fileStream.Replace("{{1}}", msg);
            if (File.Exists(outFile))
                File.Delete(outFile);
            File.WriteAllText(outFile, newText);
        }
    }
}
