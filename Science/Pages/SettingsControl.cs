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
    public partial class SettingsControl : Page
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void arbitraryImage4_Click(object sender, EventArgs e)
        {
            //BUG: this doesn't work. Need parent form to track history or something.
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foldPanel1.Closed = !foldPanel1.Closed;
            foldPanel1.Refresh();
        }

        private void settingsPanelClosedChanged(object sender, EventArgs e)
        {
            FoldPanel panel = (FoldPanel)sender;
            foreach (Control C in flowLayoutPanel1.Controls)
            {
                if (C is FoldPanel && C != sender)
                {
                    ((FoldPanel)C).Closed = true;
                    C.Refresh();
                }
            }
        }

        private void arbitraryButton1_Click(object sender, EventArgs e)
        {
            Achievement.Clear();
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip Tip = new ToolTip();
            Tip.ToolTipIcon = ToolTipIcon.None;
            Tip.IsBalloon = true;
            Tip.InitialDelay = 1;
            string text = "";
            if ((string)comboBox1.SelectedItem == "Standard")
                text = "16 significant figures";
            if ((string)comboBox1.SelectedItem == "High")
                text = "32 significant figures";
            if ((string)comboBox1.SelectedItem == "Extreme")
                text = "64 significant figures";
            if ((string)comboBox1.SelectedItem == "SCIENCE!")
                text = "128 significant figures";
            Tip.Show(text, this.ParentForm, comboBox1.Location, 1000);            
        }
    }
}
