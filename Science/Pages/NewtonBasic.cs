using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using W3b.Sine;

namespace Science
{
    public partial class NewtonBasic : Page
    {
        public NewtonBasic()
        {
            InitializeComponent();
        }

        private bool Operating;

        private void ForceChanged(object sender, EventArgs e)
        {
            if (!Operating)
            {
                Operating = true;
                FMAProblem problem = new FMAProblem(
                    txtForce.ReadOnly ? 0 : Physics.ParseNum(txtForce.Text),
                    txtMass.ReadOnly ? 0 : Physics.ParseNum(txtMass.Text),
                    txtAccel.ReadOnly ? 0 : Physics.ParseNum(txtAccel.Text)
                    );

                txtAccel.ReadOnly = problem.M != 0 && problem.F != 0;
                txtForce.ReadOnly = problem.M != 0 && problem.A != 0;
                txtMass.ReadOnly = problem.A != 0 && problem.F != 0;

                if (problem.Solve())
                {
                    if (txtAccel.ReadOnly)
                        txtAccel.Text = BigNumDec.Round(problem.A, 4);
                    if (txtForce.ReadOnly)
                        txtForce.Text = BigNumDec.Round(problem.F, 4);
                    if (txtMass.ReadOnly)
                        txtMass.Text = BigNumDec.Round(problem.M, 4);
                }
                Operating = false;
            }
        }

        internal class FMAProblem
        {
            public BigNumDec F { get; set; }
            public BigNumDec M { get; set; }
            public BigNumDec A { get; set; }

            public FMAProblem(BigNumDec F, BigNumDec M, BigNumDec A)
            {
                this.F = F;
                this.M = M;
                this.A = A;
            }

            public bool Solve()
            {
                if (F != 0 && M != 0)
                {
                    A = (BigNumDec)(F / M);
                }
                else if (F != 0 && A != 0)
                {
                    M = (BigNumDec)(F / A);
                }
                else if (M != 0 && A != 0)
                {
                    F = (BigNumDec)(M * A);
                }
                else
                {
                    return false;
                }
                return true;
            }
        }
    }
}
