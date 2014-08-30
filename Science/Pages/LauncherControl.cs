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
    public partial class LauncherControl : Page
    {
        public LauncherControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((ProgramForm)(this.Parent)).SwitchPage("Trig");
        }

        private void arbitraryImage1_Click(object sender, EventArgs e)
        {
            ((ProgramForm)(this.Parent)).SwitchPage("Settings");            
        }

        private void arbitraryImage2_Click(object sender, EventArgs e)
        {
            ((ProgramForm)(this.Parent)).SwitchPage("Achievements");
        }

        private void arbitraryImage3_Click(object sender, EventArgs e)
        {
            ((ProgramForm)(this.Parent)).SwitchPage("About");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Vectors");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Newton");
        }       
    }
}
