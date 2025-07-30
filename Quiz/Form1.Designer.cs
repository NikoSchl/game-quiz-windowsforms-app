namespace Quiz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            NextQuestion = new Button();
            label1 = new Label();
            Answer1 = new Button();
            Answer2 = new Button();
            Answer3 = new Button();
            Start = new Button();
            nameBox = new TextBox();
            label2 = new Label();
            ShowResult = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            timelabel = new Label();
            AllKnowQuiz = new Button();
            NeuStart = new Button();
            QuestionBefore = new Button();
            CSharp2 = new Button();
            Highscore = new Button();
            label4 = new Label();
            QuizSelection = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // NextQuestion
            // 
            NextQuestion.BackColor = Color.DeepSkyBlue;
            NextQuestion.Cursor = Cursors.Hand;
            NextQuestion.FlatStyle = FlatStyle.Flat;
            NextQuestion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NextQuestion.ForeColor = Color.Black;
            NextQuestion.Location = new Point(270, 430);
            NextQuestion.Name = "NextQuestion";
            NextQuestion.Size = new Size(170, 40);
            NextQuestion.TabIndex = 0;
            NextQuestion.Text = "nächste Frage";
            NextQuestion.UseVisualStyleBackColor = false;
            NextQuestion.Click += NextQuestion_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(80, 93);
            label1.Name = "label1";
            label1.Size = new Size(550, 69);
            label1.TabIndex = 1;
            label1.Text = "Frage";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Answer1
            // 
            Answer1.BackColor = Color.AliceBlue;
            Answer1.Cursor = Cursors.Hand;
            Answer1.FlatAppearance.BorderColor = Color.Black;
            Answer1.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            Answer1.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            Answer1.FlatStyle = FlatStyle.Flat;
            Answer1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Answer1.ForeColor = Color.Black;
            Answer1.Location = new Point(80, 187);
            Answer1.Name = "Answer1";
            Answer1.Size = new Size(550, 51);
            Answer1.TabIndex = 2;
            Answer1.Text = "Antwort 1";
            Answer1.UseVisualStyleBackColor = false;
            Answer1.Click += Answer1_Click;
            // 
            // Answer2
            // 
            Answer2.BackColor = Color.AliceBlue;
            Answer2.Cursor = Cursors.Hand;
            Answer2.FlatAppearance.BorderColor = Color.Black;
            Answer2.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            Answer2.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            Answer2.FlatStyle = FlatStyle.Flat;
            Answer2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Answer2.ForeColor = Color.Black;
            Answer2.Location = new Point(80, 260);
            Answer2.Name = "Answer2";
            Answer2.Size = new Size(550, 51);
            Answer2.TabIndex = 3;
            Answer2.Text = "Antwort 2";
            Answer2.UseVisualStyleBackColor = false;
            Answer2.Click += Answer2_Click;
            // 
            // Answer3
            // 
            Answer3.BackColor = Color.AliceBlue;
            Answer3.Cursor = Cursors.Hand;
            Answer3.FlatAppearance.BorderColor = Color.Black;
            Answer3.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            Answer3.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            Answer3.FlatStyle = FlatStyle.Flat;
            Answer3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Answer3.ForeColor = Color.Black;
            Answer3.Location = new Point(80, 333);
            Answer3.Name = "Answer3";
            Answer3.Size = new Size(550, 51);
            Answer3.TabIndex = 4;
            Answer3.Text = "Antwort 3";
            Answer3.UseVisualStyleBackColor = false;
            Answer3.Click += Answer3_Click;
            // 
            // Start
            // 
            Start.BackColor = Color.DeepSkyBlue;
            Start.Cursor = Cursors.Hand;
            Start.FlatStyle = FlatStyle.Flat;
            Start.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Start.ForeColor = Color.Black;
            Start.Location = new Point(154, 165);
            Start.Name = "Start";
            Start.Size = new Size(170, 126);
            Start.TabIndex = 5;
            Start.Text = "C# Quiz\nGrundwissen\nStarten";
            Start.UseVisualStyleBackColor = false;
            Start.Click += Start_Click;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(154, 29);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(217, 27);
            nameBox.TabIndex = 6;
            nameBox.TextChanged += nameBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(80, 29);
            label2.Name = "label2";
            label2.Size = new Size(68, 28);
            label2.TabIndex = 7;
            label2.Text = "Name:";
            // 
            // ShowResult
            // 
            ShowResult.BackColor = Color.CornflowerBlue;
            ShowResult.Cursor = Cursors.Hand;
            ShowResult.Enabled = false;
            ShowResult.FlatStyle = FlatStyle.Flat;
            ShowResult.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowResult.ForeColor = SystemColors.ControlText;
            ShowResult.Location = new Point(80, 485);
            ShowResult.Name = "ShowResult";
            ShowResult.Size = new Size(170, 40);
            ShowResult.TabIndex = 8;
            ShowResult.Text = "Ergebnis zeigen";
            ShowResult.UseVisualStyleBackColor = false;
            ShowResult.Click += ShowResult_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(437, 29);
            label3.Name = "label3";
            label3.Size = new Size(49, 28);
            label3.TabIndex = 9;
            label3.Text = "Zeit:";
            // 
            // timelabel
            // 
            timelabel.BackColor = SystemColors.Window;
            timelabel.BorderStyle = BorderStyle.FixedSingle;
            timelabel.Location = new Point(491, 29);
            timelabel.Name = "timelabel";
            timelabel.Size = new Size(138, 27);
            timelabel.TabIndex = 10;
            timelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AllKnowQuiz
            // 
            AllKnowQuiz.BackColor = Color.CornflowerBlue;
            AllKnowQuiz.Cursor = Cursors.Hand;
            AllKnowQuiz.FlatStyle = FlatStyle.Flat;
            AllKnowQuiz.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AllKnowQuiz.ForeColor = Color.Black;
            AllKnowQuiz.Location = new Point(356, 165);
            AllKnowQuiz.Name = "AllKnowQuiz";
            AllKnowQuiz.Size = new Size(170, 126);
            AllKnowQuiz.TabIndex = 12;
            AllKnowQuiz.Text = "Allgemeinwissen\nQuiz starten";
            AllKnowQuiz.UseVisualStyleBackColor = false;
            AllKnowQuiz.Click += AllKnowQuiz_Click;
            // 
            // NeuStart
            // 
            NeuStart.BackColor = Color.DarkTurquoise;
            NeuStart.Cursor = Cursors.Hand;
            NeuStart.FlatStyle = FlatStyle.Flat;
            NeuStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NeuStart.Location = new Point(460, 430);
            NeuStart.Name = "NeuStart";
            NeuStart.Size = new Size(170, 40);
            NeuStart.TabIndex = 13;
            NeuStart.Text = "Neustart";
            NeuStart.UseVisualStyleBackColor = false;
            NeuStart.Click += NeuStart_Click;
            // 
            // QuestionBefore
            // 
            QuestionBefore.BackColor = Color.DeepSkyBlue;
            QuestionBefore.Cursor = Cursors.Hand;
            QuestionBefore.FlatStyle = FlatStyle.Flat;
            QuestionBefore.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            QuestionBefore.Location = new Point(80, 430);
            QuestionBefore.Name = "QuestionBefore";
            QuestionBefore.Size = new Size(170, 40);
            QuestionBefore.TabIndex = 14;
            QuestionBefore.Text = "vorherige Frage";
            QuestionBefore.UseVisualStyleBackColor = false;
            QuestionBefore.Click += QuestionBefore_Click;
            // 
            // CSharp2
            // 
            CSharp2.BackColor = Color.DarkTurquoise;
            CSharp2.Cursor = Cursors.Hand;
            CSharp2.FlatStyle = FlatStyle.Flat;
            CSharp2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CSharp2.Location = new Point(154, 322);
            CSharp2.Name = "CSharp2";
            CSharp2.Size = new Size(170, 126);
            CSharp2.TabIndex = 15;
            CSharp2.Text = "C# Quiz\nerweitertes Wissen\nStarten";
            CSharp2.UseVisualStyleBackColor = false;
            CSharp2.Click += CSharp2_Click;
            // 
            // Highscore
            // 
            Highscore.BackColor = Color.CornflowerBlue;
            Highscore.Cursor = Cursors.Hand;
            Highscore.Enabled = false;
            Highscore.FlatStyle = FlatStyle.Flat;
            Highscore.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Highscore.Location = new Point(270, 485);
            Highscore.Name = "Highscore";
            Highscore.Size = new Size(170, 40);
            Highscore.TabIndex = 17;
            Highscore.Text = "Highscore Top Ten";
            Highscore.UseVisualStyleBackColor = false;
            Highscore.Click += Highscore_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(80, 93);
            label4.Name = "label4";
            label4.Size = new Size(550, 377);
            label4.TabIndex = 18;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QuizSelection
            // 
            QuizSelection.BackColor = Color.DarkTurquoise;
            QuizSelection.Cursor = Cursors.Hand;
            QuizSelection.FlatStyle = FlatStyle.Flat;
            QuizSelection.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            QuizSelection.Location = new Point(460, 485);
            QuizSelection.Name = "QuizSelection";
            QuizSelection.Size = new Size(170, 40);
            QuizSelection.TabIndex = 19;
            QuizSelection.Text = "Quizauswahl";
            QuizSelection.UseVisualStyleBackColor = false;
            QuizSelection.Click += QuizSelection_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(707, 565);
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.Background4;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(702, 560);
            Controls.Add(CSharp2);
            Controls.Add(Start);
            Controls.Add(AllKnowQuiz);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(nameBox);
            Controls.Add(label3);
            Controls.Add(timelabel);
            Controls.Add(pictureBox1);
            Controls.Add(QuizSelection);
            Controls.Add(Highscore);
            Controls.Add(QuestionBefore);
            Controls.Add(NeuStart);
            Controls.Add(ShowResult);
            Controls.Add(Answer3);
            Controls.Add(Answer2);
            Controls.Add(Answer1);
            Controls.Add(NextQuestion);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Quiz mit Biss";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button NextQuestion;
        private Label label1;
        private Button Answer1;
        private Button Answer2;
        private Button Answer3;
        private Button Start;
        private TextBox nameBox;
        private Label label2;
        private Button ShowResult;
        private System.Windows.Forms.Timer timer1;
        private Label label3;
        private Label timelabel;
        private Button AllKnowQuiz;
        private Button NeuStart;
        private Button QuestionBefore;
        private Button CSharp2;
        private Button Highscore;
        private Label label4;
        private Button QuizSelection;
        private PictureBox pictureBox1;
    }
}
