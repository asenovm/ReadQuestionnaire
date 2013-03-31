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
            this.SuspendLayout();
            // 
            // questionTitle
            // 
            this.questionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTitle.Location = new System.Drawing.Point(33, 32);
            this.questionTitle.Name = "questionTitle";
            this.questionTitle.Size = new System.Drawing.Size(716, 101);
            this.questionTitle.TabIndex = 0;
            this.questionTitle.Text = "Question";
            this.questionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // answerBox
            // 
            this.answerBox.Location = new System.Drawing.Point(38, 115);
            this.answerBox.Multiline = true;
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(711, 317);
            this.answerBox.TabIndex = 1;
            this.answerBox.Text = "Моля отговорете на въпроса с не по-малко от 1000 символа";
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextQuestionButton.Location = new System.Drawing.Point(306, 461);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(202, 39);
            this.nextQuestionButton.TabIndex = 2;
            this.nextQuestionButton.Text = "Следващ въпрос";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            this.nextQuestionButton.Click += new System.EventHandler(this.OnNextQuestionRequired);
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 512);
            this.Controls.Add(this.nextQuestionButton);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.questionTitle);
            this.Name = "MainContainer";
            this.Text = "Read Questionnaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionTitle;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.Button nextQuestionButton;
    }
}

