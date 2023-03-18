namespace Tema1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            button1 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            listBox1 = new ListBox();
            label6 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(48, 9);
            label1.Name = "label1";
            label1.Size = new Size(185, 38);
            label1.TabIndex = 0;
            label1.Text = "Application";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 69);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Last name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 118);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 2;
            label3.Text = "First name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 162);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 3;
            label4.Text = "Gender:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(220, 211);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(58, 27);
            numericUpDown1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 211);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 5;
            label5.Text = "Years of experience:";
            // 
            // button1
            // 
            button1.Location = new Point(166, 399);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Submit!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(153, 162);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(63, 24);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "male";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(246, 162);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(76, 24);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "female";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(143, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(212, 27);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(143, 118);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(212, 27);
            textBox2.TabIndex = 10;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(278, 267);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 104);
            listBox1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 267);
            label6.Name = "label6";
            label6.Size = new Size(212, 20);
            label6.TabIndex = 12;
            label6.Text = "The role you want to apply for:";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Location = new Point(446, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 455);
            panel1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(listBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private Button button1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
        private TextBox textBox2;
        private ListBox listBox1;
        private Label label6;
        private Panel panel1;
    }
}