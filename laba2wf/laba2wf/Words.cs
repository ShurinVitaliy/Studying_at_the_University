using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laba2wf
{
    public class Words
    {
        public static List<string> GetWords(string sentence)
        {
            List<string> words = new List<string>();
            string currentWord = string.Empty;
            foreach (char ch in sentence)
                if (!Char.IsPunctuation(ch) && !Char.IsSeparator(ch)&&ch!=' ')
                    
                    currentWord += ch;
                else
                {
                    words.Add(currentWord);
                    currentWord = string.Empty;
                }

            return words;
        }

        public static List<int> GetWordsCount(string data)
        {
            List<string> sentences = new List<string>();
            sentences = Senteces.GetSentences(data);

            List<int> wordsCount = new List<int>();

            foreach (var s in sentences)
                wordsCount.Add(GetWords(s).Count);

            return wordsCount;
        }
        public static bool IsConsonant(string word)
        {
            bool isConsonant = Regex.IsMatch(word, "^[a|e|i|o|u]") ? false : true;
            return isConsonant;
        }
        public static List<string> OneWords(string data)
        {
            List<string> sentence = new List<string>();
            sentence = Senteces.GetSentences(data);
            List<string> words = new List<string>();
            List<string> onewords = new List<string>();
            foreach (var sentenc in sentence)
            {
                words = Words.GetWords(sentenc);
                foreach (var word in words)
                {
                    if(!onewords.Contains(word)&&word!=""&&!char.IsDigit(word[0]))
                    { onewords.Add(word); }
                }
            }
            
            return onewords;
        }



        public static List<string> SortWords(string data)
        {
            List<string> onewords = new List<string>();
            onewords = Words.OneWords(data);            
            return onewords;
        }

        public static Word[] GetWordsAZ(string data)
        {
            List<string> wordsOne = new List<string>();
            wordsOne = Words.OneWords(data);
            List<string> sentence = new List<string>();
            sentence = Senteces.GetSentences(data);
            List<string> words = new List<string>();
            bool flag = false;
            Word[] wordvalue = new Word[wordsOne.Count];
            for(int i=0;i<wordsOne.Count;i++)
            {
                wordvalue[i].Text += wordsOne[i];
                for(int j=0;j<sentence.Count;j++)
                {
                    words = Words.GetWords(sentence[j]);
                    for(int k=0;k<words.Count;k++)
                    {
                        if (wordsOne[i]==words[k])
                        {
                            flag = true;
                            wordvalue[i].CountString++;
                        }
                    }
                    if(flag==true)
                    {
                        wordvalue[i].NumberOfSentence += j.ToString();
                        wordvalue[i].NumberOfSentence += " ";
                        flag = false;
                    }
                }
            }
            return wordvalue;
        }
    }
}
