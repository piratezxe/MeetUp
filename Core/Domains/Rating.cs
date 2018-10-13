using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class Rating
    {
        private double point;

        public double Points {

            get
            {
                return point;
            }

            set
            {
                if (value > 6)
                    throw new ArgumentOutOfRangeException("Max rating points was 6");
                else if (value < 0)
                    throw new ArgumentOutOfRangeException("Min rating points was 0");
                else
                    point = value;
            }
        }

    }
}
