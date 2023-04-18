namespace MOTI
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
            button1 = new Button();
            button4 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            AudienceList = new ListBox();
            AudiencePackList = new ListBox();
            button5 = new Button();
            AudienceNeed = new ListBox();
            button10 = new Button();
            button11 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            AudiencePackNeed = new ListBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(187, 291);
            button1.Name = "button1";
            button1.Size = new Size(92, 49);
            button1.TabIndex = 0;
            button1.Text = "Додати набір";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(70, 291);
            button4.Name = "button4";
            button4.Size = new Size(92, 49);
            button4.TabIndex = 3;
            button4.Text = "Подробиці про набір";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Location = new Point(782, 346);
            button6.Name = "button6";
            button6.Size = new Size(92, 49);
            button6.TabIndex = 6;
            button6.Text = "Видалити фокус-групу";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(665, 346);
            button7.Name = "button7";
            button7.Size = new Size(92, 49);
            button7.TabIndex = 5;
            button7.Text = "Редагувати фокус-групу";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(782, 291);
            button8.Name = "button8";
            button8.Size = new Size(92, 49);
            button8.TabIndex = 4;
            button8.Text = "Додати фокусгрупу";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // AudienceList
            // 
            AudienceList.FormattingEnabled = true;
            AudienceList.ItemHeight = 15;
            AudienceList.Location = new Point(655, 116);
            AudienceList.Name = "AudienceList";
            AudienceList.Size = new Size(235, 169);
            AudienceList.TabIndex = 8;
            // 
            // AudiencePackList
            // 
            AudiencePackList.FormattingEnabled = true;
            AudiencePackList.ItemHeight = 15;
            AudiencePackList.Location = new Point(54, 116);
            AudiencePackList.Name = "AudiencePackList";
            AudiencePackList.Size = new Size(235, 169);
            AudiencePackList.TabIndex = 9;
            // 
            // button5
            // 
            button5.Location = new Point(665, 291);
            button5.Name = "button5";
            button5.Size = new Size(92, 49);
            button5.TabIndex = 7;
            button5.Text = "Обрати фокус-групу";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // AudienceNeed
            // 
            AudienceNeed.FormattingEnabled = true;
            AudienceNeed.ItemHeight = 15;
            AudienceNeed.Location = new Point(361, 116);
            AudienceNeed.Name = "AudienceNeed";
            AudienceNeed.Size = new Size(235, 169);
            AudienceNeed.TabIndex = 10;
            // 
            // button10
            // 
            button10.Location = new Point(492, 291);
            button10.Name = "button10";
            button10.Size = new Size(92, 49);
            button10.TabIndex = 13;
            button10.Text = "Видалити фокус-групу";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(375, 291);
            button11.Name = "button11";
            button11.Size = new Size(92, 49);
            button11.TabIndex = 12;
            button11.Text = "Редагувати фокус-групу";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 98);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 14;
            label1.Text = "Набір фокус-груп";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(361, 98);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 15;
            label2.Text = "Необхідно фокус групи";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(655, 98);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 16;
            label3.Text = "Фокус-група";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(361, 346);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 18;
            label4.Text = "Набір фокус-груп";
            // 
            // AudiencePackNeed
            // 
            AudiencePackNeed.FormattingEnabled = true;
            AudiencePackNeed.ItemHeight = 15;
            AudiencePackNeed.Location = new Point(361, 364);
            AudiencePackNeed.Name = "AudiencePackNeed";
            AudiencePackNeed.Size = new Size(235, 169);
            AudiencePackNeed.TabIndex = 17;
            // 
            // button2
            // 
            button2.Location = new Point(602, 428);
            button2.Name = "button2";
            button2.Size = new Size(92, 49);
            button2.TabIndex = 19;
            button2.Text = "Згенерувати";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(602, 483);
            button3.Name = "button3";
            button3.Size = new Size(92, 49);
            button3.TabIndex = 20;
            button3.Text = "Подробиці про набір";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(AudiencePackNeed);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(AudienceNeed);
            Controls.Add(AudiencePackList);
            Controls.Add(AudienceList);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button4);
            Controls.Add(button1);
            MaximumSize = new Size(1000, 600);
            MinimumSize = new Size(1000, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button4;
        private Button button6;
        private Button button7;
        private Button button8;
        private ListBox AudienceList;
        private ListBox AudiencePackList;
        private Button button5;
        private ListBox AudienceNeed;
        private Button button10;
        private Button button11;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox AudiencePackNeed;
        private Button button2;
        private Button button3;
    }
}