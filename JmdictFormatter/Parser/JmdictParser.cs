using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace JmdictFormatter.Parser
{
    public class JmdictParser
    {
        public XDocument Document { get; set; }
        public IEnumerable<XElement> Entries { get; set; }
        public static JmdictParser LoadXml(string path)
        {
            return new JmdictParser() { Document = XDocument.Load(path),Entries=XDocument.Load(path).Descendants("entry") };
        }
        #region Entry
        public XElement GetEntry(int index)
        {
            var entries = Document.Descendants("entry");
            return entries.ElementAt(index);
        }
        #region Rele
        public class REleParser
        {
            public IEnumerable<XElement> REle { get; set; }
            public bool NoKanji { get { return REle.Descendants("re_nokanji").Count() == 1; } }
            public static REleParser LoadREleFromEntry(XElement entry)
            {
                return new REleParser() { REle = entry.Descendants("r_ele") };
            }
            public IList<string> GetRebs(XElement rele)
            {
                IList<string> rebs = new List<string>();
                foreach (var r in rele.Descendants("reb"))
                {
                    rebs.Add(r.Value);
                }
                return rebs;
            }
            public IList<string> GetRebInfo(XElement rele)
            {
                IList<string> rebinf = new List<string>();
                foreach (var r in rele.Descendants("re_inf"))
                {
                    rebinf.Add(r.Value);
                }
                return rebinf;
            }
            public IList<string> GetReStr(XElement rele)
            {
                IList<string> restr = new List<string>();
                foreach (var r in rele.Descendants("re_restr"))
                {
                    restr.Add(r.Value);
                }
                return restr;
            }
        }

        #endregion
        #region Kele
        public class KEleParser
        {
            public IEnumerable<XElement> KEle { get; set; }
            public static KEleParser LoadKEleFromEntry(XElement entry)
            {
                return new KEleParser() { KEle = entry.Descendants("k_ele") };
            }
            public IList<string> GetKebs(XElement kele)
            {
                IList<string> kebs = new List<string>();
                foreach (var k in kele.Descendants("keb"))
                {
                    kebs.Add(k.Value);
                }
                return kebs;
            }
            public IList<string> GetKebInfo(XElement kele)
            {
                IList<string> kebinf = new List<string>();
                foreach (var k in kele.Descendants("ke_inf"))
                {
                    kebinf.Add(k.Value);
                }
                return kebinf;
            }
        }
        #endregion
        #region Sense
        public class SenseParser
        {
            public IEnumerable<XElement> Senses { get; set; }
            public int Count { get { return Senses.Count(); } }
            public static SenseParser LoadSensesFromEntry(XElement entry)
            {
                return new SenseParser() { Senses = entry.Descendants("sense") };
            }
            #region Ant
            public IList<string> GetAntFromCurrentSense(XElement sense)
            {
                IList<string> ant = new List<string>();
                foreach (var a in sense.Descendants("ant"))
                {
                    ant.Add(a.Value);
                }
                return ant;
            }
            #endregion

            #region Pos
            public IList<string> GetPosFromCurrentSense(XElement sense)
            {
                IList<string> pos = new List<string>();
                foreach(var p in sense.Descendants("pos"))
                {
                    pos.Add(p.Value);
                }
                return pos;
            }
            #endregion

            #region Gloss
            public IList<string> GetGlossFromCurrentSense(XElement sense)
            {
                IList<string> gloss = new List<string>();
                foreach (var g in sense.Descendants("gloss"))
                {
                    gloss.Add(g.Value);
                }
                return gloss;
            }
            #endregion

            #region Dialect
            public IList<string> GetDialectFromCurrentSense(XElement sense)
            {
                IList<string> dial = new List<string>();
                foreach (var d in sense.Descendants("dial"))
                {
                    dial.Add(d.Value);
                }
                return dial;
            }
            #endregion

            #region Misc
            public IList<string> GetMiscFromCurrentSense(XElement sense)
            {
                IList<string> misc = new List<string>();
                foreach (var m in sense.Descendants("misc"))
                {
                    misc.Add(m.Value);
                }
                return misc;
            }
            #endregion

            #region Stagk
            public IList<string> GetStagkFromCurrentSense(XElement sense)
            {
                IList<string> stagk = new List<string>();
                foreach (var s in sense.Descendants("stagk"))
                {
                    stagk.Add(s.Value);
                }
                return stagk;
            }
            #endregion

            #region Stagr
            public IList<string> GetStagrFromCurrentSense(XElement sense)
            {
                IList<string> stagr = new List<string>();
                foreach (var s in sense.Descendants("stagr"))
                {
                    stagr.Add(s.Value);
                }
                return stagr;
            }
            #endregion

            #region Xref
            public IList<string> GetXrefFromCurrentSense(XElement sense)
            {
                IList<string> xref = new List<string>();
                foreach (var r in sense.Descendants("xref"))
                {
                    xref.Add(r.Value);
                }
                return xref;
            }
            #endregion

            #region Field
            public IList<string> GetFieldFromCurrentSense(XElement sense)
            {
                IList<string> field = new List<string>();
                foreach (var f in sense.Descendants("field"))
                {
                    field.Add(f.Value);
                }
                return field;
            }
            #endregion
            #endregion
        }
        #endregion
    }
}
