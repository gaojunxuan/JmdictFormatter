using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjidictFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input the path of the jmdict file: ");
            string xmlpath = Console.ReadLine();
            Console.Write("input the path of the sqlite file: ");
            string dbpath = Console.ReadLine();
            var fo=Formatter.JmdictParser.LoadXml(xmlpath);
            fo.LoadSql(dbpath);
            fo.ReadWriteAll();
        }
    }
}
