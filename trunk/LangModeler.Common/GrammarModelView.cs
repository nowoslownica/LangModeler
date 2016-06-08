using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace LangModeler.Common
{
    class GrammarModelView
    {
        private int Id;

        public Language Lang;

        public string Word;

        public int Root;

        public Case Case;

        public Gender Gender;

        public PartOfSpeech PartOfSpeech;

        public int TypeDec;

        public int TypeConj;

        public Number Number;

        public Person Person;

        private static int _count;

        public GrammarModelView()
        {
            _count = 0;
        }

        public GrammarModelView(string value, Language lang)
        {
            Word = value;
            Id = ++_count;
            Lang = lang;
            FindInfo(value, lang);
        }

        private void FindInfo(string value, Language lang)
        {
            var sql = new SQLite();
            var root = GetRoot(value, lang);
            var k = "root" + lang;
            SQLiteDataReader reader = sql.ShowTable(k);
            for (int i = 0; i < reader.Depth; i++)
            {
                
            }

        }

        private string GetRoot(string value, Language lang)
        {
            
        }
    }
}
