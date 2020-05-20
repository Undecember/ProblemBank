using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProblemClass
{
    public class Problems
    {
        [Serializable]
        public class ProblemTree
        {
            public string path = "";
            public List<ProblemTree> children = new List<ProblemTree>();
        }

        ProblemTree problemTree = new ProblemTree();

        public Problems()
        {
            if (!(new FileInfo("data")).Exists) return;

            IFormatter readFormatter = new BinaryFormatter();
            Stream readStream = new FileStream("data", FileMode.Open, FileAccess.Read, FileShare.Read);
            this.problemTree = (ProblemTree)readFormatter.Deserialize(readStream);
            readStream.Close();
        }

        ~Problems()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("data", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.problemTree);
            stream.Close();
        }
    }
}
