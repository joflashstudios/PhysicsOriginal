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
    public partial class MiniNavControl : UserControl
    {
        public MiniNavControl()
        {
            InitializeComponent();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Launcher");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Trig");
        }

        private void arbitraryImage4_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Launcher");
        }

        private void MiniNavControl_Paint(object sender, PaintEventArgs e)
        {
            if (this.ParentForm != null)
            {
                Control toChange = null;
                int oldWidth = 0;
                int oldLeft = 0;
                foreach (Control C in this.Controls)
                {
                    if (C is Button && this.ParentForm != null)
                    {
                        if (((ProgramForm)this.ParentForm).ActivePage.Name == (string)C.Tag)
                        {
                            toChange = C;
                        }
                        else
                        {
                            oldWidth = C.Width;
                            oldLeft = C.Left;
                        }
                    }
                }
                if (toChange != null)
                {
                    toChange.Width = oldWidth + 10;
                    toChange.Left = oldLeft - 5;
                    toChange.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Vectors");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Newton");
        }

        private void arbitraryImage1_Click(object sender, EventArgs e)
        {
            ((ProgramForm)this.ParentForm).SwitchPage("Settings");
        }
    }
}
