using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace laba2wf
{
    public interface ILogic
    {
        string GetContent(string filePath);
        string GetCorrectedText(string data);
        Sentence[] GetSentences(string data);
        List<string> GetQustionSentence(string sentence);
        string Task1(string data);
        string Task2(string data, int value);
        string Task3(string data, int value);
        string Task4(string data, string replaceby, int valuenumstring, int valuelenghtword);
        string Task22(string data);
        string Task22OrderByCount(string data);

    }
    public class Logic: ILogic
    {
        public string GetContent(string filePath)
        {
            string content = File.ReadAllText(filePath);
            return content;
        }

        public string GetCorrectedText(string data)
        {
            data = Regex.Replace(data, @"\s+", " ");
            data = Regex.Replace(data, @"(^\s)|(\s$)", "");
            return data;
        }

        public List<string> GetQustionSentence(string data)
        {
            List<string> questionsentence = new List<string>();
            List<string> sentences = new List<string>();
            sentences = Senteces.GetSentences(data);
            foreach (var sentence in sentences)
            {
                if(Senteces.IsQpestion(sentence))
                {
                    questionsentence.Add(sentence);
                }
            }

            return questionsentence;
        }

        public Sentence[] GetSentences(string data)//заполняем массив вордс каунт 
        {
            List<string> sentences = new List<string>();
            sentences = Senteces.GetSentences(data);

            List<int> wordsCount = new List<int>();
            wordsCount = Words.GetWordsCount(data);

            Sentence[] sentence = new Sentence[sentences.Count];

            for (int i = 0; i<sentences.Count;i++ ) 
            {
                sentence[i].Text = sentences[i];
                sentence[i].WordsCount = wordsCount[i];
            }
            return sentence;
        }

        public string Task1(string data)
        {
            string content = string.Empty;
            Sentence[] sentences;
            sentences = GetSentences(data);

            sentences.OrderBy(x => x.WordsCount);
            foreach (var sentence in sentences)
                content += (sentence.Text + " ");
            return content;
        }

        public string Task2(string data,int value)
        {
            List<string> words = new List<string>();
            List<string> questionsentence = new List<string>();
            questionsentence = GetQustionSentence(data);
            string answer= string.Empty;
            foreach (var sentence in questionsentence)
            {
                words = Words.GetWords(sentence);
                foreach (var word in words)
                {
                    if (word.Length == value&&!answer.Contains(word))
                    {
                        answer += word;
                        answer += "\r\n";
                    }

                }
            }
            return answer;
        }
        public string Task3(string data,int value)
        {
            List<string> sentences = new List<string>();
            List<string> words = new List<string>();
            List<string> delwords = new List<string>();
            sentences = Senteces.GetSentences(data);
            foreach (var sentence in sentences)
            {
                words = Words.GetWords(sentence);
                foreach (var word in words)
                {
                    if (Words.IsConsonant(word) && word.Length == value)
                        delwords.Add(word);
                }
            }
            string answer = string.Empty;
            foreach (var sentence in sentences)
            {
                string s = sentence;
                foreach (var delword in delwords)
                {
                    if (sentence.Contains(delword))
                    {
                        s = Regex.Replace(sentence, delword, "");

                    }
                    
                }
                answer += s; 
            }
            return answer;
        }
        public string Task4(string data, string replaceby, int valuenumstring, int valuelenghtword)
        {
            string answer = data;
            if (valuelenghtword != 0)
            {
                answer = string.Empty;
                List<string> sentences = new List<string>();
                sentences = Senteces.GetSentences(data);
                
                string sentence = sentences.ElementAt(valuenumstring);
                List<string> words = new List<string>();
                words = Words.GetWords(sentence);
                foreach (var word in words)
                {
                    if (word.Length == valuelenghtword)
                    {
                        sentence = Regex.Replace(sentence, word, replaceby);
                        sentences[valuenumstring] = sentences.ElementAt(valuenumstring).Replace(sentences.ElementAt(valuenumstring), sentence);
                    }

                }
                foreach (var sent in sentences)
                {
                    answer += sent;
                }
            }

            return answer;
        }


        //public string Sort(string data)
        //{
        //    string content = string.Empty;
        //    Sort[] sorting;
        //    sorting = GetWordsAZ(data);
        //    sorting.OrderBy(x => x.SorterAZ);
        //    foreach (var sort in sorting)
        //        content += (sort.SorterAZ + " ");
        //    return content;
        //}
        public string Task22(string data)
        {

            string content = string.Empty;
            Word[] sorting;
           
            sorting = Words.GetWordsAZ(data);
            sorting.OrderBy(x => x.Text);
            List<Word> sortedList = sorting.OrderBy(x => x.Text).ToList();
            List<char> alfavitText = new List<char>();
            bool flag = true;

            for (int i = 0; i < sorting.Count(); i++)
            {
                if(!alfavitText.Contains(char.ToUpper(sortedList[i].Text.ElementAt(0))))
                {
                    flag = true;
                }
                if (flag=true&& !alfavitText.Contains(char.ToUpper(sortedList[i].Text.ElementAt(0))))
                {
                    content += "\r\n";
                    alfavitText.Add(char.ToUpper(sortedList[i].Text.ElementAt(0)));
                    content += char.ToUpper(sortedList[i].Text.ElementAt(0));
                    content += "\r\n";
                    content += "\r\n";
                    flag = false;
                }
                content += sortedList[i].Text;
                content += "\r\t\r\t";
                content += sortedList[i].CountString;
                content += " \r\t\r\t ";
                content += sortedList[i].NumberOfSentence;
                content += "\r\n";
            }
            foreach (var sort in sortedList)
            {
                if (alfavitText.Contains(sort.Text[0]))
                {
                    alfavitText.Add(char.ToUpper(sort.Text[0]));
                }
                
            }
            /*
            foreach (var sort in sortedList)
            {
                
                content += sort.Text;
                content += "\r\t\r\t";
                content += sort.CountString;
                content += " \r\t\r\t ";
                content += sort.NumberOfSentence;
                content += "\r\n";
            }*/
            return content;
        }
        public string Task22OrderByCount(string data)
        {
            string content = string.Empty;
            Word[] sorting;
            sorting = Words.GetWordsAZ(data);
            sorting.OrderBy(x => x.CountString).ToList();
            List<Word> sortedList = sorting.OrderBy(x => x.CountString).ToList();
            //foreach (var sort in sortedList)
            //{
            //    content += sort.Text;
            //    content += "\r\t\r\t";
            //    content += sort.CountString;
            //    content += " \r\t\r\t ";
            //    content += sort.NumberOfSentence;
            //    content += "\r\n";
            //}
            for (int i = sortedList.Count-1; i >0 ; i--)
            {
                content += sortedList[i].Text;
                content += "\r\t\r\t";
                content += sortedList[i].CountString;
                content += " \r\t\r\t ";
                content += sortedList[i].NumberOfSentence;
                content += "\r\n";
            }
            return content;
        }
       
    }
}