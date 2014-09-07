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
    public partial class VectorInputControl : UserControl
    {
        private static List<VectorInputControl> VectorsControls;
        private static List<Color> AvailableColors = new List<Color>(){
                                                         Color.Blue, Color.Red, Color.Green, Color.Gold, Color.Brown, Color.Purple, Color.LightBlue, Color.Orange
                                                     };

        public VectorInputControl()
        {
            InitializeComponent();            
            this.BorderColor = AvailableColors[0];
            AvailableColors.RemoveAt(0);
            if (AvailableColors.Count == 0)
            {
                Achievement.Trigger("Vector Virtuoso");
                this.HideNew();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen p = new Pen(BorderColor, 0.1F))
            {
                Rectangle R = new Rectangle(DisplayRectangle.X, DisplayRectangle.Y, DisplayRectangle.Width - 1, DisplayRectangle.Height - 1);
                e.Graphics.DrawRectangle(p, R);
            }
        }    

        private double rad(double deg)
        {
            return (TrigProblem.PI / 180) * deg;
        }

        public Vector3 getVector()
        {
            double angle = Physics.ParseDouble(txtAngle.Text);
            double magnitude = Physics.ParseDouble(txtMagnitude.Text);

            Vector3 john = new Vector3(); //His name is John.

            if (angle < 90)
            {
                john = new Vector3(Math.Cos(rad(angle)) * magnitude, Math.Sin(rad(angle)) * magnitude, 0);
            }
            if (angle >= 90 && angle < 180)
            {
                john = new Vector3(Math.Sin(rad(angle- 90)) * -magnitude, Math.Cos(rad(angle- 90)) * magnitude, 0);
            }
            if (angle >= 180 && angle < 270)
            {
                john = new Vector3(Math.Cos(rad(angle - 180)) * -magnitude, Math.Sin(rad(angle - 180)) * -magnitude, 0);
            }
            if (angle >= 270 && angle < 360)
            {
                john = new Vector3(Math.Sin(rad(angle - 270)) * magnitude, Math.Cos(rad(angle - 270)) * -magnitude, 0);
            }
            else if (angle >= 360)
            {
                Achievement.Trigger("That's no moon!");                
            }
            john.Color = BorderColor.ToArgb();
            return john;
        }

        public Color BorderColor = Color.LightBlue;

        public void ShowNew()
        {
            this.Width = 246;
            arbitraryImage1.Visible = true;
        }

        public void HideNew()
        {
            this.Width = 219;
            arbitraryImage1.Visible = false;
        }

        private void arbitraryImage1_Click(object sender, EventArgs e)
        {
            HideNew();
            VectorInputControl Control = new VectorInputControl();
            this.Parent.Controls.Add(Control);
        }

        private void arbitraryImage2_Click(object sender, EventArgs e)
        {
            Control Parent = this.Parent;
            if (Parent.Controls.IndexOf(this) == Parent.Controls.Count - 1)
            {
                ((VectorInputControl)Parent.Controls[Parent.Controls.IndexOf(this) - 1]).ShowNew();
                ((VectorInputControl)Parent.Controls[Parent.Controls.IndexOf(this) - 1]).Refresh();
            }
            this.Parent.Controls.Remove(this);
            bool wasempty = AvailableColors.Count == 0;
            AvailableColors.Add(this.BorderColor);
            if (AvailableColors.Count > 0 && wasempty)
            {
                ((VectorInputControl)Parent.Controls[Parent.Controls.Count - 1]).ShowNew();

                ((VectorInputControl)Parent.Controls[Parent.Controls.Count - 1]).Refresh();
            }
            this.Dispose();
        }

        private void VectorInputControl_Load(object sender, EventArgs e)
        {
            if (Parent.Controls.IndexOf(this) == 0)
            {
                this.arbitraryImage2.Visible = false;
            }
        }

        private void txtMagnitude_TextChanged(object sender, EventArgs e)
        {
            this.Parent.Refresh();
        }

        private void txtAngle_TextChanged(object sender, EventArgs e)
        {
            this.Parent.Refresh();
        }
    }
}
