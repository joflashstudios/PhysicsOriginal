using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;

namespace Science
{
    class QuadrantSelector : Control
    {
        public QuadrantSelector()
        {
            ActiveQuadrant = Quadrant.First;
            BackColor = SystemColors.Control;
            ActiveColor = Color.FromArgb(40, 80, 255);
            HoverColor = Color.FromArgb(80, 160, 255);
            AxisColor = Color.FromArgb(60, 60, 60);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            DrawBackground(pevent.Graphics);
            DrawQuadrants(pevent.Graphics);
            DrawAxis(pevent.Graphics, new Point(this.Width / 2, this.Height / 2));
        }

        private Timer _MouseTracker;

        protected override void OnMouseEnter(EventArgs e)
        {
            if (_MouseTracker != null)
            {
                _MouseTracker.Stop();
                _MouseTracker.Dispose();
            }

            _MouseTracker = new Timer();
            _MouseTracker.Tick += _MouseTracker_Tick;
            _MouseTracker.Interval = 50;
            _MouseTracker.Start();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point mouse = PointToClient(Control.MousePosition);

            if (ClientRectangle.Contains(mouse))
            {
                ActiveQuadrant = GetQuadrant(mouse);
                Invalidate();
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_MouseTracker != null)
            {
                _MouseTracker.Stop();
                _MouseTracker.Dispose();
            }

            if (_LastHover != ActiveQuadrant)
            {
                Graphics graphics = CreateGraphics();
                PaintQuadrant(graphics, new SolidBrush(BackColor), _LastHover);
                graphics.Dispose();
            }
        }

        private void _MouseTracker_Tick(object sender, EventArgs e)
        {
            Point mouse = PointToClient(Control.MousePosition);

            if (ClientRectangle.Contains(mouse))
            {
                Quadrant current = GetQuadrant(mouse);
                if (_LastHover != current)
                {
                    Graphics graphics = CreateGraphics();

                    if (current != ActiveQuadrant)
                    {
                        PaintQuadrant(graphics, new SolidBrush(HoverColor), current);
                    }

                    if (_LastHover != ActiveQuadrant)
                    {
                        PaintQuadrant(graphics, new SolidBrush(BackColor), _LastHover);
                    }
                    _LastHover = current;
                    graphics.Dispose();
                }
            }
        }

        private Quadrant _LastHover = (Quadrant)(-1);

        private void DrawAxis(Graphics graphics, Point Origin)
        {
            using (Pen p = new Pen(AxisColor, 1))
            {
                graphics.DrawLine(p, new Point(Origin.X, 0), new Point(Origin.X, ClientRectangle.Height));
                graphics.DrawLine(p, new Point(0, Origin.Y), new Point(ClientRectangle.Width, Origin.Y));
            }
        }

        public void DrawBackground(Graphics graphics)
        {
            using (Pen p = new Pen(BackColor))
            {
                graphics.FillRectangle(p.Brush, this.DisplayRectangle);
            }
        }

        public void DrawQuadrants(Graphics graphics)
        {
            Point mouse = PointToClient(Control.MousePosition);

            if (ClientRectangle.Contains(mouse))
            {
                using (Brush b = new SolidBrush(HoverColor))
                {
                    PaintQuadrant(graphics, b, GetQuadrant(mouse));
                }
            }

            using (Brush b = new SolidBrush(ActiveColor))
            {
                PaintQuadrant(graphics, b, ActiveQuadrant);
            }
        }

        public Quadrant GetQuadrant(Point point)
        {
            if (point.X > Width / 2)
            {
                if (point.Y > Height / 2)
                {
                    return Quadrant.Fourth;
                }
                else
                {
                    return Quadrant.First;
                }
            }
            else
            {
                if (point.Y > Height / 2)
                {
                    return Quadrant.Third;
                }
                else
                {
                    return Quadrant.Second;
                }
            }
        }

        public void PaintQuadrant(Graphics graphics, Brush b, Quadrant quadrant)
        {
            switch (quadrant)
            {
                case Quadrant.First:
                {
                    graphics.FillRectangle(b, Width / 2 + 1, 0, Width / 2, Height / 2);
                    break;
                }
                case Quadrant.Second:
                {
                    graphics.FillRectangle(b, 0, 0, Width / 2, Height / 2);
                    break;
                }
                case Quadrant.Third:
                {
                    graphics.FillRectangle(b, 0, Height / 2 + 1, Width / 2, Height / 2);
                    break;
                }
                case Quadrant.Fourth:
                {
                    graphics.FillRectangle(b, Width / 2 + 1, Height / 2 + 1, Width / 2, Height / 2);
                    break;
                }
            }
        }

        public Color ActiveColor { get; set; }
        public Color HoverColor { get; set; }
        public Color AxisColor { get; set; }

        public Quadrant ActiveQuadrant { get; set; }
    }

    public enum Quadrant
    {
        First,
        Second,
        Third,
        Fourth
    }
}
