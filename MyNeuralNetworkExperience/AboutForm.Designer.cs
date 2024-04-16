namespace MyNeuralNetworkExperience
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            okButton = new Button();
            titleLabel = new Label();
            versionLabel = new Label();
            authorLabel = new Label();
            contactLabel = new Label();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Location = new Point(19, 155);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(84, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(220, 21);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Neural Network Experience";
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Location = new Point(49, 58);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(45, 15);
            versionLabel.TabIndex = 2;
            versionLabel.Text = "Version";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(49, 86);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(151, 15);
            authorLabel.TabIndex = 3;
            authorLabel.Text = "Author: Alexander Velilyaev";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Location = new Point(49, 115);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new Size(219, 15);
            contactLabel.TabIndex = 4;
            contactLabel.Text = "Contact: alexandervelilyaev@gmail.com";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 190);
            Controls.Add(contactLabel);
            Controls.Add(authorLabel);
            Controls.Add(versionLabel);
            Controls.Add(titleLabel);
            Controls.Add(okButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AboutForm";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private Label titleLabel;
        private Label versionLabel;
        private Label authorLabel;
        private Label contactLabel;
    }
}