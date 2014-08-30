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
            Controls.Add(Selector);

            Coords = new Tuple<Coord, Coord, Coord>(
                new Coord(0, 0),
                new Coord(1, 0),
                new Coord(1, 1)
            );
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Tuple<Coord, Coord, Coord> Coords { get; set; }

        private QuadrantSelector Selector;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //Check for line clicks
            base.OnMouseClick(e);
        }
    }

    public class Coord
    {
        public Coord()
        {
        }

        public Coord(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
