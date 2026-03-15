using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace File_Handling
{
    internal class FileHandler
    {
        public void StoreDataInFile(FileStream fsd, string line)
        {           
            using (StreamWriter sw = new StreamWriter(fsd))
            {
                sw.WriteLine(line);
            }            
        }
        public string RetriveDataInFile(FileStream fsd)
        {
            string? line = null;
            using (StreamReader sw = new StreamReader(fsd))
            {
                line = sw.ReadToEnd();
            }
            return line;
        }
        public void StoreBinaryDataInFile(FileStream fsd, string s, int val, float fval)
        {
            using (BinaryWriter bw = new BinaryWriter(fsd))
            {
                if (s != null)
                    bw.Write(s);
                bw.Write(val);
                bw.Write(fval);
            }
        }
        public string RetirveBinaryDataInFile(FileStream fsd)
        {
            string? s = null;
            int val = 0;
            float fval = 0;
            using (BinaryReader br = new BinaryReader(fsd))
            {
                s = br.ReadString();
                val = br.ReadInt32();
                fval = br.ReadSingle();
            }
            return $"Retrived File Data:\nString: {s}\nInteger: {val}\nFloat: {fval}";
        }
    }
}
