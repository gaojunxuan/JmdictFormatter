using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscExtractor.Models.JmdictModels
{
    public class JmDict
    {
        public class Sense
        {
            public int EntryId { get; set; }
            public string Pos { get; set; }
            public string Ant { get; set; }
            public string Dialect { get; set; }
            public string Misc { get; set; }
            public string Stagk { get; set; }
            public string Stagr { get; set; }
            public string Xref { get; set; }
            public string Field { get; set; }
            public string Gloss { get; set; }
        }
        public class REle
        {
            public int EntryId { get; set; }
            public bool NoKanji { get; set; }
            public string Reb { get; set; }
            public string ReInf { get; set; }
            public string ReStr { get; set; }
        }
        public class KEle
        {
            public int EntryId { get; set; }
            public string Keb { get; set; }
            public string KeInf { get; set; }
        }
    }
}
