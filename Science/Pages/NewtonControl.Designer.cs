namespace Science
{
    partial class NewtonControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.miniNavControl1 = new Science.MiniNavControl();
            this.arbitraryButton1 = new Science.ArbitraryButton();
            this.arbitraryButton2 = new Science.ArbitraryButton();
            this.arbitraryButton3 = new Science.ArbitraryButton();
            this.SuspendLayout();
            // 
            // miniNavControl1
            // 
            this.miniNavControl1.BackColor = System.Drawing.SystemColors.Control;
            this.miniNavControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miniNavControl1.Location = new System.Drawing.Point(-1, -1);
            this.miniNavControl1.Name = "miniNavControl1";
            this.miniNavControl1.Size = new System.Drawing.Size(143, 405);
            this.miniNavControl1.TabIndex = 0;
            // 
            // arbitraryButton1
            // 
            this.arbitraryButton1.DisableHover = false;
            this.arbitraryButton1.DownOnHover = false;
            this.arbitraryButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arbitraryButton1.Location = new System.Drawing.Point(149, 10);
            this.arbitraryButton1.Name = "arbitraryButton1";
            this.arbitraryButton1.NoBorder = false;
            this.arbitraryButton1.Size = new System.Drawing.Size(88, 25);
            this.arbitraryButton1.TabIndex = 1;
            this.arbitraryButton1.Text = "Basic Motion";
            this.arbitraryButton1.TextPoint = new System.Drawing.Point(2, 3);
            this.arbitraryButton1.UseVisualStyleBackColor = true;
            this.arbitraryButton1.Click += new System.EventHandler(this.arbitraryButton1_Click);
            // 
            // arbitraryButton2
            // 
            this.arbitraryButton2.DisableHover = false;
            this.arbitraryButton2.DownOnHover = false;
            this.arbitraryButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arbitraryButton2.Location = new System.Drawing.Point(236, 10);
            this.arbitraryButton2.Name = "arbitraryButton2";
            this.arbitraryButton2.NoBorder = false;
            this.arbitraryButton2.Size = new System.Drawing.Size(51, 25);
            this.arbitraryButton2.TabIndex = 2;
            this.arbitraryButton2.Text = "Energy";
            this.arbitraryButton2.TextPoint = new System.Drawing.Point(2, 3);
            this.arbitraryButton2.UseVisualStyleBackColor = true;
            // 
            // arbitraryButton3
            // 
            this.arbitraryButton3.DisableHover = false;
            this.arbitraryButton3.DownOnHover = false;
            this.arbitraryButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arbitraryButton3.Location = new System.Drawing.Point(286, 10);
            this.arbitraryButton3.Name = "arbitraryButton3";
            this.arbitraryButton3.NoBorder = false;
            this.arbitraryButton3.Size = new System.Drawing.Size(55, 25);
            this.arbitraryButton3.TabIndex = 3;
            this.arbitraryButton3.Text = "Gravity";
            this.arbitraryButton3.TextPoint = new System.Drawing.Point(2, 3);
            this.arbitraryButton3.UseVisualStyleBackColor = true;
            // 
            // NewtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.arbitraryButton3);
            this.Controls.Add(this.arbitraryButton2);
            this.Controls.Add(this.arbitraryButton1);
            this.Controls.Add(this.miniNavControl1);
            this.Name = "NewtonControl";
            this.Size = new System.Drawing.Size(662, 370);
            this.Load += new System.EventHandler(this.NewtonControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MiniNavControl miniNavControl1;
        private ArbitraryButton arbitraryButton1;
        private ArbitraryButton arbitraryButton2;
        private ArbitraryButton arbitraryButton3;
    }
}
