namespace Science
{
    partial class TrigControl
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
            this.rightTrianglePanel1 = new Science.RightTrianglePanel();
            this.SuspendLayout();
            // 
            // miniNavControl1
            // 
            this.miniNavControl1.BackColor = System.Drawing.SystemColors.Control;
            this.miniNavControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miniNavControl1.Location = new System.Drawing.Point(-1, -1);
            this.miniNavControl1.Name = "miniNavControl1";
            this.miniNavControl1.Size = new System.Drawing.Size(143, 405);
            this.miniNavControl1.TabIndex = 27;
            // 
            // rightTrianglePanel1
            // 
            this.rightTrianglePanel1.Location = new System.Drawing.Point(148, 3);
            this.rightTrianglePanel1.Name = "rightTrianglePanel1";
            this.rightTrianglePanel1.Size = new System.Drawing.Size(532, 392);
            this.rightTrianglePanel1.TabIndex = 28;
            this.rightTrianglePanel1.Text = "rightTrianglePanel1";
            // 
            // TrigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rightTrianglePanel1);
            this.Controls.Add(this.miniNavControl1);
            this.Name = "TrigControl";
            this.Size = new System.Drawing.Size(683, 398);
            this.ResumeLayout(false);

        }

        #endregion

        private MiniNavControl miniNavControl1;
        private RightTrianglePanel rightTrianglePanel1;
    }
}
