using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Science
{
    class ArbitraryImage : PictureBox
    {
        public Boolean DownOnHover { get; set; }
        public Boolean NoHover { get; set; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (ClientRectangle.Contains(PointToClient(Control.MousePosition)) && !NoHover)
            {
                var Color = BackColor.ToArgb();

                OnPaint(pevent, AdjustBrightness(this.BackColor, DownOnHover ? 0.93F : 1.1F));
            }
            else
            {
                OnPaint(pevent, BackColor);
            }
        }

        protected void OnPaint(PaintEventArgs pevent, Color EffectiveBackColor)
        {
            using (Pen p = new Pen(BorderColor))
            {
                pevent.Graphics.FillRectangle(p.Brush, this.DisplayRectangle);
            }

            using (Pen p = new Pen(EffectiveBackColor))
            {
                Rectangle Smaller = new Rectangle(this.DisplayRectangle.X + 1, this.DisplayRectangle.Y + 1, this.DisplayRectangle.Width - 2, this.DisplayRectangle.Height - 2);
                pevent.Graphics.FillRectangle(p.Brush, Smaller);
            }

            if (this.Image != null)
            {
                pevent.Graphics.DrawImage(new Bitmap(this.Image), ImagePoint); 
            }
        }

        public Color BorderColor { get; set; }

        public Point ImagePoint { get; set; }

        Color AdjustBrightness(Color c1, float factor)
        {

            float r = ((c1.R * factor) > 255) ? 255 : (c1.R * factor);
            float g = ((c1.G * factor) > 255) ? 255 : (c1.G * factor);
            float b = ((c1.B * factor) > 255) ? 255 : (c1.B * factor);

            Color c = Color.FromArgb(c1.A, (int)r, (int)g, (int)b);
            return c;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            OnPaint(new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle));
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            OnPaint(new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle));
            base.OnMouseEnter(e);
        }
    }
}
