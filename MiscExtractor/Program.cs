using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input the path of the sqlite file: ");
            string xmlpath = Console.ReadLine();
            Console.Write("input the path of the target sqlite file: ");
            string dbpath = Console.ReadLine();
            Console.Write("input the pos you want to extract:");
            string misc = Console.ReadLine();
            Extractor extractor = new Extractor();
            extractor.Load(xmlpath, dbpath);
            extractor.ExtractPos(misc);
        }
    }
}
