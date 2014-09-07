using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.ComponentModel;

namespace Science
{
    class RightTrianglePanel : Control
    {
        public RightTrianglePanel()
        {
            Selector = new QuadrantSelector();
            Selector.Top = 4;
            Selector.Left = 4;
            Selector.Height = Selector.Width = 48;
            Selector.MouseClick += Selector_MouseClick;
            Controls.Add(Selector);

            Triangle = new Triangle(
                new Coord(0, 0),
                new Coord(5, 0),
                new Coord(5, 3)
            );
        }

        void Selector_MouseClick(object sender, MouseEventArgs e)
        {
            GoToQuadrant(Selector.ActiveQuadrant);
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Triangle Triangle { get; set; }

        private QuadrantSelector Selector;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //Check for line clicks
            base.OnMouseClick(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Triangle normals = Normalize(Triangle);

            DrawBackground(pevent.Graphics);
            DrawTheta(pevent.Graphics, normals);
            DrawTriangle(pevent.Graphics, normals);
            DrawText(pevent.Graphics, normals);
        }

        private void DrawBackground(Graphics graphics)
        {
            using (Pen p = new Pen(BackColor))
            {
                graphics.FillRectangle(p.Brush, this.DisplayRectangle);
            }
        }

        private void DrawTriangle(Graphics graphics, Triangle normalizedTriangle)
        {
            Pen side = new Pen(Color.FromArgb(40, 40, 40), 2);
            Pen red = new Pen(Color.Red, 2);

            if (CurrentHover == Hover.Baseline)
                graphics.DrawLine(red, normalizedTriangle.Origin.AsPointF(), normalizedTriangle.Extension.AsPointF());
            else
                graphics.DrawLine(side, normalizedTriangle.Origin.AsPointF(), normalizedTriangle.Extension.AsPointF());

            if (CurrentHover == Hover.Vertical)
                graphics.DrawLine(red, normalizedTriangle.Extension.AsPointF(), normalizedTriangle.Arbitrary.AsPointF());
            else
                graphics.DrawLine(side, normalizedTriangle.Extension.AsPointF(), normalizedTriangle.Arbitrary.AsPointF());

            if (CurrentHover == Hover.Hypotenuse)
                graphics.DrawLine(red, normalizedTriangle.Arbitrary.AsPointF(), normalizedTriangle.Origin.AsPointF());
            else
                graphics.DrawLine(side, normalizedTriangle.Arbitrary.AsPointF(), normalizedTriangle.Origin.AsPointF());

            side.Dispose();
            red.Dispose();
        }

        private void DrawTheta(Graphics graphics, Triangle triangle)
        {
            int radius = (int)MinAbs(30d, triangle.Adjacent, triangle.Opposite);

            Pen arc;
            if (CurrentHover == Hover.Theta)
                arc = new Pen(Color.Red, 2);
            else
                arc = new Pen(Color.FromArgb(40, 40, 40), 2);

            Rectangle arcRect = new Rectangle((int)triangle.Origin.X - radius, (int)triangle.Origin.Y - radius, radius * 2, radius * 2);
            graphics.DrawArc(arc, arcRect, (float)triangle.AxisAngle, (float)triangle.EffectiveTheta);
            arc.Dispose();
        }

        public void DrawText(Graphics graphics, Triangle triangle)
        {
            Brush brush;
            if (CurrentHover == Hover.Theta)
                brush = new SolidBrush(Color.Red);
            else
                brush = new SolidBrush(Color.Black);
            
            string angle = Math.Round(triangle.Theta, 2).ToString() + "°";
            graphics.DrawString(angle, Font, brush, GetThetaPoint(triangle, angle));

            brush.Dispose();
        }

        private PointF GetThetaPoint(Triangle triangle, string angleText)
        {
            Coord point = triangle.Origin.Clone();
            double angle = triangle.AxisAngle + ((-triangle.EffectiveTheta) / 2);
            double radians = angle / (180 / Math.PI);
            point.Y -= Font.SizeInPoints / 1.5;
            if (((int)triangle.ActiveQuadrant & 1) == 1)
            {
                point.X -= (Font.SizeInPoints / 2) * angleText.Length * 1.1;
            }

            Vector3 vector = Vector3.Roll(new Vector3(40, 0, 0), -radians);

            point.Y += vector.Y;
            point.X += vector.X;

            return point.AsPointF();
        }

        private void GoToQuadrant(Quadrant target)
        {
            double maxX = MaxAbs(Triangle.Origin.X, Triangle.Extension.X, Triangle.Arbitrary.X);
            double maxY = MaxAbs(Triangle.Origin.Y, Triangle.Extension.Y, Triangle.Arbitrary.Y);

            bool flipX = ((int)target & 1) != ((int)Triangle.ActiveQuadrant & 1);
            bool flipY = ((int)target & 2) != ((int)Triangle.ActiveQuadrant & 2);

            if (flipX)
            {
                Triangle.Origin.InvertXIn(maxX);
                Triangle.Extension.InvertXIn(maxX);
                Triangle.Arbitrary.InvertXIn(maxX);
            }

            if (flipY)
            {
                Triangle.Origin.InvertYIn(maxY);
                Triangle.Extension.InvertYIn(maxY);
                Triangle.Arbitrary.InvertYIn(maxY);
            }

            Triangle.ActiveQuadrant = target;

            Invalidate();
        }

        //Negative coords are not permitted.
        private Triangle Normalize(Triangle input)
        {
            Triangle norm = input.Clone();

            int effectiveHeight = ClientRectangle.Height - (Padding.Bottom + Padding.Top);
            int effectiveWidth = ClientRectangle.Width - (Padding.Left + Padding.Right + Selector.Width);

            double maxX = MaxAbs(norm.Origin.X, norm.Extension.X, norm.Arbitrary.X);
            double maxY = MaxAbs(norm.Origin.Y, norm.Extension.Y, norm.Arbitrary.Y);

            double ratioX = effectiveWidth / maxX;
            double ratioY = effectiveHeight / maxY;
            double ratio = Math.Min(ratioX, ratioY);

            norm.Origin.ModifyBy(ratio);
            norm.Extension.ModifyBy(ratio);
            norm.Arbitrary.ModifyBy(ratio);

            norm.Origin.InvertYIn(effectiveHeight);
            norm.Extension.InvertYIn(effectiveHeight);
            norm.Arbitrary.InvertYIn(effectiveHeight);

            norm.Origin.X += Selector.Width + Padding.Right;
            norm.Extension.X += Selector.Width + Padding.Right;
            norm.Arbitrary.X += Selector.Width + Padding.Right;

            int topExtra = effectiveHeight - (int)Math.Abs(norm.Origin.Y - norm.Arbitrary.Y);
            topExtra = Math.Max(topExtra, 0);

            norm.Origin.Y += Padding.Top - topExtra;
            norm.Extension.Y += Padding.Top - topExtra;
            norm.Arbitrary.Y += Padding.Top - topExtra;

            return norm;
        }

        private static double MaxAbs(params double[] args)
        {
            double max = double.MinValue;
            foreach (double current in args)
            {
                double abs = Math.Abs(current);
                if (abs > max)
                {
                    max = abs;
                }
            }
            return max;
        }

        private static double MinAbs(params double[] args)
        {
            double min = double.MaxValue;
            foreach (double current in args)
            {
                double abs = Math.Abs(current);
                if (abs < min)
                {
                    min = abs;
                }
            }
            return min;
        }

        private Hover GetHover(Point mouse)
        {
            Triangle normal = Normalize(this.Triangle);
            if (IsInLine(mouse, normal.Origin, normal.Extension))
            {
                return Hover.Baseline;
            }
            else if (IsInLine(mouse, normal.Extension, normal.Arbitrary))
            {
                return Hover.Vertical;
            }
            else if (IsInLine(mouse, normal.Origin, normal.Arbitrary))
            {
                return Hover.Hypotenuse;
            }
            else if (IsInTheta(mouse, normal))
            {
                return Hover.Theta;
            }
            else
            {
                return Hover.None;
            }
        }

        private bool IsInTheta(PointF mouse, Triangle normal)
        {
            PointF thetaPoint = GetThetaPoint(normal, "0");
            if (Math.Abs(mouse.X - thetaPoint.X) < 20 && Math.Abs(mouse.Y - thetaPoint.Y) < 20)
            {
                return true;
            }
            return false;
        }

        private static bool IsInLine(PointF test, PointF lineStart, PointF lineStop)
        {
            if (Math.Abs((test.X - lineStart.X) / (lineStop.X - lineStart.X) - (test.Y - lineStart.Y) / (lineStop.Y - lineStart.Y)) < 0.02)
            {
                return true;
            }
            else if (lineStart.X == lineStop.X)
            {
                return Math.Abs(1 - Math.Abs(1 / (test.X / lineStart.X))) < 0.02 && test.Y < Math.Max(lineStart.Y, lineStop.Y) && test.Y > Math.Min(lineStart.Y, lineStop.Y);
            }
            else if (lineStart.Y == lineStop.Y)
            {
                return Math.Abs(1 - Math.Abs(1 / (test.Y / lineStart.Y))) < 0.02 && test.X < Math.Max(lineStart.X, lineStop.X) && test.X > Math.Min(lineStart.X, lineStop.X);
            }
            else
            {
                return false;
            }
        }

        private static bool IsInLine(PointF test, Coord lineStart, Coord lineStop)
        {
            return IsInLine(test, lineStart.AsPointF(), lineStop.AsPointF());
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

        private Hover CurrentHover;        

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_MouseTracker != null)
            {
                _MouseTracker.Stop();
                _MouseTracker.Dispose();
            }
            CurrentHover = Hover.None;
            Cursor = Cursors.Default;
            UpdateRender(); 
        }

