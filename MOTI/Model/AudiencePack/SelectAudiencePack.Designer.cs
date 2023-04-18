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
            // 
            // button2
            // 
            button2.Location = new Point(50, 348);
            button2.Name = "button2";
            button2.Size = new Size(92, 49);
            button2.TabIndex = 4;
            button2.Text = "Зберегти Зміни";
            button2.UseVisualStyleBackColor = true;
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
            button1.Location = new Point(311, 128);
            button1.Name = "button1";
            button1.Size = new Size(88, 49);
            button1.TabIndex = 9;
            button1.Text = "Додати фокус-групу";
            button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(311, 183);
            button4.Name = "button4";
            button4.Size = new Size(88, 49);
            button4.TabIndex = 10;
            button4.Text = "Видалити фокус-групу";
            button4.UseVisualStyleBackColor = true;
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
            // SelectAudiencePack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 475);
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
            Text = "SelectAidoencePack";
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
    }
}