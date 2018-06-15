using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JmdictFormatter.Parser;
using System.Diagnostics;
using static JmdictFormatter.Parser.JmdictParser;

namespace JmdictFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input the path of the jmdict file: ");
            string xmlpath=Console.ReadLine();
            Console.Write("input the path of the sqlite file: ");
            string dbpath = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(xmlpath)&&!string.IsNullOrWhiteSpace(dbpath))
            {
                JmdictFormatter.Foramtter formatter = new Foramtter(xmlpath,dbpath);
                Console.WriteLine("started");
                formatter.ReadXmlWriteDb();
            }
            Console.WriteLine("finished");
        }
    }
}
