
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateImporter
{
    public class Update
    {
        public string Kanji { get; set; }
        public string Kana { get; set; }
        public string Explanation { get; set; }
        public string Pos { get; set; }
        public string English { get; set; }
    }
    public class UpdateDict
    {
        public int ID { get; set; }
        public int AutoId { get; set; }
        public string JpChar { get; set; }
        public string Reading { get; set; }
        public string Defination { get; set; }
        public string Comment { get; set; }
        public string Category { get; set; }
    }
}
