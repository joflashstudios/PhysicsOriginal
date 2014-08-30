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
            launcherControl1.Active = true;
            launcherControl1.Name = "Launcher";

            Pages.Add(this.launcherControl1);
            Pages.Add(new TrigControl() { Name = "Trig" });
            Pages.Add(new VectorControl() { Name = "Vectors" });
            Pages.Add(new NewtonControl() { Name = "Newton" });
            Pages.Add(new SettingsControl() { Name = "Settings" });
            Pages.Add(new Liberty() { Name = "Liberty" });
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
            Page OldPage = null;
            Page NewPage = null;
            foreach (Page P in this.Pages)
            {
                if (P.Active)
                    OldPage = P;
                if (P.Name == target)
                    NewPage = P;
            }
            DoPageSwitch(OldPage, NewPage);
            ActivePage = NewPage.Name;
        }

        public string ActivePage { get; set; }

        private void DoPageSwitch(Page OldPage, Page NewPage)
        {
            this.MaximumSize = new Size(0, 0);
            this.MinimumSize = new Size(0, 0);
            if (OldPage != null)
            {
                this.Controls.Remove(OldPage);
            }

            this.Controls.Add(NewPage);
            NewPage.Visible = false;

            double Xincrement = (double)(NewPage.Width - this.Size.Width) / 30D;
            double Yincrement = (double)(NewPage.Height - this.Size.Height) / 30D;
            double ActualX = this.ClientRectangle.Width;
            double ActualY = this.ClientRectangle.Height;

            double ActualTop = this.Top;
            double ActualLeft = this.Left;
            if (OldPage != null && OldPage.Size != NewPage.Size)
            {
                for (int i = 0; i < 30; i++)
                {
                    ActualX += Xincrement;
                    ActualY += Yincrement;
                    ActualLeft -= Xincrement / 2;
                    ActualTop -= Yincrement / 2;
                    this.Left = (int)ActualLeft;
                    this.Top = (int)ActualTop;
                    Size thing = new Size((int)ActualX, (int)ActualY);
                    this.ClientSize = thing;
                    this.Refresh();
                    System.Threading.Thread.Sleep(3);
                }
            }

            NewPage.Visible = true;
            NewPage.Active = true;
            if (OldPage != null)
            {
                OldPage.Visible = false;
                this.Controls.Remove(OldPage);
                OldPage.Active = false;
            }
            if (NewPage.Name == "Liberty")
            {
                ((Liberty)NewPage).Animate();
            }
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        public List<Page> Pages = new List<Page>();

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
    }
}
