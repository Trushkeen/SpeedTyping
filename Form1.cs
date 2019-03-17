using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TypingStudy
{
    public partial class Main : Form
    {
        Dict dict = new Dict();
        Dict easy, medium, hard;
        int score = 0;
        Stopwatch timer = new Stopwatch();

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblCurrentWord.Text = dict.GetRandomWord();
            tbEnterWord.Enabled = true;
            tbEnterWord.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            groupBox1.Visible = false;
            timer.Start();
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
            if(lblCurrentWord.Text.ToLower() == tbEnterWord.Text.ToLower())
            {
                score += lblCurrentWord.Text.Length;
                if (timer.ElapsedMilliseconds < 10000)
                {
                    score += Convert.ToInt32((10000 - timer.ElapsedMilliseconds)/1000);
                }
                lblScore.Text = "Очки:" + score.ToString();
                lblCurrentWord.Text = dict.GetRandomWord();
                tbEnterWord.Text = string.Empty;
                timer.Restart();
            }
        }

        public Main()
        {
            InitializeComponent();
            lblScore.Text = "Очки: " + score.ToString();
            try
            {
                easy = new Dict("easy.txt");
                dict = easy;
                medium = new Dict("medium.txt");
                hard = new Dict("hard.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить словари");
                rbEasy.Enabled = false;
                rbMedium.Enabled = false;
                rbHard.Enabled = false;
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
