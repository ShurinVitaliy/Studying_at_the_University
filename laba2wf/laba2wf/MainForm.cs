using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2wf
{
    public interface IMainForm
    {
        string AllText { get; set; }
        string CorrectedText { get; set; }
        string FilePath { get; set; }
        string Task1 { get; set; }
        string Task2 { get; set; }
        string Task3 { get; set; }
        string ContentTask2 { get; set; }
        int ValueTask2 { get; }       
        int ValueTask3 { get; }
        string Task4 { get; set; }
        string ReplaceBy { get; set; }
        int ValueStringTask4 { get; }
        int ValueLenghtWord4 { get; }
        string ContentTask22 { get; set; }
        string Task22 { get; set; }

        event EventHandler Check;
        event EventHandler SelectFileClick;
        event EventHandler Pnh;
    }
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file*|*.txt|All files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = dlg.FileName;
                SelectFileClick?.Invoke(this, EventArgs.Empty);
            }           
        }

        public string AllText { get => tbContent.Text; set => tbContent.Text = value; }
        public string CorrectedText { get => tbCorrectedContent.Text; set => tbCorrectedContent.Text = value; }
        public string FilePath { get => tbFilePath.Text; set => tbFilePath.Text = value; }
        public string Task1 { get => tbTask1.Text; set => tbTask1.Text = value; }
        public string Task2 { get => tbResultTask2.Text; set => tbResultTask2.Text=value; }
        public int ValueTask2 { get => (int)numTask2.Value; }
        public string ContentTask2 { get => tbContentTask2.Text; set => tbContentTask2.Text=value; }
        public string Task3 { get => tbResultTask3.Text; set => tbResultTask3.Text=value; }
        public int ValueTask3 => (int)numTask3.Value;
        public string ReplaceBy { get => tbReplaceTask4.Text; set => tbReplaceTask4.Text=value; }
        public int ValueStringTask4 => (int)numStringTask4.Value;
        public int ValueLenghtWord4 => (int)numLenghtWordTask4.Value;
        public string Task4 { get => tbResultTask4.Text; set => tbResultTask4.Text=value; }
        public string ContentTask22 { get => tbContentTask22.Text; set => tbContentTask22.Text=value; }
        public string Task22 { get => tbResultTask22.Text; set => tbResultTask22.Text=value; }

        public event EventHandler SelectFileClick;

        private void numTask2_ValueChanged(object sender, EventArgs e)
        {
            Check?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler Check;
        public event EventHandler Pnh;

        private void numTask3_ValueChanged(object sender, EventArgs e)
        {
            Check?.Invoke(this, EventArgs.Empty);
        }

        private void tbReplaceTask4_TextChanged(object sender, EventArgs e)
        {
            Check?.Invoke(this, EventArgs.Empty);
        }

        private void numStringTask4_ValueChanged(object sender, EventArgs e)
        {
            Check?.Invoke(this, EventArgs.Empty);
        }

        private void numLenghtWordTask4_ValueChanged(object sender, EventArgs e)
        {
            Check?.Invoke(this, EventArgs.Empty);
        }

    }
}

