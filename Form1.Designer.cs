namespace TypingStudy
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbEnterWord = new System.Windows.Forms.TextBox();
            this.lblCurrentWord = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenCustomDict = new System.Windows.Forms.Button();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbEnterWord
            // 
            this.tbEnterWord.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbEnterWord.Enabled = false;
            this.tbEnterWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEnterWord.Location = new System.Drawing.Point(0, 71);
            this.tbEnterWord.Name = "tbEnterWord";
            this.tbEnterWord.Size = new System.Drawing.Size(496, 31);
            this.tbEnterWord.TabIndex = 1;
            this.tbEnterWord.TextChanged += new System.EventHandler(this.tbEnterWord_TextChanged);
            // 
            // lblCurrentWord
            // 
            this.lblCurrentWord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentWord.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentWord.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentWord.Name = "lblCurrentWord";
            this.lblCurrentWord.Size = new System.Drawing.Size(496, 71);
            this.lblCurrentWord.TabIndex = 2;
            this.lblCurrentWord.Text = "Нажмите \"Начать\"";
            this.lblCurrentWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.tbEnterWord);
            this.panel1.Controls.Add(this.lblCurrentWord);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 240);
            this.panel1.TabIndex = 3;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 13);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Время:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(35, 13);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "Очки:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenCustomDict);
            this.groupBox1.Controls.Add(this.rbCustom);
            this.groupBox1.Controls.Add(this.rbHard);
            this.groupBox1.Controls.Add(this.rbMedium);
            this.groupBox1.Controls.Add(this.rbEasy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Уровень сложности";
            // 
            // btnOpenCustomDict
            // 
            this.btnOpenCustomDict.Location = new System.Drawing.Point(169, 86);
            this.btnOpenCustomDict.Name = "btnOpenCustomDict";
            this.btnOpenCustomDict.Size = new System.Drawing.Size(153, 23);
            this.btnOpenCustomDict.TabIndex = 4;
            this.btnOpenCustomDict.Text = "Открыть другой";
            this.btnOpenCustomDict.UseVisualStyleBackColor = true;
            this.btnOpenCustomDict.Click += new System.EventHandler(this.btnOpenCustomDict_Click);
            // 
            // rbCustom
            // 
            this.rbCustom.Enabled = false;
            this.rbCustom.Location = new System.Drawing.Point(12, 86);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(151, 24);
            this.rbCustom.TabIndex = 3;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "Пользовательский";
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(12, 63);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(72, 17);
            this.rbHard.TabIndex = 2;
            this.rbHard.TabStop = true;
            this.rbHard.Text = "Сложный";
            this.rbHard.UseVisualStyleBackColor = true;
            this.rbHard.CheckedChanged += new System.EventHandler(this.rbHard_CheckedChanged);
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.Location = new System.Drawing.Point(12, 40);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(68, 17);
            this.rbMedium.TabIndex = 1;
            this.rbMedium.TabStop = true;
            this.rbMedium.Text = "Средний";
            this.rbMedium.UseVisualStyleBackColor = true;
            this.rbMedium.CheckedChanged += new System.EventHandler(this.rbMedium_CheckedChanged);
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Checked = true;
            this.rbEasy.Location = new System.Drawing.Point(12, 19);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(62, 17);
            this.rbEasy.TabIndex = 0;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "Легкий";
            this.rbEasy.UseVisualStyleBackColor = true;
            this.rbEasy.CheckedChanged += new System.EventHandler(this.rbEasy_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStart.Location = new System.Drawing.Point(0, 102);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(496, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 240);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbEnterWord;
        private System.Windows.Forms.Label lblCurrentWord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenCustomDict;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
    }
}

