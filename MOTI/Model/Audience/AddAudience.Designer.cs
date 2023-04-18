namespace MOTI.Model
{
    partial class AddAudience
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
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "1";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Чоловік", "Жінка" });
            comboBox1.Location = new Point(28, 91);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(111, 23);
            comboBox1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(28, 37);
            numericUpDown1.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(69, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 19);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 2;
            label1.Text = "Вік";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 73);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 3;
            label2.Text = "Стать";
            // 
            // button2
            // 
            button2.Location = new Point(37, 157);
            button2.Name = "button2";
            button2.Size = new Size(82, 24);
            button2.TabIndex = 5;
            button2.Text = "Назад";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(37, 120);
            button1.Name = "button1";
            button1.Size = new Size(82, 31);
            button1.TabIndex = 4;
            button1.Text = "Додати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddAudience
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(162, 213);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            MaximumSize = new Size(178, 252);
            MinimumSize = new Size(178, 252);
            Name = "AddAudience";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddAudience";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button button1;
    }
}