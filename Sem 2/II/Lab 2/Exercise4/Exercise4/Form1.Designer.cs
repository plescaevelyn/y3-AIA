namespace Exercise4
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            listBox1 = new ListBox();
            tabPage2 = new TabPage();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(11, 13);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(904, 521);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(896, 488);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Location = new Point(247, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(624, 464);
            panel1.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(24, 21);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(194, 464);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightPink;
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(896, 488);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Harlow Solid Italic", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.DeepPink;
            label2.Location = new Point(370, 411);
            label2.Name = "label2";
            label2.Size = new Size(95, 38);
            label2.TabIndex = 3;
            label2.Text = "Fight!";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Vladimir Script", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DeepPink;
            label1.Location = new Point(265, 19);
            label1.Name = "label1";
            label1.Size = new Size(317, 54);
            label1.TabIndex = 2;
            label1.Text = "Choose your fighter!";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton5);
            groupBox2.Controls.Add(radioButton6);
            groupBox2.Controls.Add(radioButton7);
            groupBox2.Controls.Add(radioButton8);
            groupBox2.Location = new Point(465, 76);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(283, 314);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(28, 145);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(80, 24);
            radioButton5.TabIndex = 6;
            radioButton5.TabStop = true;
            radioButton5.Text = "Kendall";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(28, 96);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(61, 24);
            radioButton6.TabIndex = 7;
            radioButton6.TabStop = true;
            radioButton6.Text = "Kylie";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(28, 50);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(72, 24);
            radioButton7.TabIndex = 8;
            radioButton7.TabStop = true;
            radioButton7.Text = "Hailey";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(28, 187);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(66, 24);
            radioButton8.TabIndex = 9;
            radioButton8.TabStop = true;
            radioButton8.Text = "Justin";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(105, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(283, 314);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(47, 187);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(87, 24);
            radioButton4.TabIndex = 5;
            radioButton4.TabStop = true;
            radioButton4.Text = "Zendaya";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(47, 145);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(66, 24);
            radioButton3.TabIndex = 4;
            radioButton3.TabStop = true;
            radioButton3.Text = "Miley";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(47, 96);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(69, 24);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "Taylor";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(47, 50);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(74, 24);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "Selena";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 565);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private ListBox listBox1;
        private TabPage tabPage2;
        private Panel panel1;
        private GroupBox groupBox2;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label1;
        private Label label2;
    }
}