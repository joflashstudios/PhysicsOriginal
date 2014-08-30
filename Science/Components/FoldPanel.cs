using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Science
{
    class FoldPanel : Panel
    {
        public bool Closed { get; set; }
        public string TextLabel { get; set; }
        public Size OrigonalSize { get; set; }
        private bool suspend { get; set; }

        public event EventHandler ClosedChanged;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Rectangle ClickRectangle = new Rectangle(ClientRectangle.Location, new Size(ClientRectangle.Width, 32));
            if (ClickRectangle.Contains(PointToClient(Control.MousePosition)))
            {
                this.Closed = !this.Closed;
                if (ClosedChanged != null)
                {
                    ClosedChanged(this, new EventArgs());
                }
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Closed)
            {
                suspend = true;
                this.Height = 32;
                suspend = false;
            }
            else
            {
                suspend = true;
                this.Height = OrigonalSize.Height;
                suspend = false;
            }

            base.OnPaint(e);
            using (Pen p = new Pen(ForeColor))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawString((Closed ? "▶  " : "▼   ") + TextLabel, Font, p.Brush, new Point(3, 3));
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
}