        private void UpdateRender()
        {
            Graphics graphics = CreateGraphics();
            Triangle normal = Normalize(this.Triangle);
            DrawTriangle(graphics, normal);
            DrawTheta(graphics, normal);
            DrawText(graphics, normal);
        }

        private void _MouseTracker_Tick(object sender, EventArgs e)
        {
            Point mouse = PointToClient(Control.MousePosition);

            if (ClientRectangle.Contains(mouse))
            {
                Hover current = GetHover(mouse);
                if (CurrentHover != current)
                {
                    CurrentHover = current;
                    if (CurrentHover == Hover.None)
                    {
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        this.Cursor = Cursors.Hand;
                    }
                    UpdateRender();               
                }
            }
        }


        private enum Hover
        {
            None,
            Baseline,
            Vertical,
            Hypotenuse,
            Theta
        }
    }

    public class Triangle
    {
        public Triangle()
        {
        }

        public Triangle Clone()
        {
            Triangle clone = new Triangle(Origin.Clone(), Extension.Clone(), Arbitrary.Clone());
            clone.ActiveQuadrant = ActiveQuadrant;
            return clone;
        }

        public Triangle(Coord origin, Coord extension, Coord arbitray)
        {
            Origin = origin;
            Extension = extension;
            Arbitrary = arbitray;
        }

