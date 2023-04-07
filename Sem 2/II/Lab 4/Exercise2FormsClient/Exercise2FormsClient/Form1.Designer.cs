namespace Exercise2FormsClient
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
            TextBox resultTextBox;
            listBox = new ListBox();
            addListBttn = new Button();
            dataLbl = new Label();
            celsiusLbl = new Label();
            fahrenheitLbl = new Label();
            tempConvResLbl = new Label();
            celsiusTextBox = new TextBox();
            fahrenheitTextBox = new TextBox();
            FtoCbttn = new Button();
            CtoFbttn = new Button();
            label5 = new Label();
            ronTextBox = new TextBox();
            hufTextBox = new TextBox();
            resultTextBox = new TextBox();
            SuspendLayout();
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(399, 133);
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(160, 27);
            resultTextBox.TabIndex = 8;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 20;
            listBox.Location = new Point(64, 29);
            listBox.Name = "listBox";
            listBox.Size = new Size(192, 124);
            listBox.TabIndex = 0;
            // 
            // addListBttn
            // 
            addListBttn.Location = new Point(89, 170);
            addListBttn.Name = "addListBttn";
            addListBttn.Size = new Size(141, 29);
            addListBttn.TabIndex = 1;
            addListBttn.Text = "Adauga lista";
            addListBttn.UseVisualStyleBackColor = true;
            // 
            // dataLbl
            // 
            dataLbl.AutoSize = true;
            dataLbl.Location = new Point(64, 293);
            dataLbl.Name = "dataLbl";
            dataLbl.Size = new Size(44, 20);
            dataLbl.TabIndex = 2;
            dataLbl.Text = "Data:";
            dataLbl.Click += dataLbl_Click;
            // 
            // celsiusLbl
            // 
            celsiusLbl.AutoSize = true;
            celsiusLbl.Location = new Point(330, 33);
            celsiusLbl.Name = "celsiusLbl";
            celsiusLbl.Size = new Size(59, 20);
            celsiusLbl.TabIndex = 3;
            celsiusLbl.Text = "Temp C";
            // 
            // fahrenheitLbl
            // 
            fahrenheitLbl.AutoSize = true;
            fahrenheitLbl.Location = new Point(330, 83);
            fahrenheitLbl.Name = "fahrenheitLbl";
            fahrenheitLbl.Size = new Size(57, 20);
            fahrenheitLbl.TabIndex = 4;
            fahrenheitLbl.Text = "Temp F";
            // 
            // tempConvResLbl
            // 
            tempConvResLbl.AutoSize = true;
            tempConvResLbl.Location = new Point(330, 133);
            tempConvResLbl.Name = "tempConvResLbl";
            tempConvResLbl.Size = new Size(63, 20);
            tempConvResLbl.TabIndex = 5;
            tempConvResLbl.Text = "Rezultat";
            // 
            // celsiusTextBox
            // 
            celsiusTextBox.Location = new Point(399, 26);
            celsiusTextBox.Name = "celsiusTextBox";
            celsiusTextBox.Size = new Size(160, 27);
            celsiusTextBox.TabIndex = 6;
            // 
            // fahrenheitTextBox
            // 
            fahrenheitTextBox.Location = new Point(399, 80);
            fahrenheitTextBox.Name = "fahrenheitTextBox";
            fahrenheitTextBox.Size = new Size(160, 27);
            fahrenheitTextBox.TabIndex = 7;
            // 
            // FtoCbttn
            // 
            FtoCbttn.Location = new Point(415, 170);
            FtoCbttn.Name = "FtoCbttn";
            FtoCbttn.Size = new Size(94, 29);
            FtoCbttn.TabIndex = 9;
            FtoCbttn.Text = "FtoC";
            FtoCbttn.UseVisualStyleBackColor = true;
            FtoCbttn.Click += FtoCbttn_Click;
            // 
            // CtoFbttn
            // 
            CtoFbttn.Location = new Point(415, 205);
            CtoFbttn.Name = "CtoFbttn";
            CtoFbttn.Size = new Size(94, 29);
            CtoFbttn.TabIndex = 10;
            CtoFbttn.Text = "CtoF";
            CtoFbttn.UseVisualStyleBackColor = true;
            CtoFbttn.Click += CtoFbttn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(303, 296);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 11;
            label5.Text = "RON to HUF";
            // 
            // ronTextBox
            // 
            ronTextBox.Location = new Point(399, 293);
            ronTextBox.Name = "ronTextBox";
            ronTextBox.Size = new Size(125, 27);
            ronTextBox.TabIndex = 12;
            ronTextBox.TextChanged += ronTextBox_TextChanged;
            // 
            // hufTextBox
            // 
            hufTextBox.Location = new Point(399, 335);
            hufTextBox.Name = "hufTextBox";
            hufTextBox.ReadOnly = true;
            hufTextBox.Size = new Size(125, 27);
            hufTextBox.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 450);
            Controls.Add(hufTextBox);
            Controls.Add(ronTextBox);
            Controls.Add(label5);
            Controls.Add(CtoFbttn);
            Controls.Add(FtoCbttn);
            Controls.Add(resultTextBox);
            Controls.Add(fahrenheitTextBox);
            Controls.Add(celsiusTextBox);
            Controls.Add(tempConvResLbl);
            Controls.Add(fahrenheitLbl);
            Controls.Add(celsiusLbl);
            Controls.Add(dataLbl);
            Controls.Add(addListBttn);
            Controls.Add(listBox);
            Name = "Form1";
            Text = "s";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox;
        private Button addListBttn;
        private Label dataLbl;
        private Label celsiusLbl;
        private Label fahrenheitLbl;
        private Label tempConvResLbl;
        private TextBox celsiusTextBox;
        private TextBox fahrenheitTextBox;
        private TextBox resultTextBox;
        private Button FtoCbttn;
        private Button CtoFbttn;
        private Label label5;
        private TextBox ronTextBox;
        private TextBox hufTextBox;
    }
}