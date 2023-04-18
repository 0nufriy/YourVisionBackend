namespace MOTI.Model.AudiencePack
{
    partial class AddAudiencePack
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
            label5 = new Label();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            button5 = new Button();
            button4 = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button2 = new Button();
            Audiences = new ListBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(299, 191);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 30;
            label5.Text = "Кілкість:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(299, 144);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 29;
            label4.Text = "Фокус-група:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(299, 209);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(112, 23);
            numericUpDown1.TabIndex = 28;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(299, 162);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 23);
            comboBox1.TabIndex = 27;
            // 
            // button5
            // 
            button5.Location = new Point(234, 349);
            button5.Name = "button5";
            button5.Size = new Size(59, 49);
            button5.TabIndex = 26;
            button5.Text = "Назад";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(311, 293);
            button4.Name = "button4";
            button4.Size = new Size(88, 49);
            button4.TabIndex = 25;
            button4.Text = "Видалити фокус-групу";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(311, 238);
            button1.Name = "button1";
            button1.Size = new Size(88, 49);
            button1.TabIndex = 24;
            button1.Text = "Додати фокус-групу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(93, 56);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 23);
            textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(93, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 23);
            textBox1.TabIndex = 22;
            // 
            // button2
            // 
            button2.Location = new Point(121, 349);
            button2.Name = "button2";
            button2.Size = new Size(92, 49);
            button2.TabIndex = 20;
            button2.Text = "Додати";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Audiences
            // 
            Audiences.FormattingEnabled = true;
            Audiences.ItemHeight = 15;
            Audiences.Location = new Point(36, 129);
            Audiences.Name = "Audiences";
            Audiences.Size = new Size(257, 214);
            Audiences.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 101);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 18;
            label3.Text = "Склад:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 59);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 17;
            label2.Text = "Ціна:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 30);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 16;
            label1.Text = "Назва: ";
            // 
            // AddAudiencePack
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
            Controls.Add(button2);
            Controls.Add(Audiences);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(448, 514);
            MinimumSize = new Size(448, 514);
            Name = "AddAudiencePack";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddAidoencePack";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
        private Button button5;
        private Button button4;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
        private ListBox Audiences;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}