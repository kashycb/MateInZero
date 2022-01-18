namespace MateInZero
{
    partial class MainMenu
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
            this.mainMenuStartBtn = new System.Windows.Forms.Button();
            this.mainMenuExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenuStartBtn
            // 
            this.mainMenuStartBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainMenuStartBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainMenuStartBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.mainMenuStartBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.mainMenuStartBtn.FlatAppearance.BorderSize = 0;
            this.mainMenuStartBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mainMenuStartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainMenuStartBtn.Location = new System.Drawing.Point(279, 137);
            this.mainMenuStartBtn.Margin = new System.Windows.Forms.Padding(25, 5, 4, 5);
            this.mainMenuStartBtn.Name = "mainMenuStartBtn";
            this.mainMenuStartBtn.Size = new System.Drawing.Size(169, 67);
            this.mainMenuStartBtn.TabIndex = 0;
            this.mainMenuStartBtn.Text = "Begin";
            this.mainMenuStartBtn.UseVisualStyleBackColor = false;
            // 
            // mainMenuExitBtn
            // 
            this.mainMenuExitBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainMenuExitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainMenuExitBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.mainMenuExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.mainMenuExitBtn.FlatAppearance.BorderSize = 0;
            this.mainMenuExitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mainMenuExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainMenuExitBtn.Location = new System.Drawing.Point(279, 217);
            this.mainMenuExitBtn.Margin = new System.Windows.Forms.Padding(25, 5, 4, 5);
            this.mainMenuExitBtn.Name = "mainMenuExitBtn";
            this.mainMenuExitBtn.Size = new System.Drawing.Size(169, 67);
            this.mainMenuExitBtn.TabIndex = 1;
            this.mainMenuExitBtn.Text = "Exit";
            this.mainMenuExitBtn.UseVisualStyleBackColor = false;
            this.mainMenuExitBtn.Click += new System.EventHandler(this.mainMenuExitBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(727, 421);
            this.Controls.Add(this.mainMenuExitBtn);
            this.Controls.Add(this.mainMenuStartBtn);
            this.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainMenu";
            this.Text = "MateInZero";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mainMenuStartBtn;
        private System.Windows.Forms.Button mainMenuExitBtn;
    }
}

