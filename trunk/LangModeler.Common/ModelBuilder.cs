using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace LangModeler.Common
{
    class ModelBuilder
    {
        public void LookThroughSentences(string text, Language lang)
        {
            var newSent = text;
            while (newSent.Equals(""))
            {
                var currSent = GrabSentence(text);
                newSent = DeleteFirstSentence(currSent, text);
                Analise(currSent, lang);
            }
        }

        private string DeleteFirstSentence(string sent, string text)
        {
            var i = 0;
            while (sent[i] == text[i])
            {
                text.Remove(i);
                i++;
            }
            return text;
        }

        private string GrabSentence(string text)
        {
            var output = "";
            var i = 0;
            while (text[i] != '.')
            {
                output = output.Insert(i, text[i].ToString());
            }
            return output;
        }

        private List<GrammarModelView> BuildWordArray(string sent, Language lang)
        {
            List<GrammarModelView> output = new List<GrammarModelView>();
            var temp = "";
            for (var i = 0; i < sent.Length; i++)
            {
                if (sent[i] == ' ')
                {
                    var grammarModel = new GrammarModelView(temp, lang);
                    output.Add(grammarModel);
                    temp = "";
                    i++;
                }
                else
                { 
                    temp = temp.Insert(i, sent[i].ToString());
                    i++;
                }
               
            }
            return output;
        }

        private void Analise(string input, Language lang)
        {
            var wordArray = BuildWordArray(input, lang);
        }
    }
}
