using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2wf
{
    class Presenter
    {
        private readonly ILogic logic;
        private readonly IMainForm view;
        public Presenter(ILogic logic, IMainForm view)
        {
            this.logic = logic;
            this.view = view;

            view.SelectFileClick += View_SelectFileClick;
            view.Check += View_Check;
        }

        private void View_Sort2(object sender, EventArgs e)
        {
            string filePath = view.FilePath;
            string allText = logic.GetContent(filePath);
            string viewSort2 = logic.Task22(allText);
            view.Task22 = viewSort2;
        }

        private void View_Sort(object sender, EventArgs e)
        {
            string filePath = view.FilePath;
            string allText = logic.GetContent(filePath);
            string viewSort = logic.Task22OrderByCount(allText);
            view.Task22 = viewSort;
        }

        private void View_Check(object sender, EventArgs e)
        {
            string filePath = view.FilePath;
            string allText = logic.GetContent(filePath);
            view.AllText = allText;

            string correctedText = logic.GetCorrectedText(allText);
            view.CorrectedText = correctedText;


            string task1 = logic.Task1(correctedText);
            view.Task1 = task1;

            int numTask2 = view.ValueTask2;
            string task2 = logic.Task2(correctedText, numTask2);
            view.Task2 = task2;
            view.ContentTask2 = correctedText;

            int numTask3 = view.ValueTask3;
            string task3 = logic.Task3(correctedText, numTask3);
            view.Task3 = task3;

            string replaceBy = view.ReplaceBy;
            int numLenghtWords = view.ValueLenghtWord4;
            int numStringTask4 = view.ValueStringTask4;
            string task4 = logic.Task4(correctedText, replaceBy, numStringTask4, numLenghtWords);
            view.Task4 = task4;
        }

        private void View_SelectFileClick(object sender, EventArgs e)
        {
            string filePath = view.FilePath;
            string allText = logic.GetContent(filePath);
            view.AllText = allText;

            string correctedText = logic.GetCorrectedText(allText);
            view.CorrectedText = correctedText;


            string task1 = logic.Task1(correctedText);
            view.Task1 = task1;

            int numTask2 = view.ValueTask2;
            string task2 = logic.Task2(correctedText, numTask2);
            view.Task2 = task2;
            view.ContentTask2 = correctedText;

            int numTask3 = view.ValueTask3;
            string task3 = logic.Task3(correctedText, numTask3);
            view.Task3 = task3;

            string replaceBy = view.ReplaceBy;
            int numLenghtWords = view.ValueLenghtWord4;
            int numStringTask4 = view.ValueStringTask4;
            string task4 = logic.Task4(correctedText, replaceBy, numStringTask4, numLenghtWords);
            view.Task4 = task4;


            string task22 = logic.Task22(correctedText);
            view.Task22 = task22;

            string task22c = logic.Task22OrderByCount(correctedText);
            view.ContentTask22 = task22c;
        }
    }
}
