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
            textBox_City = new TextBox();
            textBox_CodeUniv = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            listBox_Fac = new ListBox();
            listBox_Univ = new ListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            groupBox1.Size = new Size(536, 248);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Exemplu DB";
            // 
            // textBox_City
            // 
            textBox_City.Location = new Point(337, 165);
            textBox_City.Margin = new Padding(3, 2, 3, 2);
            textBox_City.Name = "textBox_City";
            textBox_City.Size = new Size(168, 23);
            textBox_City.TabIndex = 6;
            // 
            // textBox_CodeUniv
            // 
            textBox_CodeUniv.Location = new Point(337, 218);
            textBox_CodeUniv.Margin = new Padding(3, 2, 3, 2);
            textBox_CodeUniv.Name = "textBox_CodeUniv";
            textBox_CodeUniv.Size = new Size(168, 23);
            textBox_CodeUniv.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(335, 200);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 5;
            label4.Text = "Cod univ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(337, 148);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 4;
            label3.Text = "Oras";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(337, 22);
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
            listBox_Fac.Location = new Point(337, 40);
            listBox_Fac.Margin = new Padding(3, 2, 3, 2);
            listBox_Fac.Name = "listBox_Fac";
            listBox_Fac.Size = new Size(158, 94);
            listBox_Fac.TabIndex = 1;
            // 
            // listBox_Univ
            // 
            listBox_Univ.FormattingEnabled = true;
            listBox_Univ.ItemHeight = 15;
            listBox_Univ.Location = new Point(60, 40);
            listBox_Univ.Margin = new Padding(3, 2, 3, 2);
            listBox_Univ.Name = "listBox_Univ";
            listBox_Univ.Size = new Size(228, 199);
            listBox_Univ.TabIndex = 0;
            listBox_Univ.SelectedIndexChanged += listBox_Univ_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 320);
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
    }
}