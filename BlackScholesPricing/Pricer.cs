using System;
namespace BlackScholesPricing
{
    /*
     *  Implemeting the Black Scholes Opton pricing method.
     *  Comumulative normal distribution function is implemented using the Abromowitz and Stegun approximation method.
     *  Parameters are defines as :
     *      S : Initial stock price
     *      K : Strike price
     *      r : Risk free rate
     *    vol : Stock volatility
     *      T : Time to maturity
     * option : option type : call 'c', put 'p'
     * 
     * 
     *  Author : Charles Sambo
     *  @stochasticquant
     *  quantengineer@outlook.com
     */
     

    public class Pricer : PricerInterface
    {
        // pricing parameters

        private  double S;       
        private  double K;       
        private  double r;       
        private  double vol;     
        private  double T;       
        private  char  option;  




        // constructors
        public Pricer()
        {
        }

        public Pricer(Double S, Double K, double r, double vol, double T, char option){
            this.S1 = S;
            this.K1 = K;
            this.R = r;
            this.Vol = vol;
            this.T1 = T;
            this.Option = option;

        }

        // getters and setters
        public double S1 { get => S; set => S = value; }
        public double K1 { get => K; set => K = value; }
        public double R { get => r; set => r = value; }
        public double Vol { get => vol; set => vol = value; }
        public double T1 { get => T; set => T = value; }
        public char Option { get => option; set => option = value; }


        // Cumulative normal fuction
        // Abromowitz and Stegun approximation

        /*
        public static double CND( double x){

            const double b1 = 0.319381530;
            const double b2 = -0.356563782;
            const double b3 = 1.781477937;
            const double b4 = -1.821255978;
            const double b5 = 1.330274429;
            const double p = 0.2316419;
            const double c = 0.39894228;

            if (x >= 0.0){
                double t = 1.0 / (1.0 + p * x);
                return (1.0 - c * Math.Exp(-x * x / 2.0) * t * (t * (t * (t * (t * b5 + b4) + b3) + b2) + b1));

            } else {
                double t = 1.0 / (1.0 + p * x);
                return (c * Math.Exp(-x * x / 2.0) * t * (t * (t * (t * (t * b5 + b4) + b3) + b2) + b1));
                
            }
        }

        */

        // Cumulative normal fuction
        // Abromowitz and Stegun approximation
        public static double CND(double z)
        {
            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign;
            if (z < 0.0)
                sign = -1;
            else
                sign = 1;
            
            double x = Math.Abs(z) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3)
              * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        }


        // calculating d1 and d2
        public  double d1()
        {
            double D1 = (Math.Log10(S1 / K1) + (R + Vol * Vol * 0.5) * T1) / (Vol * Math.Sqrt(T1));
            return D1;
        }

        public double d2()
        {
            double D2 = (Math.Log10(S1 / K1) + (R - Vol * Vol * 0.5) * T1) / (Vol * Math.Sqrt(T1));
            return D2;
        }



        // black scholes price calculation
        public double bs(){


            if (Option.Equals('c'))
            {
                double price = S1 * CND(d1()) - CND(d2() * K1 * Math.Exp(-R * T1));
                return price;

            }
            else if (Option.Equals('p'))
            {
                double price = CND(-d2()) * K1 * Math.Exp(-R * T1) - CND(-d1()) * S1;
                return price;

            }
            else
            {
                Console.WriteLine("Option type not valid!");
                return 0;

            }

        }


    }
}
