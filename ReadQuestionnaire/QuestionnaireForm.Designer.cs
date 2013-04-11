namespace ReadQuestionnaire
{
    partial class MainContainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.questionTitle = new System.Windows.Forms.Label();
            this.answerBox = new System.Windows.Forms.TextBox();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.characterCount = new System.Windows.Forms.Label();
            this.characterCountLabel = new System.Windows.Forms.Label();
            this.questionHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // questionTitle
            // 
            this.questionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTitle.Location = new System.Drawing.Point(38, 8);
            this.questionTitle.Name = "questionTitle";
            this.questionTitle.Size = new System.Drawing.Size(757, 110);
            this.questionTitle.TabIndex = 0;
            this.questionTitle.Text = "Question";
            this.questionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // answerBox
            // 
            this.answerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerBox.Location = new System.Drawing.Point(38, 140);
            this.answerBox.Multiline = true;
            this.answerBox.Name = "answerBox";
            this.answerBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.answerBox.Size = new System.Drawing.Size(757, 444);
            this.answerBox.TabIndex = 1;
            this.answerBox.TextChanged += new System.EventHandler(this.OnAnswerChanged);
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextQuestionButton.Location = new System.Drawing.Point(321, 599);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(202, 39);
            this.nextQuestionButton.TabIndex = 2;
            this.nextQuestionButton.Text = "Следващ въпрос";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            this.nextQuestionButton.Click += new System.EventHandler(this.OnNextQuestionRequired);
            // 
            // characterCount
            // 
            this.characterCount.AutoSize = true;
            this.characterCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.characterCount.Location = new System.Drawing.Point(548, 108);
            this.characterCount.Name = "characterCount";
            this.characterCount.Size = new System.Drawing.Size(19, 20);
            this.characterCount.TabIndex = 3;
            this.characterCount.Text = "0";
            // 
            // characterCountLabel
            // 
            this.characterCountLabel.AutoSize = true;
            this.characterCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.characterCountLabel.Location = new System.Drawing.Point(268, 108);
            this.characterCountLabel.Name = "characterCountLabel";
            this.characterCountLabel.Size = new System.Drawing.Size(259, 20);
            this.characterCountLabel.TabIndex = 4;
            this.characterCountLabel.Text = "Въведени до момента символи: ";
            // 
            // questionHolder
            // 
            this.questionHolder.Location = new System.Drawing.Point(38, 140);
            this.questionHolder.Name = "questionHolder";
            this.questionHolder.Size = new System.Drawing.Size(757, 444);
            this.questionHolder.TabIndex = 5;
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 651);
            this.Controls.Add(this.questionHolder);
            this.Controls.Add(this.characterCountLabel);
            this.Controls.Add(this.characterCount);
            this.Controls.Add(this.nextQuestionButton);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.questionTitle);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(847, 689);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(847, 689);
            this.Name = "MainContainer";
            this.Text = "Read Questionnaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionTitle;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.Label characterCount;
        private System.Windows.Forms.Label characterCountLabel;
        private System.Windows.Forms.FlowLayoutPanel questionHolder;
    }
}

