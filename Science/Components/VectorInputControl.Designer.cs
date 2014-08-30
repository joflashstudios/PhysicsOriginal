namespace Science
{
    partial class VectorInputControl
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
            this.txtMagnitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.arbitraryImage1 = new Science.ArbitraryImage();
            this.arbitraryImage2 = new Science.ArbitraryImage();
            ((System.ComponentModel.ISupportInitialize)(this.arbitraryImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbitraryImage2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMagnitude
            // 
            this.txtMagnitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMagnitude.Location = new System.Drawing.Point(4, 8);
            this.txtMagnitude.Name = "txtMagnitude";
            this.txtMagnitude.Size = new System.Drawing.Size(75, 26);
            this.txtMagnitude.TabIndex = 1;
            this.txtMagnitude.TextChanged += new System.EventHandler(this.txtMagnitude_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "∠";
            // 
            // txtAngle
            // 
            this.txtAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngle.Location = new System.Drawing.Point(110, 7);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(75, 26);
            this.txtAngle.TabIndex = 3;
            this.txtAngle.TextChanged += new System.EventHandler(this.txtAngle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, -13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "⇀";
            // 
            // arbitraryImage1
            // 
            this.arbitraryImage1.BorderColor = System.Drawing.SystemColors.Control;
            this.arbitraryImage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arbitraryImage1.DownOnHover = true;
            this.arbitraryImage1.Image = global::Science.Properties.Resources.plus1;
            this.arbitraryImage1.ImagePoint = new System.Drawing.Point(0, 0);
            this.arbitraryImage1.Location = new System.Drawing.Point(219, 7);
            this.arbitraryImage1.Name = "arbitraryImage1";
            this.arbitraryImage1.NoHover = true;
            this.arbitraryImage1.Size = new System.Drawing.Size(24, 24);
            this.arbitraryImage1.TabIndex = 6;
            this.arbitraryImage1.TabStop = false;
            this.arbitraryImage1.Click += new System.EventHandler(this.arbitraryImage1_Click);
            // 
            // arbitraryImage2
            // 
            this.arbitraryImage2.BorderColor = System.Drawing.SystemColors.Control;
            this.arbitraryImage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arbitraryImage2.DownOnHover = true;
            this.arbitraryImage2.Image = global::Science.Properties.Resources.x1;
            this.arbitraryImage2.ImagePoint = new System.Drawing.Point(0, 0);
            this.arbitraryImage2.Location = new System.Drawing.Point(191, 7);
            this.arbitraryImage2.Name = "arbitraryImage2";
            this.arbitraryImage2.NoHover = true;
            this.arbitraryImage2.Size = new System.Drawing.Size(24, 24);
            this.arbitraryImage2.TabIndex = 5;
            this.arbitraryImage2.TabStop = false;
            this.arbitraryImage2.Click += new System.EventHandler(this.arbitraryImage2_Click);
            // 
            // VectorInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.arbitraryImage1);
            this.Controls.Add(this.arbitraryImage2);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMagnitude);
            this.Controls.Add(this.label1);
            this.Name = "VectorInputControl";
            this.Size = new System.Drawing.Size(246, 38);
            this.Load += new System.EventHandler(this.VectorInputControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.arbitraryImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbitraryImage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMagnitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAngle;
        private ArbitraryImage arbitraryImage2;
        private ArbitraryImage arbitraryImage1;
        private System.Windows.Forms.Label label1;

    }
}
