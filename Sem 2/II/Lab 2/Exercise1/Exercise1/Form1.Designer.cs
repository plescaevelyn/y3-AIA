namespace Exercise1
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Tomato;
            button1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(106, 281);
            button1.Name = "button1";
            button1.Size = new Size(112, 58);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(292, 281);
            button2.Name = "button2";
            button2.Size = new Size(118, 58);
            button2.TabIndex = 1;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Tomato;
            label1.Location = new Point(70, 112);
            label1.Name = "label1";
            label1.Size = new Size(138, 29);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(70, 198);
            label2.Name = "label2";
            label2.Size = new Size(148, 29);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(224, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(224, 198);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(170, 27);
            textBox2.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Location = new Point(481, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(318, 451);
            panel1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            ForeColor = Color.Transparent;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Panel panel1;
    }
}