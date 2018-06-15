using KanjidictFormatter.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KanjidictFormatter
{
    class Formatter
    {
        public class JmdictParser
        {
            public XDocument Document { get; set; }
            public IEnumerable<XElement> Entries { get; set; }
            public SQLiteConnection Connection { get; set; }
            public static JmdictParser LoadXml(string path)
            {
                return new JmdictParser() { Document = XDocument.Load(path), Entries = XDocument.Load(path).Descendants("character") };
            }
            public void LoadSql(string path)
            {
                Connection = new SQLiteConnection(path);
            }
            public XElement GetEntry(int index)
            {
                var entries = Document.Descendants("character");
                return entries.ElementAt(index);
            }
            public void ReadWriteAll()
            {
                if(Connection!=null)
                {
                    //IList<Kanjidict> verbres = new List<Kanjidict>();
                    Connection.CreateTable<Kanjidict>();
                    for (int i = 0; i < Entries.Count(); i++)
                    {
                        var entry = GetEntry(i);
                        string on = "";
                        foreach (var ir in entry.Descendants("reading_meaning").Descendants("rmgroup").Descendants("reading").Where(f => f.FirstAttribute.Value == "ja_on"))
                        {
                            on += ir.Value + ", ";
                        }
                        if(!string.IsNullOrWhiteSpace(on))
                        {
                            on = on.Substring(0, on.Length - 2);
                        }
                        else
                        {
                            on = "-";
                        }
                        string kun = "";
                        foreach (var ik in entry.Descendants("reading_meaning").Descendants("rmgroup").Descendants("reading").Where(f => f.FirstAttribute.Value == "ja_kun"))
                        {
                            kun += ik.Value + ", ";
                        }
                        if (!string.IsNullOrWhiteSpace(kun))
                        {
                            kun = kun.Substring(0, kun.Length - 2);
                        }
                        else
                        {
                            kun = "-";
                        }
                        var grades = entry.Descendants("misc").Descendants("grade");
                        string grade = "";
                        var jlpts = entry.Descendants("misc").Descendants("jlpt");
                        string jlpt = "";
                        var freqs = entry.Descendants("misc").Descendants("freq");
                        string freq = "";
                        var kanjis = entry.Descendants("literal");
                        string kanji = "";
                        var strokes = entry.Descendants("misc").Descendants("stroke_count");
                        string stroke = "";
                        if(grades.Count()!=0)
                        {
                            grade = grades.First().Value;
                        }
                        else
                        {
                            grade = "-";
                        }
                        if(jlpts.Count()!=0)
                        {
                            jlpt = jlpts.First().Value;
                        }
                        else
                        {
                            jlpt = "-";
                        }
                        if(freqs.Count()!=0)
                        {
                            freq = freqs.First().Value;
                        }
                        else
                        {
                            freq = "-";
                        }
                        if(kanjis.Count()!=0)
                        {
                            kanji = kanjis.First().Value;
                        }
                        else
                        {
                            kanji = "-";
                        }
                        if(strokes.Count()!=0)
                        {
                            stroke = strokes.First().Value;
                        }
                        else
                        {
                            stroke = "-";
                        }
                        var kanjidict = new Kanjidict() { Grade = grade, Jlpt = jlpt, Frequency = freq, Kanji = kanji, Strokes = stroke, KunReading = kun, OnReading = on };
                        Connection.Insert(kanjidict);
                    }
                   

                }
            }
        }
    }
}
