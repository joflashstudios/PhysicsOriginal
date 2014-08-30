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
            this.lblClear = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblThetaTwo = new System.Windows.Forms.Label();
            this.lblThetaOne = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtThetaTwo = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtThetaOne = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.miniNavControl1 = new Science.MiniNavControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Location = new System.Drawing.Point(154, 38);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(57, 13);
            this.lblClear.TabIndex = 26;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "Clear Form";
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 26);
            this.label5.TabIndex = 25;
            this.label5.Text = "Enter known values.\nUnknown values will be computed.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(313, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 27);
            this.label3.TabIndex = 24;
            this.label3.Text = "C=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 27);
            this.label2.TabIndex = 23;
            this.label2.Text = "Β=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(609, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 27);
            this.label1.TabIndex = 22;
            this.label1.Text = "Α=";
            // 
            // lblThetaTwo
            // 
            this.lblThetaTwo.AutoSize = true;
            this.lblThetaTwo.BackColor = System.Drawing.Color.Transparent;
            this.lblThetaTwo.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThetaTwo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThetaTwo.Location = new System.Drawing.Point(515, 52);
            this.lblThetaTwo.Name = "lblThetaTwo";
            this.lblThetaTwo.Size = new System.Drawing.Size(54, 32);
            this.lblThetaTwo.TabIndex = 21;
            this.lblThetaTwo.Text = "θ₂=";
            // 
            // lblThetaOne
            // 
            this.lblThetaOne.AutoSize = true;
            this.lblThetaOne.BackColor = System.Drawing.Color.Transparent;
            this.lblThetaOne.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThetaOne.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThetaOne.Location = new System.Drawing.Point(230, 287);
            this.lblThetaOne.Name = "lblThetaOne";
            this.lblThetaOne.Size = new System.Drawing.Size(54, 32);
            this.lblThetaOne.TabIndex = 20;
            this.lblThetaOne.Text = "θ₁=";
            // 
            // txtC
            // 
            this.txtC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(296, 139);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(82, 26);
            this.txtC.TabIndex = 19;
            this.txtC.TextChanged += new System.EventHandler(this.trigChanged);
            // 
            // txtB
            // 
            this.txtB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(352, 364);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(82, 26);
            this.txtB.TabIndex = 18;
            this.txtB.TextChanged += new System.EventHandler(this.trigChanged);
            // 
            // txtThetaTwo
            // 
            this.txtThetaTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThetaTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThetaTwo.Location = new System.Drawing.Point(499, 87);
            this.txtThetaTwo.Name = "txtThetaTwo";
            this.txtThetaTwo.Size = new System.Drawing.Size(82, 26);
            this.txtThetaTwo.TabIndex = 17;
            this.txtThetaTwo.TextChanged += new System.EventHandler(this.trigChanged);
            // 
            // txtA
            // 
            this.txtA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(594, 169);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(82, 26);
            this.txtA.TabIndex = 16;
            this.txtA.TextChanged += new System.EventHandler(this.trigChanged);
            // 
            // txtThetaOne
            // 
            this.txtThetaOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThetaOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThetaOne.Location = new System.Drawing.Point(214, 322);
            this.txtThetaOne.Name = "txtThetaOne";
            this.txtThetaOne.Size = new System.Drawing.Size(82, 26);
            this.txtThetaOne.TabIndex = 15;
            this.txtThetaOne.TextChanged += new System.EventHandler(this.trigChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Science.Properties.Resources.trig;
            this.pictureBox1.Location = new System.Drawing.Point(142, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(447, 356);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
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
            // TrigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.miniNavControl1);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblThetaTwo);
            this.Controls.Add(this.lblThetaOne);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtThetaTwo);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtThetaOne);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TrigControl";
            this.Size = new System.Drawing.Size(683, 398);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThetaTwo;
        private System.Windows.Forms.Label lblThetaOne;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtThetaTwo;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtThetaOne;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MiniNavControl miniNavControl1;
    }
}
