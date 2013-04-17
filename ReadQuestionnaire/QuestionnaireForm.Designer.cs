namespace Read
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
            this.questionHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // questionTitle
            // 
            this.questionTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.questionTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTitle.ForeColor = System.Drawing.Color.Black;
            this.questionTitle.Location = new System.Drawing.Point(58, 20);
            this.questionTitle.Name = "questionTitle";
            this.questionTitle.Size = new System.Drawing.Size(825, 93);
            this.questionTitle.TabIndex = 0;
            this.questionTitle.Text = "Question";
            this.questionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // answerBox
            // 
            this.answerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.answerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerBox.Location = new System.Drawing.Point(53, 116);
            this.answerBox.Multiline = true;
            this.answerBox.Name = "answerBox";
            this.answerBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.answerBox.Size = new System.Drawing.Size(825, 300);
            this.answerBox.TabIndex = 1;
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nextQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextQuestionButton.Location = new System.Drawing.Point(369, 479);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(202, 39);
            this.nextQuestionButton.TabIndex = 2;
            this.nextQuestionButton.Text = "Следващ въпрос";
            this.nextQuestionButton.UseVisualStyleBackColor = false;
            this.nextQuestionButton.Click += new System.EventHandler(this.OnNextQuestionRequired);
            // 
            // questionHolder
            // 
            this.questionHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.questionHolder.Location = new System.Drawing.Point(48, 116);
            this.questionHolder.Name = "questionHolder";
            this.questionHolder.Size = new System.Drawing.Size(845, 300);
            this.questionHolder.TabIndex = 5;
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(924, 562);
            this.Controls.Add(this.questionHolder);
            this.Controls.Add(this.nextQuestionButton);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.questionTitle);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(940, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(940, 600);
            this.Name = "MainContainer";
            this.Text = "Read Questionnaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnCloseRequired);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionTitle;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.FlowLayoutPanel questionHolder;
    }
}

