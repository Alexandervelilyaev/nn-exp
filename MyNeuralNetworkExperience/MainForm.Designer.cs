namespace MyNeuralNetworkExperience
{
    partial class MainForm
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
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            saveButton = new Button();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            iterationLabel = new Label();
            epochLabel = new Label();
            nameLabel = new Label();
            createdAtLabel = new Label();
            updatedAtLabel = new Label();
            button1 = new Button();
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1184, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(103, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1141, 570);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(12, 630);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // iterationLabel
            // 
            iterationLabel.AutoSize = true;
            iterationLabel.Location = new Point(1052, 33);
            iterationLabel.Name = "iterationLabel";
            iterationLabel.Size = new Size(57, 15);
            iterationLabel.TabIndex = 3;
            iterationLabel.Text = "Iteration: ";
            // 
            // epochLabel
            // 
            epochLabel.AutoSize = true;
            epochLabel.Location = new Point(872, 33);
            epochLabel.Name = "epochLabel";
            epochLabel.Size = new Size(46, 15);
            epochLabel.TabIndex = 4;
            epochLabel.Text = "Epoch: ";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 33);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(45, 15);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Name: ";
            // 
            // createdAtLabel
            // 
            createdAtLabel.AutoSize = true;
            createdAtLabel.Location = new Point(344, 33);
            createdAtLabel.Name = "createdAtLabel";
            createdAtLabel.Size = new Size(66, 15);
            createdAtLabel.TabIndex = 6;
            createdAtLabel.Text = "Created At:";
            // 
            // updatedAtLabel
            // 
            updatedAtLabel.AutoSize = true;
            updatedAtLabel.Location = new Point(545, 33);
            updatedAtLabel.Name = "updatedAtLabel";
            updatedAtLabel.Size = new Size(70, 15);
            updatedAtLabel.TabIndex = 7;
            updatedAtLabel.Text = "Updated At:";
            // 
            // button1
            // 
            button1.Location = new Point(349, 629);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(button1);
            Controls.Add(updatedAtLabel);
            Controls.Add(createdAtLabel);
            Controls.Add(nameLabel);
            Controls.Add(epochLabel);
            Controls.Add(iterationLabel);
            Controls.Add(saveButton);
            Controls.Add(pictureBox1);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = mainMenuStrip;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "NN Experience";
            Load += MainForm_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private PictureBox pictureBox1;
        private Button saveButton;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Label iterationLabel;
        private Label epochLabel;
        private Label nameLabel;
        private Label createdAtLabel;
        private Label updatedAtLabel;
        private Button button1;
    }
}