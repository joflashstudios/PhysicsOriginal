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
    public partial class NewtonControl : Page
    {
        public NewtonControl()
        {
            InitializeComponent();
        }

        public Point ChildPoint = new Point(133, 34);

        private List<Page> NewtonPages = new List<Page>()
        {
            new NewtonBasic() {Name = "Basic", Active = true}
        };

        private void arbitraryButton1_Click(object sender, EventArgs e)
        {
            Switch("Basic", sender);
        }

        private void Switch(string Title, object sender)
        {
            Page target = null;

            foreach (Page P in NewtonPages)
            {
                if (P.Active)
                {
                    P.Active = false;
                    this.Controls.Remove(P);
                }
                if (P.Name == Title)
                {
                    target = P;
                }
            }

            foreach (Control C in this.Controls)
            {
                if (C is ArbitraryButton)
                {
                    ArbitraryButton B = C as ArbitraryButton;
                    if (B == sender)
                    {
                        B.DisableHover = true;
                        B.BackColor = Color.LightGray;
                    }
                    else
                    {
                        B.DisableHover = false;
                    }
                }
            }

            target.Location = ChildPoint;
            this.Controls.Add(target);
        }

        private void NewtonControl_Load(object sender, EventArgs e)
        {
            Switch("Basic", arbitraryButton1);
        }
    }
}
