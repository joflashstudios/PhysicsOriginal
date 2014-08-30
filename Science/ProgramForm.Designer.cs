namespace Science
{
    partial class ProgramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramForm));
            this.arbitraryButton2 = new Science.ArbitraryButton();
            this.arbitraryButton1 = new Science.ArbitraryButton();
            this.launcherControl1 = new Science.LauncherControl();
            this.SuspendLayout();
            // 
            // arbitraryButton2
            // 
            this.arbitraryButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arbitraryButton2.BackColor = System.Drawing.Color.White;
            this.arbitraryButton2.DisableHover = false;
            this.arbitraryButton2.DownOnHover = true;
            this.arbitraryButton2.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arbitraryButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.arbitraryButton2.Location = new System.Drawing.Point(348, -1);
            this.arbitraryButton2.Name = "arbitraryButton2";
            this.arbitraryButton2.NoBorder = false;
            this.arbitraryButton2.Size = new System.Drawing.Size(41, 24);
            this.arbitraryButton2.TabIndex = 2;
            this.arbitraryButton2.Text = "−";
            this.arbitraryButton2.TextPoint = new System.Drawing.Point(8, -7);
            this.arbitraryButton2.UseVisualStyleBackColor = false;
            this.arbitraryButton2.Click += new System.EventHandler(this.arbitraryButton2_Click);
            // 
            // arbitraryButton1
            // 
            this.arbitraryButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arbitraryButton1.BackColor = System.Drawing.Color.Brown;
            this.arbitraryButton1.DisableHover = false;
            this.arbitraryButton1.DownOnHover = false;
            this.arbitraryButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arbitraryButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.arbitraryButton1.Location = new System.Drawing.Point(388, -1);
            this.arbitraryButton1.Name = "arbitraryButton1";
            this.arbitraryButton1.NoBorder = false;
            this.arbitraryButton1.Size = new System.Drawing.Size(48, 24);
            this.arbitraryButton1.TabIndex = 1;
            this.arbitraryButton1.Text = "×";
            this.arbitraryButton1.TextPoint = new System.Drawing.Point(12, -7);
            this.arbitraryButton1.UseVisualStyleBackColor = false;
            this.arbitraryButton1.Click += new System.EventHandler(this.arbitraryButton1_Click);
            // 
            // launcherControl1
            // 
            this.launcherControl1.Location = new System.Drawing.Point(0, 0);
            this.launcherControl1.Name = "launcherControl1";
            this.launcherControl1.Size = new System.Drawing.Size(434, 678);
            this.launcherControl1.TabIndex = 0;
            // 
            // ProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(435, 660);
            this.ControlBox = false;
            this.Controls.Add(this.arbitraryButton2);
            this.Controls.Add(this.arbitraryButton1);
            this.Controls.Add(this.launcherControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgramForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Science!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramForm_FormClosing);
            this.Load += new System.EventHandler(this.ProgramForm_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private LauncherControl launcherControl1;
        private ArbitraryButton arbitraryButton1;
        private ArbitraryButton arbitraryButton2;
    }
}