namespace MOTI.Model.AudiencePack
{
    partial class SelectAudiencePack
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Audiences = new ListBox();
            button3 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button4 = new Button();
            button5 = new Button();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 29);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Назва: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 58);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 1;
            label2.Text = "Ціна:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 100);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Склад:";
            // 
            // Audiences
            // 
            Audiences.FormattingEnabled = true;
            Audiences.ItemHeight = 15;
            Audiences.Location = new Point(48, 128);
            Audiences.Name = "Audiences";
            Audiences.Size = new Size(257, 214);
            Audiences.TabIndex = 3;
            // 
            // button3
            // 
            button3.Location = new Point(148, 348);
            button3.Name = "button3";
            button3.Size = new Size(92, 49);
            button3.TabIndex = 5;
            button3.Text = "Видалити Набір";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(50, 348);
            button2.Name = "button2";
            button2.Size = new Size(92, 49);
            button2.TabIndex = 4;
            button2.Text = "Зберегти Зміни";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(105, 55);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 23);
            textBox2.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(323, 237);
            button1.Name = "button1";
            button1.Size = new Size(88, 49);
            button1.TabIndex = 9;
            button1.Text = "Додати фокус-групу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(323, 292);
            button4.Name = "button4";
            button4.Size = new Size(88, 49);
            button4.TabIndex = 10;
            button4.Text = "Видалити фокус-групу";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(246, 348);
            button5.Name = "button5";
            button5.Size = new Size(59, 49);
            button5.TabIndex = 11;
            button5.Text = "Назад";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(311, 161);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 23);
            comboBox1.TabIndex = 12;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(311, 208);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(112, 23);
            numericUpDown1.TabIndex = 13;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(311, 143);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 14;
            label4.Text = "Фокус-група:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(311, 190);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 15;
            label5.Text = "Кілкість:";
            // 
            // SelectAudiencePack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 475);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Audiences);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SelectAudiencePack";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectAidoencePack";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox Audiences;
        private Button button3;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button4;
        private Button button5;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private Label label5;
    }
}