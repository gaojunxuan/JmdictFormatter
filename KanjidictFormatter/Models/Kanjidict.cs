using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjidictFormatter.Models
{
    public class Kanjidict
    {
        public string Kanji { get; set; }
        public string Strokes { get; set; }
        public string Grade { get; set; }
        public string Jlpt { get; set; }
        public string Frequency { get; set; }
        public string OnReading { get; set; }
        public string KunReading { get; set; }
    }
}
