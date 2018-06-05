using System;
namespace BlackScholesPricing
{
    public class Greeks : Pricer, GreeksInterface {

        // constructor calls the Pricer default constructor 
        public Greeks()
            : base()
        {

        }

        // constructor calls Pricer defined constructor
        public Greeks(Double S, Double K, double r, double vol, double T, char option)
            : base(S, K, r, vol, T, option)
        {

            /*
             *  this constructor gives a call to the Pricer defines constructor whichs makes the following variables
             *  usable in the class
             * 
             *  this.S1 = S;
             *  this.K1 = K;
             *  this.R = r;
             *  this.Vol = vol;
             *  this.T1 = T;
             *  this.Option = option;
             */

        }

        // method to calculate delta : The first derivative of the option price with respect to the underlying.
        public double delta()
        {
            if (Option.Equals('c'))
            {
                double delta_ = CND(d1());
                return delta_;
            }
            else if (Option.Equals('p'))
            {
                double delta_ = CND(d2());
                return delta_;
            }
            else
            {
                return 0;
            }
        }

        // method to calculate gamma : The second derivative of the option price wrt the underlying stock. These are equal for puts and calls 
        public double gamma()
        {
            if (Option.Equals('c'))
            {
                double gamma_ = CND(d1()) / (S1 * Vol * Math.Sqrt(T1));
                return gamma_;
            }
            else if (Option.Equals('p'))
            {
                double gamma_ = CND(d2()) / (S1 * Vol * Math.Sqrt(T1));
                return gamma_;
            }
            else
            {
                return 0;
            }
        }

        // method to calculate theta : The partial with respect to time-to-maturity. 
        public double theta()
        {
            if (Option.Equals('c'))
            {
                double theta_ = -((CND(d1()) * S1 * Vol)/ (2.0 * Math.Sqrt(T1))) - R * K1 * Math.Exp(-R * T1) * CND(d2());
                return theta_;
            }
            else if (Option.Equals('p'))
            {
                double theta_ = -((CND(d1()) * S1 * Vol) / (2.0 * Math.Sqrt(T1))) - R * K1 * Math.Exp(-R * T1) * CND(-d2());
                return theta_;
            }
            else
            {
                return 0;
            }
        }

        // method to calculate vega : The partial with respect to volatility. 
        public double vega()
        {
            if (Option.Equals('c'))
            {
                double vega_ = S1 * T1 * CND(d1());
                return vega_;
            }
            else if (Option.Equals('p'))
            {
                double vega_ = S1 * T1 * CND(d1());
                return vega_;
            }
            else
            {
                return 0;
            }
        }

        // method to calculate rho : The partial with respect to the interest rate. 
        public double rho()
        {
            if (Option.Equals('c'))
            {
                double rho_ = K1 * T1 * Math.Exp(-R * T1) *  CND(d2());
                return rho_;
            }
            else if (Option.Equals('p'))
            {
                double rho_ = -K1 * T1 * Math.Exp(-R * T1) * CND(-d2());
                return rho_;
            }
            else
            {
                return 0;
            }
        }
       

            
        }

}
