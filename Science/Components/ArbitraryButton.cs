using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Science
{
    class ArbitraryButton : Button
    {
        public Point TextPoint { get; set; }
        public Boolean DownOnHover { get; set; }
        public Boolean DisableHover { get; set; }

        public Color BorderColor = Color.Black;

        protected override void OnPaint(PaintEventArgs pevent)
        {            
            if(ClientRectangle.Contains(PointToClient(Control.MousePosition)) && !DisableHover)
            {
                var Color = BackColor.ToArgb();

                OnPaint(pevent, AdjustBrightness(this.BackColor, DownOnHover ? 0.93F : 1.1F));                
            }
            else
            {
                OnPaint(pevent, BackColor);
            }
        }

        public bool NoBorder { get; set; }

        protected void OnPaint(PaintEventArgs pevent, Color EffectiveBackColor)
        {
            if (!NoBorder)
            {
                using (Pen p = new Pen(BorderColor))
                {
                    pevent.Graphics.FillRectangle(p.Brush, this.DisplayRectangle);
                }
            }

            using (Pen p = new Pen(EffectiveBackColor))
            {
                Rectangle Smaller = new Rectangle(this.DisplayRectangle.X + 1, this.DisplayRectangle.Y + 1, this.DisplayRectangle.Width - 2, this.DisplayRectangle.Height - 2);
                pevent.Graphics.FillRectangle(p.Brush, Smaller);
            }

            using (Pen p = new Pen(ForeColor))
            {
                pevent.Graphics.DrawString(Text, Font, p.Brush, TextPoint);
            }           
        }

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
