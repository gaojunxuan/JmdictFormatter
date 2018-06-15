using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UpdateImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SQLiteConnection(Console.ReadLine());
            var target = new SQLiteConnection(Console.ReadLine());
            var table = connection.Table<Update>();
            target.CreateTable<UpdateDict>();
            int b = 0;
            int ba = 91129;
            int bb = 0;
            if (target.Table<UpdateDict>().LastOrDefault() != null)
            {
                ba = target.Table<UpdateDict>().Last().AutoId + 1;
                bb = target.Table<UpdateDict>().Last().ID + 1;
            }
            foreach (var i in table)
            {
                string def = "";
                if(!string.IsNullOrEmpty(i.English))
                {
                    def = "\n" + i.English + "\n" + i.Explanation;
                    target.Insert(new UpdateDict() { ID = bb, AutoId = ba + b, JpChar = i.Kanji, Reading = i.Kana, Defination = def });
                }
                else
                {
                    if (i.Kanji == i.Kana)
                        def = "\n" + i.Pos.Replace(", ", " ") + " " + i.Explanation;
                    else
                        def = i.Kana + "\n\n" + i.Kanji + "\n" + i.Pos.Replace(", ", " ") + " " + i.Explanation;
                    target.Insert(new UpdateDict() { ID = bb, AutoId = ba + b, JpChar = i.Kanji, Reading = i.Kana, Defination =  def});
                }
                b++;
            }
            foreach (var i in table)
            {
                if (string.IsNullOrEmpty(i.English))
                {
                    if (i.Kana != i.Kanji)
                        target.Insert(new UpdateDict() { ID = b, AutoId = ba + b, JpChar = i.Kana, Reading = "", Defination = "\n" + i.Kanji + "\n" + i.Pos.Replace(", ", " ") + " " + i.Explanation });
                }
                b++;
            }
        }
    }
}
