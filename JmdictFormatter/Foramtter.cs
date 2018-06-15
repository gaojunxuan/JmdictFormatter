using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.IO;
using SQLite;
using JmdictFormatter.Models.JmdictModels;
using JmdictFormatter.Parser;
using System.Diagnostics;
using static JmdictFormatter.Models.JmdictModels.JmDict;

namespace JmdictFormatter
{
    public class Foramtter
    {
        public SQLiteConnection DbConn { get; set; }
        string DbPath { get; set; }
        string XmlPath { get; set; }
        public Foramtter(string xmlpath,string dbpath)
        {
            DbConn = new SQLiteConnection($"{dbpath}");
            DbPath = dbpath;
            XmlPath = xmlpath;
        }
        public void ReadXmlWriteDb()
        {
            var parser=JmdictParser.LoadXml(XmlPath);
            DbConn.CreateTable<Sense>();
            DbConn.CreateTable<REle>();
            DbConn.CreateTable<KEle>();
            for(int i=0;i< parser.Entries.Count();i++)
            {
                var entry = parser.GetEntry(i);
                var senses = JmdictParser.SenseParser.LoadSensesFromEntry(entry);
                var kele = JmdictParser.KEleParser.LoadKEleFromEntry(entry);
                var rele = JmdictParser.REleParser.LoadREleFromEntry(entry);
                foreach(var s in senses.Senses)
                {
                    var ants = senses.GetAntFromCurrentSense(s);
                    StringBuilder sb_ant = new StringBuilder();
                    int count_a = 0;
                    foreach (var a in ants)
                    {
                        count_a += 1;
                        sb_ant.Append(a);
                        if(count_a<ants.Count)
                        {
                            sb_ant.Append(", ");
                        }
                    }
                    var pos = senses.GetPosFromCurrentSense(s);
                    StringBuilder sb_pos = new StringBuilder();
                    int count_p = 0;
                    foreach (var p in pos)
                    {
                        count_p += 1;
                        sb_pos.Append(p);
                        if (count_p < pos.Count)
                        {
                            sb_pos.Append(", ");
                        }
                    }
                    var dialect = senses.GetDialectFromCurrentSense(s);
                    StringBuilder sb_dialect = new StringBuilder();
                    int count_d = 0;
                    foreach (var d in dialect)
                    {
                        count_d += 1;
                        sb_dialect.Append(d);
                        if (count_d < dialect.Count)
                        {
                            sb_dialect.Append(", ");
                        }
                    }
                    var misc = senses.GetMiscFromCurrentSense(s);
                    StringBuilder sb_misc = new StringBuilder();
                    int count_m = 0;
                    foreach (var m in misc)
                    {
                        count_m += 1;
                        sb_misc.Append(m);
                        if (count_m < misc.Count)
                        {
                            sb_misc.Append(", ");
                        }
                    }
                    var stagk = senses.GetStagkFromCurrentSense(s);
                    StringBuilder sb_stagk = new StringBuilder();
                    int count_sk = 0;
                    foreach (var sk in stagk)
                    {
                        count_sk += 1;
                        sb_stagk.Append(sk);
                        if (count_sk < stagk.Count)
                        {
                            sb_stagk.Append(", ");
                        }
                    }
                    var stagr = senses.GetStagrFromCurrentSense(s);
                    StringBuilder sb_stagr = new StringBuilder();
                    int count_sr = 0;
                    foreach (var sr in stagr)
                    {
                        count_sr += 1;
                        sb_stagr.Append(sr);
                        if (count_sr < stagr.Count)
                        {
                            sb_stagr.Append(", ");
                        }
                    }
                    var xref = senses.GetXrefFromCurrentSense(s);
                    StringBuilder sb_xref = new StringBuilder();
                    int count_x = 0;
                    foreach (var x in xref)
                    {
                        count_x += 1;
                        sb_xref.Append(x);
                        if (count_x < xref.Count)
                        {
                            sb_xref.Append(", ");
                        }
                    }
                    var field = senses.GetFieldFromCurrentSense(s);
                    StringBuilder sb_field = new StringBuilder();
                    int count_f = 0;
                    foreach (var f in field)
                    {
                        count_f += 1;
                        sb_field.Append(f);
                        if (count_f < field.Count)
                        {
                            sb_field.Append(", ");
                        }
                    }
                    var gloss = senses.GetGlossFromCurrentSense(s);
                    StringBuilder sb_gloss = new StringBuilder();
                    int count_g = 0;
                    foreach (var g in gloss)
                    {
                        count_g += 1;
                        sb_gloss.Append(g);
                        if (count_g < gloss.Count)
                        {
                            sb_gloss.Append(", ");
                        }
                    }
                    DbConn.Insert(new Sense() { Ant = sb_ant.ToString(), Dialect = sb_dialect.ToString(), EntryId = i, Field = sb_field.ToString(), Gloss = sb_gloss.ToString(), Misc = sb_misc.ToString(), Pos = sb_pos.ToString(), Stagk = sb_stagk.ToString(), Stagr = sb_stagr.ToString(), Xref = sb_xref.ToString() });
                    //todo
                }
                foreach (var k in kele.KEle)
                {
                    var kinf = kele.GetKebInfo(k);
                    StringBuilder sb_kinf = new StringBuilder();
                    int count_ki = 0;
                    foreach(var ki in kinf)
                    {
                        count_ki += 1;
                        sb_kinf.Append(ki);
                        if (count_ki < kinf.Count)
                        {
                            sb_kinf.Append(", ");
                        }
                    }

                    var keb = kele.GetKebs(k);
                    StringBuilder sb_keb = new StringBuilder();
                    int count_ke = 0;
                    foreach (var ke in keb)
                    {
                        count_ke += 1;
                        sb_keb.Append(ke);
                        if (count_ke < keb.Count)
                        {
                            sb_keb.Append(", ");
                        }
                    }
                    DbConn.Insert(new KEle() { EntryId = i, Keb = sb_keb.ToString(), KeInf = sb_kinf.ToString() });
                    //todo
                }
                foreach(var r in rele.REle)
                {
                    var rinf = rele.GetRebInfo(r);
                    StringBuilder sb_rinf = new StringBuilder();
                    int count_ri = 0;
                    foreach (var ri in rinf)
                    {
                        count_ri += 1;
                        sb_rinf.Append(ri);
                        if (count_ri < rinf.Count)
                        {
                            sb_rinf.Append(", ");
                        }
                    }

                    var reb = rele.GetRebs(r);
                    StringBuilder sb_reb = new StringBuilder();
                    int count_re = 0;
                    foreach (var re in reb)
                    {
                        count_re += 1;
                        sb_reb.Append(re);
                        if (count_re < reb.Count)
                        {
                            sb_reb.Append(", ");
                        }
                    }

                    var restr = rele.GetReStr(r);
                    StringBuilder sb_restr = new StringBuilder();
                    int count_rs = 0;
                    foreach (var rs in restr)
                    {
                        count_rs += 1;
                        sb_restr.Append(rs);
                        if (count_rs < restr.Count)
                        {
                            sb_restr.Append(", ");
                        }
                    }
                    DbConn.Insert(new REle() { EntryId = i, NoKanji = rele.NoKanji, Reb = sb_reb.ToString(), ReInf = sb_rinf.ToString(), ReStr = sb_restr.ToString() });
                    //todo
                }
            }
            
        }
    }
}
