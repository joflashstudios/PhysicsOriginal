using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using W3b.Sine;

namespace Science
{
    public partial class ProgramForm : Form
    {
        public ProgramForm()
        {
            InitializeComponent();

            Pages.Add("Launcher", launcherControl1);
            Pages.Add("Trig", new TrigControl());
            Pages.Add("Vectors", new VectorControl());
            Pages.Add("Settings", new SettingsControl());
            ActivePage = launcherControl1;

            Achievement.F = this;
        }

        public void DisplayAchievement(Achievement get)
        {
            AcheievementGet control = new AcheievementGet(get);
            this.Controls.Add(control);
            control.Animate();
        }

        public void SwitchPage(string target)
        {
            SwitchPage(Pages[target]);
        }

        public void SwitchPage(Page target)
        {
            target.Visible = false;
            this.Controls.Add(target);
            ActivePage.Visible = false;

            SwitchToSize(target.Size);

            target.Visible = true;
            this.Controls.Remove(ActivePage);

            ActivePage = target;
        }

        private void SwitchToSize(Size target)
        {
            this.MaximumSize = new Size(0, 0);
            this.MinimumSize = new Size(0, 0);

            double Xincrement = (double)(target.Width - this.Size.Width) / 50D;
            double Yincrement = (double)(target.Height - this.Size.Height) / 50D;
            double ActualX = this.ClientRectangle.Width;
            double ActualY = this.ClientRectangle.Height;

            double ActualTop = this.Top;
            double ActualLeft = this.Left;
            if (ActivePage.Size != target)
            {
                DateTime lastLoop = DateTime.Now;
                for (int i = 0; i < 50; i++)
                {
                    ActualX += Xincrement;
                    ActualY += Yincrement;
                    ActualLeft -= Xincrement / 2;
                    ActualTop -= Yincrement / 2;
                    this.Left = (int)ActualLeft;
                    this.Top = (int)ActualTop;
                    this.ClientSize = new Size((int)ActualX, (int)ActualY);
                    this.Refresh();
                }
            }

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void ProgramForm_Load(object sender, EventArgs e)
        {
            SwitchPage("Launcher");
        }

        private void arbitraryButton1_Click(object sender, EventArgs e)
        {
            dying = true;
            //int startHeight = this.Height / 2;
            //int lastHeight = startHeight;
            //int startTop = this.Top;

            for (double d = 1; d > 0; d -= 0.1)
            {
                //int change = (int)(startHeight * (1 - d));
                //this.Height = startHeight - change;
                
                //if(this.Height != lastHeight)
                //    this.Top = startTop + (int)((double)change / 1.5);

                //lastHeight = this.Height;
                this.Opacity = d;
                this.Refresh();
                System.Threading.Thread.Sleep(10);
            }
            this.Close();
        }

        private void arbitraryButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        bool dying;

        protected override CreateParams CreateParams {get 
        {
            if (dying)
            {
                var S = base.CreateParams;
                S.Style = S.Style & ~0xc00000;
                return S;
            }
            else
            {
                var S = base.CreateParams;
                S.Style = S.Style & 0x800000;
                return S;
            }
        }}

        private void ProgramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Achievement.Save();
        }

        private void ProgramForm_Load_1(object sender, EventArgs e)
        {
            Physics.AppSettings = new Settings();
            BigNumDec._divisionDigits = 100;
        }

        public Dictionary<string, Page> Pages = new Dictionary<string, Page>();
        public Page ActivePage { get; set; }
    }
}
