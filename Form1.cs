using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TypingStudy
{
    public partial class Main : Form
    {
        //НАСТРОЙКА ПАРАМЕТРОВ
        int scoreLimit = 100; //Кол-во очков до победы
        int timerDelay = 10; //Срабатывание таймера раз в n мс; поставить меньше, если есть разрывы между действиями

        Dict dict = new Dict();
        Dict easy, medium, hard;
        int score = 0;
        Stopwatch timer = new Stopwatch();
        Stopwatch record = new Stopwatch();
        Timer interval;

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblCurrentWord.Text = dict.GetRandomWord();
            tbEnterWord.Enabled = true;
            tbEnterWord.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            groupBox1.Visible = false;
            timer.Start();
            record.Restart();
            interval = new Timer();
            interval.Interval = timerDelay;
            interval.Tick += Interval_Tick;
            interval.Start();
        }

        private void Interval_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Время: " + record.Elapsed.Minutes + ":" + record.Elapsed.Seconds;
            lblScore.Text = "Очки:" + score.ToString();
        }

        #region difficulties
        private void rbEasy_CheckedChanged(object sender, EventArgs e)
        {
            dict = easy;
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            dict = medium;
        }

        private void rbHard_CheckedChanged(object sender, EventArgs e)
        {
            dict = hard;
        }
        #endregion

        private void tbEnterWord_TextChanged(object sender, EventArgs e)
        {
            if (lblCurrentWord.Text.ToLower() == tbEnterWord.Text.ToLower())
            {
                score += lblCurrentWord.Text.Length;
                if (timer.ElapsedMilliseconds < 10000)
                {
                    score += Convert.ToInt32((10000 - timer.ElapsedMilliseconds) / 1000);
                }
                lblCurrentWord.Text = dict.GetRandomWord();
                tbEnterWord.Text = string.Empty;
                timer.Restart();
                if (score >= scoreLimit)
                {
                    lblScore.Text = "Очки:" + score.ToString();
                    lblCurrentWord.Text = "Игра окончена!";
                    groupBox1.Visible = true;
                    score = 0;
                    record.Stop();
                    interval.Dispose();
                }
            }
        }

        public Main()
        {
            InitializeComponent();
            lblScore.Text = "Очки: " + score.ToString();
            try
            {
                if (File.Exists("easy.txt"))
                {
                    easy = new Dict("easy.txt");
                    dict = easy;
                }
                else throw new IOException("Не удалось загрузить \"легкий\" словарь", 1);
                if (File.Exists("medium.txt"))
                {
                    medium = new Dict("medium.txt");
                }
                else throw new IOException("Не удалось загрузить \"средний\" словарь", 2);
                if (File.Exists("hard.txt"))
                {
                    hard = new Dict("hard.txt");
                }
                else throw new IOException("Не удалось загрузить \"сложный\" словарь", 3);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Не удалось один или несколько словарей. Проверьте их расположение в папке программы");
                if (ex.HResult == 1) { rbEasy.Enabled = false; rbEasy.Checked = false; }
                if (ex.HResult == 2) rbMedium.Enabled = false;
                if (ex.HResult == 3) rbHard.Enabled = false;
            }
        }

        private void btnOpenCustomDict_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.ShowDialog();
                try
                {
                    dict.AddWords(ofd.FileName);
                    rbCustom.Text = ofd.FileName.Remove(0, ofd.FileName.LastIndexOf('\\') + 1);
                    rbCustom.Enabled = true;
                    rbCustom.Checked = true;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
