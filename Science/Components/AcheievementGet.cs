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
    public partial class AcheievementGet : UserControl
    {
        public AcheievementGet(Achievement get)
        {            
            InitializeComponent();
            if(!string.IsNullOrEmpty(get.ResourceName))
                this.pictureBox1.Image = new Bitmap(
                    System.Reflection.Assembly.GetEntryAssembly().
                        GetManifestResourceStream("Properties.Resources." + get.ResourceName));
            this.lblTitle.Text = get.Title;
            if (!get.Unlocked)
            {
                this.label1.Text = "Achievement progress!";
            }
            this.Visible = false;
        }

        public void Animate()
        {
            this.Left = (Parent.Width - this.Width) / 2;
            this.Top = -this.Height;
            this.Visible = true;
            this.Parent.Controls.SetChildIndex(this, 0);
            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(() => {
                try
                {
                    while (this.Top < -1)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.Top += 1;
                            this.Refresh();
                        }));
                        System.Threading.Thread.Sleep(10);
                    }
                    System.Threading.Thread.Sleep(2000);
                    while (this.Top > -this.Height)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.Top -= 1;
                            this.Refresh();
                        }));
                        System.Threading.Thread.Sleep(10);
                    }
                    this.Invoke(new Action(() =>
                    {
                        this.Visible = false;
                        this.Parent.Controls.Remove(this);
                        this.Dispose();
                    }));
                }
                catch (InvalidOperationException)
                {
                }
            }));
            T.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(
                new Pen(
                    new SolidBrush(colorBorder),2), 
                    this.DisplayRectangle);
        }

        public Color colorBorder = Color.Black;
    }
}
