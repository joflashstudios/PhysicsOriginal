using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Science
{
    public partial class VectorControl : Page
    {
        public VectorControl()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vectorPanel1.Vectors.Add(new Vector3(5, 5, 0) { Color = Color.LightBlue.ToArgb() });
            vectorPanel1.Vectors.Add(new Vector3(-8, 3, 0) {Color = Color.Blue.ToArgb()});
            vectorPanel1.Vectors.Add(new Vector3(12, -6, 0) { Color = Color.Green.ToArgb() });
            vectorPanel1.Vectors.Add(new Vector3(-13, -3, 0) { Color = Color.Orange.ToArgb() });
            vectorPanel1.Vectors.Add(new Vector3(-1, 9, 0) { Color = Color.Purple.ToArgb() });
            vectorPanel1.Refresh();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            vectorPanel1.Vectors.Clear();
            Vector3 sum = new Vector3();
            foreach (Control C in flowLayoutPanel1.Controls)
            {
                VectorInputControl V = (VectorInputControl)C;
                Vector3 vex = V.getVector();
                if (vex != new Vector3(0, 0, 0))
                {
                    vectorPanel1.Vectors.Add(vex);
                    sum += vex;
                }
            }

            if (sum != new Vector3())
            {                
                txtMag.Text = Math.Round(sum.Magnitude, 4).ToString();
                txtAngle.Text = Math.Round(sum.AngleFromX(), 4).ToString();
            }

            vectorPanel1.Refresh();
        }
    }
}
