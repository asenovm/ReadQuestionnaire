namespace Read
{
    partial class PersonalInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalInformationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.majorDropDown = new System.Windows.Forms.ComboBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.femaleRadio = new System.Windows.Forms.RadioButton();
            this.maleRadio = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.majorDropDown);
            this.panel1.Controls.Add(this.nextBtn);
            this.panel1.Controls.Add(this.femaleRadio);
            this.panel1.Controls.Add(this.maleRadio);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ageBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 409);
            this.panel1.TabIndex = 0;
            // 
            // majorDropDown
            // 
            this.majorDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.majorDropDown.FormattingEnabled = true;
            this.majorDropDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.majorDropDown.Items.AddRange(new object[] {
            "Психология",
            "Икономика",
            "Стопанско Управление"});
            this.majorDropDown.Location = new System.Drawing.Point(309, 250);
            this.majorDropDown.Name = "majorDropDown";
            this.majorDropDown.Size = new System.Drawing.Size(177, 21);
            this.majorDropDown.TabIndex = 22;
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.nextBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextBtn.BackgroundImage")));
            this.nextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.nextBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nextBtn.Location = new System.Drawing.Point(278, 337);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(142, 36);
            this.nextBtn.TabIndex = 21;
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.OnNextButtonClicked);
            // 
            // femaleRadio
            // 
            this.femaleRadio.AutoSize = true;
            this.femaleRadio.Location = new System.Drawing.Point(418, 192);
            this.femaleRadio.Name = "femaleRadio";
            this.femaleRadio.Size = new System.Drawing.Size(54, 17);
            this.femaleRadio.TabIndex = 6;
            this.femaleRadio.TabStop = true;
            this.femaleRadio.Text = "Жена";
            this.femaleRadio.UseVisualStyleBackColor = true;
            // 
            // maleRadio
            // 
            this.maleRadio.AutoSize = true;
            this.maleRadio.Location = new System.Drawing.Point(323, 192);
            this.maleRadio.Name = "maleRadio";
            this.maleRadio.Size = new System.Drawing.Size(49, 17);
            this.maleRadio.TabIndex = 5;
            this.maleRadio.TabStop = true;
            this.maleRadio.Text = "Мъж";
            this.maleRadio.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(174, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Специалност:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(174, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Пол:";
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(309, 125);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(177, 20);
            this.ageBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(175, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Възраст:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(148, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Моля попълнете следнете данни за вас:";
            // 
            // PersonalInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 445);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(719, 483);
            this.MinimumSize = new System.Drawing.Size(719, 483);
            this.Name = "PersonalInformationForm";
            this.Text = "PersonalInformation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnCloseRequired);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton femaleRadio;
        private System.Windows.Forms.RadioButton maleRadio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.ComboBox majorDropDown;
    }
}