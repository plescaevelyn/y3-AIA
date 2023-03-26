using System.Data;
using System.Security.Cryptography;

namespace Example
{
    partial class Form1 : Form
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
            groupBox1 = new GroupBox();
            button1 = new Button();
            button3 = new Button();
            button2 = new Button();
            textBox_City = new TextBox();
            textBox_CodeUniv = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            listBox_Fac = new ListBox();
            listBox_Univ = new ListBox();
            label5 = new Label();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox_City);
            groupBox1.Controls.Add(textBox_CodeUniv);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(listBox_Fac);
            groupBox1.Controls.Add(listBox_Univ);
            groupBox1.Location = new Point(44, 29);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(834, 422);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Exemplu DB";
            // 
            // button1
            // 
            button1.Location = new Point(366, 346);
            button1.Name = "button1";
            button1.Size = new Size(118, 58);
            button1.TabIndex = 8;
            button1.Text = "Inserare universitate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(649, 346);
            button3.Name = "button3";
            button3.Size = new Size(118, 58);
            button3.TabIndex = 10;
            button3.Text = "Stergere universitate";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(508, 346);
            button2.Name = "button2";
            button2.Size = new Size(118, 58);
            button2.TabIndex = 9;
            button2.Text = "Update universitate";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox_City
            // 
            textBox_City.Location = new Point(369, 175);
            textBox_City.Margin = new Padding(3, 2, 3, 2);
            textBox_City.Name = "textBox_City";
            textBox_City.Size = new Size(168, 23);
            textBox_City.TabIndex = 6;
            // 
            // textBox_CodeUniv
            // 
            textBox_CodeUniv.Location = new Point(369, 227);
            textBox_CodeUniv.Margin = new Padding(3, 2, 3, 2);
            textBox_CodeUniv.Name = "textBox_CodeUniv";
            textBox_CodeUniv.Size = new Size(168, 23);
            textBox_CodeUniv.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(366, 210);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 5;
            label4.Text = "Cod univ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(369, 158);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 4;
            label3.Text = "Oras";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(369, 22);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Facultate";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 22);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 2;
            label1.Text = "Universitati";
            // 
            // listBox_Fac
            // 
            listBox_Fac.FormattingEnabled = true;
            listBox_Fac.ItemHeight = 15;
            listBox_Fac.Location = new Point(369, 40);
            listBox_Fac.Margin = new Padding(3, 2, 3, 2);
            listBox_Fac.Name = "listBox_Fac";
            listBox_Fac.Size = new Size(331, 109);
            listBox_Fac.TabIndex = 1;
            // 
            // listBox_Univ
            // 
            listBox_Univ.FormattingEnabled = true;
            listBox_Univ.ItemHeight = 15;
            listBox_Univ.Location = new Point(60, 40);
            listBox_Univ.Margin = new Padding(3, 2, 3, 2);
            listBox_Univ.Name = "listBox_Univ";
            listBox_Univ.Size = new Size(256, 364);
            listBox_Univ.TabIndex = 0;
            listBox_Univ.SelectedIndexChanged += listBox_Univ_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(368, 278);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 11;
            label5.Text = "Nume universitate:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(366, 306);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 23);
            textBox1.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 462);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listBox_Fac;
        private ListBox listBox_Univ;
        private TextBox textBox_City;
        private TextBox textBox_CodeUniv;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private Button button3;
        private Button button2;
        private TextBox textBox1;
        private Label label5;
    }
}