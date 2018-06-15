using MiscExtractor.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiscExtractor.Models.JmdictModels.JmDict;

namespace MiscExtractor
{
    class Extractor
    {
        public SQLiteConnection Connection { get; set; }
        public SQLiteConnection TargetConnection { get; set; }
        public void Load(string path,string target)
        {
            Connection = new SQLiteConnection(path);
            TargetConnection = new SQLiteConnection(target);
        }
        public void ExtractMisc(string misc)
        {
            if(Connection!=null&&TargetConnection!=null)
            {
                var miscitems=Connection.Table<Sense>().Where(q=>q.Misc.Contains(misc));
                foreach(var m in miscitems)
                {
                    var kanjiitems = Connection.Table<KEle>().Where(k => k.EntryId == m.EntryId);
                    var reitems = Connection.Table<REle>().Where(r => (r.EntryId == m.EntryId));
                    foreach(var k in kanjiitems)
                    {
                        TargetConnection.CreateTable<MiscDict>();
                        TargetConnection.Insert(new MiscDict() { Kanji = k.Keb, Reading = reitems.First().Reb, Explanation = m.Gloss,SeeMore=m.Xref,Pos=m.Pos });
                    }
                }
            }
        }
        public void ExtractPos(string pos)
        {
            if (Connection != null && TargetConnection != null)
            {
                var miscitems = Connection.Table<Sense>().Where(q => q.Pos.Contains(pos));
                foreach (var m in miscitems)
                {
                    var kanjiitems = Connection.Table<KEle>().Where(k => k.EntryId == m.EntryId);
                    var reitems = Connection.Table<REle>().Where(r => (r.EntryId == m.EntryId));
                    foreach (var k in kanjiitems)
                    {
                        TargetConnection.CreateTable<MiscDict>();
                        TargetConnection.Insert(new MiscDict() { Kanji = k.Keb, Reading = reitems.First().Reb, Explanation = m.Gloss, SeeMore = m.Xref, Pos = m.Pos });
                    }
                }
            }
        }
    }
}
