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
            button4 = new Button();
            button5 = new Button();
            textBoxIdFac = new TextBox();
            label11 = new Label();
            textBoxCodFac = new TextBox();
            label9 = new Label();
            textBoxNumeFac = new TextBox();
            label10 = new Label();
            dataGridView1 = new DataGridView();
            textBox_oras = new TextBox();
            textBox_id = new TextBox();
            textBox_cod = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            textBox_Nume = new TextBox();
            label5 = new Label();
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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(textBoxIdFac);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(textBoxCodFac);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textBoxNumeFac);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(textBox_oras);
            groupBox1.Controls.Add(textBox_id);
            groupBox1.Controls.Add(textBox_cod);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox_Nume);
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
            groupBox1.Location = new Point(50, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1302, 578);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Exemplu DB";
            // 
            // button4
            // 
            button4.Location = new Point(1069, 473);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(116, 67);
            button4.TabIndex = 27;
            button4.Text = "Stergere facultate";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(904, 473);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(116, 67);
            button5.TabIndex = 26;
            button5.Text = "Adauga facultate";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBoxIdFac
            // 
            textBoxIdFac.Location = new Point(858, 417);
            textBoxIdFac.Name = "textBoxIdFac";
            textBoxIdFac.Size = new Size(162, 27);
            textBoxIdFac.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(858, 394);
            label11.Name = "label11";
            label11.Size = new Size(89, 20);
            label11.TabIndex = 24;
            label11.Text = "ID facultate:";
            // 
            // textBoxCodFac
            // 
            textBoxCodFac.Location = new Point(858, 362);
            textBoxCodFac.Name = "textBoxCodFac";
            textBoxCodFac.Size = new Size(162, 27);
            textBoxCodFac.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(858, 339);
            label9.Name = "label9";
            label9.Size = new Size(101, 20);
            label9.TabIndex = 22;
            label9.Text = "Cod facultate:";
            // 
            // textBoxNumeFac
            // 
            textBoxNumeFac.Location = new Point(858, 303);
            textBoxNumeFac.Margin = new Padding(3, 4, 3, 4);
            textBoxNumeFac.Name = "textBoxNumeFac";
            textBoxNumeFac.Size = new Size(162, 27);
            textBoxNumeFac.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(858, 280);
            label10.Name = "label10";
            label10.Size = new Size(114, 20);
            label10.TabIndex = 20;
            label10.Text = "Nume facultate:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(823, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(457, 223);
            dataGridView1.TabIndex = 19;
            // 
            // textBox_oras
            // 
            textBox_oras.Location = new Point(629, 417);
            textBox_oras.Name = "textBox_oras";
            textBox_oras.Size = new Size(162, 27);
            textBox_oras.TabIndex = 18;
            // 
            // textBox_id
            // 
            textBox_id.Location = new Point(629, 362);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(162, 27);
            textBox_id.TabIndex = 17;
            // 
            // textBox_cod
            // 
            textBox_cod.Location = new Point(395, 417);
            textBox_cod.Name = "textBox_cod";
            textBox_cod.Size = new Size(162, 27);
            textBox_cod.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(629, 394);
            label8.Name = "label8";
            label8.Size = new Size(122, 20);
            label8.TabIndex = 15;
            label8.Text = "Oras universitate:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(395, 394);
            label7.Name = "label7";
            label7.Size = new Size(119, 20);
            label7.TabIndex = 14;
            label7.Text = "Cod universitate:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(629, 339);
            label6.Name = "label6";
            label6.Size = new Size(107, 20);
            label6.TabIndex = 13;
            label6.Text = "ID universitate:";
            // 
            // textBox_Nume
            // 
            textBox_Nume.Location = new Point(395, 363);
            textBox_Nume.Margin = new Padding(3, 4, 3, 4);
            textBox_Nume.Name = "textBox_Nume";
            textBox_Nume.Size = new Size(162, 27);
            textBox_Nume.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(395, 339);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 11;
            label5.Text = "Nume universitate:";
            // 
            // button1
            // 
            button1.Location = new Point(393, 473);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(116, 67);
            button1.TabIndex = 8;
            button1.Text = "Inserare universitate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(675, 473);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(116, 67);
            button3.TabIndex = 10;
            button3.Text = "Stergere universitate";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(531, 473);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(116, 67);
            button2.TabIndex = 9;
            button2.Text = "Update universitate";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox_City
            // 
            textBox_City.Location = new Point(397, 233);
            textBox_City.Name = "textBox_City";
            textBox_City.Size = new Size(191, 27);
            textBox_City.TabIndex = 6;
            // 
            // textBox_CodeUniv
            // 
            textBox_CodeUniv.Location = new Point(397, 303);
            textBox_CodeUniv.Name = "textBox_CodeUniv";
            textBox_CodeUniv.Size = new Size(191, 27);
            textBox_CodeUniv.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(393, 280);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 5;
            label4.Text = "Cod univ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(397, 211);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 4;
            label3.Text = "Oras";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(397, 29);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 3;
            label2.Text = "Facultate";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 29);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 2;
            label1.Text = "Universitati";
            // 
            // listBox_Fac
            // 
            listBox_Fac.FormattingEnabled = true;
            listBox_Fac.ItemHeight = 20;
            listBox_Fac.Location = new Point(397, 53);
            listBox_Fac.Name = "listBox_Fac";
            listBox_Fac.Size = new Size(394, 144);
            listBox_Fac.TabIndex = 1;
            // 
            // listBox_Univ
            // 
            listBox_Univ.FormattingEnabled = true;
            listBox_Univ.ItemHeight = 20;
            listBox_Univ.Location = new Point(69, 53);
            listBox_Univ.Name = "listBox_Univ";
            listBox_Univ.Size = new Size(292, 504);
            listBox_Univ.TabIndex = 0;
            listBox_Univ.SelectedIndexChanged += listBox_Univ_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 616);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private TextBox textBox_Nume;
        private Label label5;
        private TextBox textBox_oras;
        private TextBox textBox_id;
        private TextBox textBox_cod;
        private Label label8;
        private Label label7;
        private Label label6;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button5;
        private TextBox textBoxIdFac;
        private Label label11;
        private TextBox textBoxCodFac;
        private Label label9;
        private TextBox textBoxNumeFac;
        private Label label10;
    }
}