        public Coord Origin { get; set; }
        public Coord Extension { get; set; }
        public Coord Arbitrary { get; set; }

        public Quadrant ActiveQuadrant { get; set; }

        public double AxisAngle
        {
            get
            {
                switch (ActiveQuadrant)
                {
                    case Quadrant.First:
                    {
                        return 0;
                    }
                    case Quadrant.Second:
                    {
                        return 180;
                    }
                    case Quadrant.Third:
                    {
                        return 180;
                    }
                    case Quadrant.Fourth:
                    {
                        return 360;
                    }
                    default:
                    {
                        return 0;
                    }
                }
            }
        }

        public double Opposite
        {
            get
            {
                return Math.Abs(Arbitrary.Y - Origin.Y);
            }
        }

        public double Adjacent
        {
            get
            {
                return Math.Abs(Extension.X - Origin.X);
            }
        }

        public double Hypotenuse
        {
            get
            {
                return Math.Sqrt(Adjacent * Adjacent + Opposite * Opposite);
            }
        }

        public double Theta
        {
            get
            {
                return Math.Atan(Math.Abs(Arbitrary.Y - Origin.Y) / Math.Abs(Extension.X - Origin.X)) * (180 / Math.PI);
            }
        }

        public double EffectiveTheta
        {
            get
            {
                if (ActiveQuadrant == Quadrant.Second || ActiveQuadrant == Quadrant.Fourth)
                {
                    return Theta;
                }
                else
                {
                    return -Theta;
                }
            }
        }       
    }

    public class Coord
    {
        public Coord(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void ModifyBy(double multiplier)
        {
            X *= multiplier;
            Y *= multiplier;
        }

        public void InvertYIn(double range)
        {
            Y = range - Y;
        }

        public void InvertXIn(double range)
        {
            X = range - X;
        }

        public void InvertIn(double range)
        {
            InvertXIn(range);
            InvertYIn(range);
        }

        public PointF AsPointF()
        {
            return new PointF((float)X, (float)Y);
        }

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }

        private double x;
        private double y;

        public Coord Clone()
        {
            return new Coord(X, Y);
        }
    }
}
