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
        double score = 0;
        Stopwatch timer = new Stopwatch();
        Stopwatch record = new Stopwatch();
        Timer interval = new Timer();
        bool isRoundStarted = false;
        private string currentWord;
        enum Difficulties { Easy, Medium, Hard }
        Difficulties difficulty;
        Records leaderboard = Records.GetObject();
        UserArguments userArguments;

        public Main(UserArguments authArgs)
        {
            leaderboard.LoadLeaderboard();
            InitializeComponent();
            difficulty = Difficulties.Easy;
            userArguments = authArgs;
            Text = "Пользователь " + authArgs.Username;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRoundStarted)
            {
                isRoundStarted = true;
                btnStart.Text = "Стоп";
                currentWord = dict.GetRandomWord();
                lblCurrentWord.Text = currentWord;
                tbEnterWord.Enabled = true;
                tbEnterWord.Focus();
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
                groupBox1.Visible = false;
                timer.Start();
                record.Restart();
                interval.Interval = timerDelay;
                interval.Tick += Interval_Tick;
                interval.Start();
            }
            else
            {
                //TODO: логика остановки
                isRoundStarted = false;
                btnStart.Text = "Начать";
            }
        }

        private void Interval_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Время: " + record.ElapsedMilliseconds / 1000 + "." + record.ElapsedMilliseconds % 100;
            lblScore.Text = "Очки:" + score.ToString();
        }

        #region difficulties
        private void rbEasy_CheckedChanged(object sender, EventArgs e)
        {
            dict = easy;
            difficulty = Difficulties.Easy;
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            dict = medium;
            difficulty = Difficulties.Medium;
        }

        private void rbHard_CheckedChanged(object sender, EventArgs e)
        {
            dict = hard;
            difficulty = Difficulties.Hard;
        }
        #endregion

        private void tbEnterWord_TextChanged(object sender, EventArgs e)
        {
            if (currentWord.ToUpper() == tbEnterWord.Text.ToUpper())
            {
                score += currentWord.Length;
                if (timer.ElapsedMilliseconds < 10000)
                {
                    switch (difficulty)
                    {
                        case Difficulties.Easy:
                            score += Convert.ToDouble((10000 - timer.ElapsedMilliseconds) / 1000);
                            break;
                        case Difficulties.Medium:
                            score += Convert.ToDouble(((10000 - timer.ElapsedMilliseconds) / 1000) * 1.25);
                            break;
                        case Difficulties.Hard:
                            score += Convert.ToDouble(((10000 - timer.ElapsedMilliseconds) / 1000) * 1.5);
                            break;
                    }
                }
                currentWord = dict.GetRandomWord();
                lblCurrentWord.Text = currentWord;
                tbEnterWord.Text = string.Empty;
                timer.Restart();
                if (score >= scoreLimit)
                {
                    lblScore.Text = "Очки:" + score.ToString();
                    lblCurrentWord.Text = "Игра окончена!";
                    groupBox1.Visible = true;
                    try
                    {
                        leaderboard.AddRecord(new UserArguments(userArguments.Username, record.ElapsedMilliseconds));
                        leaderboard.SaveLeaderboard();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    score = 0;
                    record.Stop();
                    interval.Dispose();
                    tbEnterWord.Enabled = false;
                }
            }
        }

        private void btnOpenCustomDict_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.txt | *.txt";
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

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
