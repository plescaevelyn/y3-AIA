namespace Exercise3
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
            menuStrip1 = new MenuStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            add = new ToolStripMenuItem();
            substract = new ToolStripSeparator();
            multiply = new ToolStripMenuItem();
            divide = new ToolStripMenuItem();
            toolStripTextBox2 = new ToolStripTextBox();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripTextBox3 = new ToolStripTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, add, toolStripTextBox2, toolStripMenuItem4, toolStripTextBox3 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(396, 31);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            // 
            // add
            // 
            add.DropDownItems.AddRange(new ToolStripItem[] { substract, multiply, divide });
            add.Name = "add";
            add.Size = new Size(33, 27);
            add.Text = "+";
            add.Click += add_Click;
            // 
            // substract
            // 
            substract.Name = "substract";
            substract.Size = new Size(221, 6);
            substract.Text = "-";
            substract.Click += substract_Click;
            // 
            // multiply
            // 
            multiply.Name = "multiply";
            multiply.Size = new Size(224, 26);
            multiply.Text = "*";
            multiply.Click += multiply_Click;
            // 
            // divide
            // 
            divide.Name = "divide";
            divide.Size = new Size(224, 26);
            divide.Text = "/";
            divide.Click += divide_Click;
            // 
            // toolStripTextBox2
            // 
            toolStripTextBox2.Name = "toolStripTextBox2";
            toolStripTextBox2.Size = new Size(100, 27);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(33, 27);
            toolStripMenuItem4.Text = "=";
            // 
            // toolStripTextBox3
            // 
            toolStripTextBox3.Enabled = false;
            toolStripTextBox3.Name = "toolStripTextBox3";
            toolStripTextBox3.Size = new Size(100, 27);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 36);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripMenuItem add;
        private ToolStripSeparator substract;
        private ToolStripMenuItem multiply;
        private ToolStripMenuItem divide;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripTextBox toolStripTextBox3;
    }
}