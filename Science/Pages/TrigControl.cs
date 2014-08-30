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
    public partial class TrigControl : Page
    {
        public TrigControl()
        {

            InitializeComponent();
            switchToImage(lblThetaOne);
            switchToImage(lblThetaTwo);
        }

        private void switchToImage(Label lbl)
        {
            var pos = this.PointToScreen(lbl.Location);
            pos = pictureBox1.PointToClient(pos);
            lbl.Parent = pictureBox1;
            lbl.Location = pos;
            lbl.BackColor = Color.Transparent;
        }

        private bool UpdatingForm = false;

        private void trigChanged(object sender, EventArgs e)
        {
            if (!UpdatingForm)
            {
                TrigProblem problem = new TrigProblem()
                {
                    A = txtA.ReadOnly ? 0 : Physics.ParseDouble("0" + txtA.Text),
                    B = txtB.ReadOnly ? 0 : Physics.ParseDouble("0" + txtB.Text),
                    C = txtC.ReadOnly ? 0 : Physics.ParseDouble("0" + txtC.Text),
                    ThetaOne = txtThetaOne.ReadOnly ? 0 : Physics.ParseDouble("0" + txtThetaOne.Text),
                    ThetaTwo = txtThetaTwo.ReadOnly ? 0 : Physics.ParseDouble("0" + txtThetaTwo.Text)
                };

                if (problem.A == 65 && problem.B == 77)
                {
                    ((ProgramForm)ParentForm).SwitchPage("Liberty");
                }

                txtA.ReadOnly = ((problem.ThetaOne != 0 || problem.ThetaTwo != 0) && (problem.B != 0 || problem.C != 0)) || problem.C != 0;
                txtB.ReadOnly = ((problem.ThetaOne != 0 || problem.ThetaTwo != 0) && (problem.A != 0 || problem.C != 0)) || problem.C != 0;
                txtC.ReadOnly = (problem.B != 0 || problem.A != 0);
                txtThetaOne.ReadOnly = Truth(problem.B != 0, problem.A != 0, problem.C != 0) > 1 || problem.ThetaTwo != 0;
                txtThetaTwo.ReadOnly = Truth(problem.B != 0, problem.A != 0, problem.C != 0) > 1 || problem.ThetaOne != 0;

                if (problem.Solve())
                {
                    setBoxes(problem);
                }
                else
                {
                    clearBoxes(problem);
                }

                if (problem.ThetaOne >= 90 || problem.ThetaTwo >= 90)
                {
                    Achievement.Trigger("That's Not Right!");
                }
            }
        }

        private void setBoxes(TrigProblem prob)
        {
            UpdatingForm = true;
            if (txtA.ReadOnly)
                txtA.Text = Math.Round(prob.A, 6).ToString();
            if (txtB.ReadOnly)
                txtB.Text = Math.Round(prob.B, 6).ToString();
            if (txtC.ReadOnly)
                txtC.Text = Math.Round(prob.C, 6).ToString();
            if (txtThetaOne.ReadOnly)
                txtThetaOne.Text = Math.Round(prob.ThetaOne, 6).ToString();
            if (txtThetaTwo.ReadOnly)
                txtThetaTwo.Text = Math.Round(prob.ThetaTwo, 6).ToString();
            UpdatingForm = false;
        }

        private void clearBoxes(TrigProblem prob)
        {
            UpdatingForm = true;
            if (txtA.Text == "0")
                txtA.Text = string.Empty;
            if (txtB.Text == "0")
                txtB.Text = string.Empty;
            if (txtC.Text == "0")
                txtC.Text = string.Empty;
            if (txtThetaOne.Text == "0")
                txtThetaOne.Text = string.Empty;
            if (txtThetaTwo.Text == "0")
                txtThetaTwo.Text = string.Empty;
            UpdatingForm = false;
        }

        private int Truth(params bool[] booleans)
        {
            return booleans.Count(b => b);
        }

        private void txtC_ReadOnlyChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.ReadOnly)
            {
                box.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                box.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.UpdatingForm = true;
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    C.Text = string.Empty;
                    ((TextBox)C).ReadOnly = false;
                }
            }
        }

        private void miniNavControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((ProgramForm)ParentForm).SwitchPage("Liberty");
        }  
    }
}
