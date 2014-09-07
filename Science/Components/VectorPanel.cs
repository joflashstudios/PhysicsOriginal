using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;

namespace Science
{
    class VectorPanel : Control
    {
        public VectorPanel()
        {
            this.Vectors = new List<Vector3>();
        }

        public List<Vector3> Vectors;

        public bool snapped;
        private Form snapform;

        protected override void OnClick(EventArgs e)
        {
            if (!snapped)
            {
                snapform = new Form();
                snapform.FormBorderStyle = FormBorderStyle.None;
                snapform.WindowState = FormWindowState.Maximized;
                snapform.TopMost = true;
                VectorPanel P = new VectorPanel();
                P.Dock = DockStyle.Fill;
                P.Vectors = this.Vectors;
                P.snapped = true;
                P.BackColor = Color.White;
                snapform.Controls.Add(P);
                P.KeyDown += new KeyEventHandler((object sender, KeyEventArgs args) => { 
                    ((Form)((Control)sender).Parent).Close(); 
                });
                snapform.Show();
                snapform.Focus();
            }
            else
            {
                ((Form)this.Parent).Close();
            }
            base.OnClick(e);
        }

        public Color BorderColor { get; set; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawFrame(pevent);

            Point Origin = new Point(ClientRectangle.Width / 2, ClientRectangle.Height / 2);           
            DrawAxis(pevent, Origin);

            DrawVectors(pevent, Origin);
        }

        private void DrawVectors(PaintEventArgs pevent, Point Origin)
        {
            if (Vectors.Count > 0)
            {
                Vector3 Sum = new Vector3(0, 0, 0);
                Vector3 Max = new Vector3(0, 0, 0);

                var sorted = this.Vectors.OrderBy(n => n.Magnitude);

                foreach (Vector3 vector in sorted)
                {
                    Sum = Sum + vector;
                    Max = Vector3.Max(vector, Max); //Is the current vector greater than the max?
                    Max = Vector3.Max(vector, Sum); //Is the sum greater than the max?
                }
                double xratio = ((ClientRectangle.Width - 4) / 2) / Math.Abs(Max.X);
                double yratior = ((ClientRectangle.Height - 4) / 2) / Math.Abs(Max.Y);

                double ratio = Math.Min(xratio, yratior);

                Rectangle ArcRec = DrawVectorSet(pevent, Origin, sorted, ratio);

                DrawSum(pevent, ref Sum, ref Origin, ratio, ref ArcRec);
            }
        }

        private void DrawFrame(PaintEventArgs pevent)
        {
            using (Pen p = new Pen(BorderColor))
            {
                pevent.Graphics.FillRectangle(p.Brush, this.DisplayRectangle);
            }

            using (Pen p = new Pen(BackColor))
            {
                Rectangle Smaller = new Rectangle(this.DisplayRectangle.X + 1, this.DisplayRectangle.Y + 1, this.DisplayRectangle.Width - 2, this.DisplayRectangle.Height - 2);
                pevent.Graphics.FillRectangle(p.Brush, Smaller);
            }
        }

        private static void DrawSum(PaintEventArgs pevent, ref Vector3 Sum, ref Point Origin, double ratio, ref Rectangle ArcRec)
        {
            using (Pen p = new Pen(Color.Black, 3))
            {
                Point effectivePoint = new Point(Origin.X + (int)(Sum.X * ratio), Origin.Y - (int)(Sum.Y * ratio));
                pevent.Graphics.DrawLine(p, Origin, effectivePoint);
            }

            using (Pen p = new Pen(Color.Black, 2))
            {
                ArcRec = new Rectangle(ArcRec.X - 5, ArcRec.Y - 5, ArcRec.Width + 10, ArcRec.Height + 10);
                float sweep = (float)Sum.AngleFromX();
                pevent.Graphics.DrawArc(p, ArcRec, 0, -sweep);
            }
        }

        private static Rectangle DrawVectorSet(PaintEventArgs pevent, Point Origin, IOrderedEnumerable<Vector3> sorted, double ratio)
        {
            Rectangle ArcRec = new Rectangle(Origin.X - 5, Origin.Y - 5, 10, 10);

            foreach (Vector3 vector in sorted)
            {
                using (Pen p = new Pen(Color.FromArgb(vector.Color), 1))
                {
                    //Bump up ArcRect by 5 px radius
                    ArcRec = new Rectangle(ArcRec.X - 5, ArcRec.Y - 5, ArcRec.Width + 10, ArcRec.Height + 10);
                    float sweep = (float)vector.Angle(new Vector3(1, 0, 0)) * 57.2957795F;
                    if (vector.Y < 0)
                    {
                        sweep = 180 + (180 - sweep);
                    }
                    pevent.Graphics.DrawArc(p, ArcRec, 0, -sweep);
                }
            }

            foreach (Vector3 vector in sorted)
            {
                using (Pen p = new Pen(Color.FromArgb(vector.Color), 2))
                {
                    Point effectivePoint = new Point(Origin.X + (int)(vector.X * ratio), Origin.Y - (int)(vector.Y * ratio));
                    pevent.Graphics.DrawLine(p, Origin, effectivePoint);
                }
            }
            return ArcRec;
        }

        private void DrawAxis(PaintEventArgs pevent, Point Origin)
        {
            using (Pen p = new Pen(Color.Gray, 1))
            {
                pevent.Graphics.DrawLine(p, new Point(Origin.X, 0), new Point(Origin.X, ClientRectangle.Height));
                pevent.Graphics.DrawLine(p, new Point(0, Origin.Y), new Point(ClientRectangle.Width, Origin.Y));
            }            
        }
    }
}
