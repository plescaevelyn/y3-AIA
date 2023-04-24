namespace Tema2Client
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
            dbData = new ListBox();
            currentSongs = new Label();
            idLabel = new Label();
            songNameLabel = new Label();
            songTypeLabel = new Label();
            artistLabel = new Label();
            insertBttn = new Button();
            updateBttn = new Button();
            deleteBttn = new Button();
            songIdTextBox = new TextBox();
            songNameTextBox = new TextBox();
            songTypeTextBox = new TextBox();
            artistTextBox = new TextBox();
            albumTextBox = new TextBox();
            albumLabel = new Label();
            SuspendLayout();
            // 
            // dbData
            // 
            dbData.FormattingEnabled = true;
            dbData.ItemHeight = 20;
            dbData.Location = new Point(50, 56);
            dbData.Name = "dbData";
            dbData.Size = new Size(361, 404);
            dbData.TabIndex = 0;
            dbData.SelectedIndexChanged += dbData_SelectedIndexChanged;
            // 
            // currentSongs
            // 
            currentSongs.AutoSize = true;
            currentSongs.Font = new Font("SWComp", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            currentSongs.Location = new Point(49, 18);
            currentSongs.Name = "currentSongs";
            currentSongs.Size = new Size(273, 36);
            currentSongs.TabIndex = 1;
            currentSongs.Text = "Current songs";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("SWComp", 9F, FontStyle.Regular, GraphicsUnit.Point);
            idLabel.Location = new Point(461, 92);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(87, 19);
            idLabel.TabIndex = 2;
            idLabel.Text = "Song id:";
            // 
            // songNameLabel
            // 
            songNameLabel.AutoSize = true;
            songNameLabel.Font = new Font("SWComp", 9F, FontStyle.Regular, GraphicsUnit.Point);
            songNameLabel.Location = new Point(461, 145);
            songNameLabel.Name = "songNameLabel";
            songNameLabel.Size = new Size(119, 19);
            songNameLabel.TabIndex = 3;
            songNameLabel.Text = "Song name:";
            // 
            // songTypeLabel
            // 
            songTypeLabel.AutoSize = true;
            songTypeLabel.Font = new Font("SWComp", 9F, FontStyle.Regular, GraphicsUnit.Point);
            songTypeLabel.Location = new Point(461, 198);
            songTypeLabel.Name = "songTypeLabel";
            songTypeLabel.Size = new Size(109, 19);
            songTypeLabel.TabIndex = 4;
            songTypeLabel.Text = "Song type:";
            // 
            // artistLabel
            // 
            artistLabel.AutoSize = true;
            artistLabel.Font = new Font("SWComp", 9F, FontStyle.Regular, GraphicsUnit.Point);
            artistLabel.Location = new Point(461, 251);
            artistLabel.Name = "artistLabel";
            artistLabel.Size = new Size(68, 19);
            artistLabel.TabIndex = 5;
            artistLabel.Text = "Artist:";
            // 
            // insertBttn
            // 
            insertBttn.BackColor = Color.RosyBrown;
            insertBttn.Font = new Font("SWComp", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            insertBttn.Location = new Point(430, 379);
            insertBttn.Name = "insertBttn";
            insertBttn.Size = new Size(101, 64);
            insertBttn.TabIndex = 6;
            insertBttn.Text = "Insert song";
            insertBttn.UseVisualStyleBackColor = false;
            insertBttn.Click += insertBttn_Click;
            // 
            // updateBttn
            // 
            updateBttn.BackColor = Color.RosyBrown;
            updateBttn.Font = new Font("SWComp", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            updateBttn.Location = new Point(537, 379);
            updateBttn.Name = "updateBttn";
            updateBttn.Size = new Size(101, 64);
            updateBttn.TabIndex = 7;
            updateBttn.Text = "Update song";
            updateBttn.UseVisualStyleBackColor = false;
            updateBttn.Click += updateBttn_Click;
            // 
            // deleteBttn
            // 
            deleteBttn.BackColor = Color.RosyBrown;
            deleteBttn.Font = new Font("SWComp", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            deleteBttn.Location = new Point(644, 379);
            deleteBttn.Name = "deleteBttn";
            deleteBttn.Size = new Size(103, 64);
            deleteBttn.TabIndex = 8;
            deleteBttn.Text = "Delete song";
            deleteBttn.UseVisualStyleBackColor = false;
            deleteBttn.Click += deleteBttn_Click;
            // 
            // songIdTextBox
            // 
            songIdTextBox.Location = new Point(461, 115);
            songIdTextBox.Name = "songIdTextBox";
            songIdTextBox.Size = new Size(233, 27);
            songIdTextBox.TabIndex = 9;
            // 
            // songNameTextBox
            // 
            songNameTextBox.Location = new Point(461, 168);
            songNameTextBox.Name = "songNameTextBox";
            songNameTextBox.Size = new Size(233, 27);
            songNameTextBox.TabIndex = 10;
            // 
            // songTypeTextBox
            // 
            songTypeTextBox.Location = new Point(461, 221);
            songTypeTextBox.Name = "songTypeTextBox";
            songTypeTextBox.Size = new Size(233, 27);
            songTypeTextBox.TabIndex = 11;
            // 
            // artistTextBox
            // 
            artistTextBox.Location = new Point(461, 274);
            artistTextBox.Name = "artistTextBox";
            artistTextBox.Size = new Size(233, 27);
            artistTextBox.TabIndex = 12;
            // 
            // albumTextBox
            // 
            albumTextBox.Location = new Point(461, 327);
            albumTextBox.Name = "albumTextBox";
            albumTextBox.Size = new Size(233, 27);
            albumTextBox.TabIndex = 13;
            // 
            // albumLabel
            // 
            albumLabel.AutoSize = true;
            albumLabel.Font = new Font("SWComp", 9F, FontStyle.Regular, GraphicsUnit.Point);
            albumLabel.Location = new Point(461, 304);
            albumLabel.Name = "albumLabel";
            albumLabel.Size = new Size(74, 19);
            albumLabel.TabIndex = 14;
            albumLabel.Text = "Album:";
            albumLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 506);
            Controls.Add(albumLabel);
            Controls.Add(albumTextBox);
            Controls.Add(artistTextBox);
            Controls.Add(songTypeTextBox);
            Controls.Add(songNameTextBox);
            Controls.Add(songIdTextBox);
            Controls.Add(deleteBttn);
            Controls.Add(updateBttn);
            Controls.Add(insertBttn);
            Controls.Add(artistLabel);
            Controls.Add(songTypeLabel);
            Controls.Add(songNameLabel);
            Controls.Add(idLabel);
            Controls.Add(currentSongs);
            Controls.Add(dbData);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox dbData;
        private Label currentSongs;
        private Label idLabel;
        private Label songNameLabel;
        private Label songTypeLabel;
        private Label artistLabel;
        private Button insertBttn;
        private Button updateBttn;
        private Button deleteBttn;
        private TextBox songIdTextBox;
        private TextBox songNameTextBox;
        private TextBox songTypeTextBox;
        private TextBox artistTextBox;
        private TextBox albumTextBox;
        private Label albumLabel;
    }
}