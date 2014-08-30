using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Science
{
    public class TrigProblem
    {
        public Double B { get; set; }
        public Double A { get; set; }
        public Double C { get; set; }
        public Double ThetaOne { get; set; }
        public Double ThetaTwo { get; set; }
        
        public bool Solve()
        {
            if (B != 0 && A != 0)
            {
                return SolveFromAB();
            }
            else if (ThetaOne != 0 && Truth(B != 0, A != 0, C != 0) > 0)
            {
                return SolveFromThetaOne();
            }
            else if (ThetaTwo != 0 && Truth(B != 0, A != 0, C != 0) > 0)
            {
                return SolveFromThetaTwo();
            }
            else
            {
                return false;
            }
        }

        private bool SolveFromAB()
        {
            C = Math.Sqrt(B * B + A * A);
            ThetaOne = deg(Math.Atan(A / B));
            ThetaTwo = deg(Math.Atan(B / A));
            return true;
        }

        public const double PI = 3.14159265358979;

        private double rad(double degree)
        {
            return (PI / 180) * degree;
        }

        private double deg(double radian)
        {
            return (180 / PI) * radian;
        }

        private double sin(double degree)
        {
            return Math.Sin(rad(degree));
        }

        private double cos(double degree)
        {
            return Math.Cos(rad(degree));
        }

        private double tan(double degree)
        {
            return Math.Tan(rad(degree));
        }

        private bool SolveFromThetaOne()
        {
            if (C != 0)
            {
                B = cos(ThetaOne) * C;
                A = sin(ThetaOne) * C;
            }
            else if (B != 0)
            {
                A = tan(ThetaOne) * B;
                C = B / cos(ThetaOne);
            }
            else if (A != 0)
            {
                B = A / tan(ThetaOne);
                C = A / sin(ThetaOne);
            }
            else
            {
                return false;
            }

            ThetaTwo = deg(Math.Atan(B / A));
            return true;
        }

        private bool SolveFromThetaTwo()
        {
            if (C != 0)
            {
                B = sin(ThetaTwo) * C;
                A = cos(ThetaTwo) * C;
            }
            else if (A != 0)
            {
                B = tan(ThetaTwo) * A;
                C = A / cos(ThetaTwo);
            }
            else if (B != 0)
            {
                A = B / tan(ThetaTwo);
                C = B / sin(ThetaTwo);
            }
            else
            {
                return false;
            }

            ThetaOne = deg(Math.Atan(A / B));
            return true;
        }

        static int Truth(params bool[] booleans)
        {
            return booleans.Count(b => b);
        }
    }
}
