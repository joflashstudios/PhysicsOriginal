namespace Science
{
    partial class VectorControl
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
            this.vectorPanel1 = new Science.VectorPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.vectorInputControl1 = new Science.VectorInputControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniNavControl1
            // 
            this.miniNavControl1.BackColor = System.Drawing.SystemColors.Control;
            this.miniNavControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miniNavControl1.Location = new System.Drawing.Point(-1, -1);
            this.miniNavControl1.Name = "miniNavControl1";
            this.miniNavControl1.Size = new System.Drawing.Size(143, 556);
            this.miniNavControl1.TabIndex = 0;
            // 
            // vectorPanel1
            // 
            this.vectorPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.vectorPanel1.BorderColor = System.Drawing.SystemColors.Control;
            this.vectorPanel1.Location = new System.Drawing.Point(405, 33);
            this.vectorPanel1.Name = "vectorPanel1";
            this.vectorPanel1.Size = new System.Drawing.Size(415, 375);
            this.vectorPanel1.TabIndex = 1;
            this.vectorPanel1.Text = "vectorPanel1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.vectorInputControl1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(149, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(252, 372);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // vectorInputControl1
            // 
            this.vectorInputControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vectorInputControl1.Location = new System.Drawing.Point(3, 3);
            this.vectorInputControl1.Name = "vectorInputControl1";
            this.vectorInputControl1.Size = new System.Drawing.Size(246, 38);
            this.vectorInputControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vector Sum:";
            // 
            // txtMag
            // 
            this.txtMag.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMag.Location = new System.Drawing.Point(242, 8);
            this.txtMag.Name = "txtMag";
            this.txtMag.ReadOnly = true;
            this.txtMag.Size = new System.Drawing.Size(66, 27);
            this.txtMag.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "∠";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, -14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "⇀";
            // 
            // txtAngle
            // 
            this.txtAngle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngle.Location = new System.Drawing.Point(334, 8);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.ReadOnly = true;
            this.txtAngle.Size = new System.Drawing.Size(65, 27);
            this.txtAngle.TabIndex = 8;
            // 
            // VectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.vectorPanel1);
            this.Controls.Add(this.miniNavControl1);
            this.Controls.Add(this.label3);
            this.Name = "VectorControl";
            this.Size = new System.Drawing.Size(825, 414);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MiniNavControl miniNavControl1;
        private VectorPanel vectorPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private VectorInputControl vectorInputControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAngle;
    }
}
