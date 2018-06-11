using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2wf
{
    public class Senteces
    {
        public static List<string> GetSentences(string data)
        {
            List<string> sentences = new List<string>();
            string currentSentence = string.Empty;
            foreach (char ch in data)
                if (ch != '!' && ch != '?' && ch != '.')
                {
                    currentSentence += ch;
                }

                else
                {
                    currentSentence += ch;
                    sentences.Add(currentSentence);
                    currentSentence = string.Empty;
                }

            return sentences;
        }

        public static bool IsQpestion(string sentence)
        {
            return sentence.ElementAt(sentence.Length - 1) == '?' ? true : false;
        }
    }
}
