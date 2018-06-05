using System;

namespace BlackScholesPricing
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            /*
             *  The main method implements the pricing of plain vanilla call and put options.
             *  The Greeks for the two options are calculated
             */


            // option objects
            Pricer obj1 = new Pricer(120.0, 100.0, 0.05, 0.2, 1, 'c');
            Pricer obj2 = new Pricer(120.0, 100.0, 0.05, 0.2, 1, 'p');
            double callPrice = obj1.bs();
            double putPrice = obj2.bs();


            // greek objects
            Greeks greeks1 = new Greeks(120.0, 100.0, 0.05, 0.2, 1, 'c');
            Greeks greeks2 = new Greeks(120.0, 100.0, 0.05, 0.2, 1, 'p');


            // output
            Console.WriteLine("............. Input Parameters ..................\n");
            Console.WriteLine("Initial stock price  : " + obj1.S1);
            Console.WriteLine("Strike price         : " + obj1.K1);
            Console.WriteLine("Risk free rate       : " + obj1.R);
            Console.WriteLine("Stock volatility     : " + obj1.Vol);
            Console.WriteLine("Time to maturity     : " + obj1.T1);
            Console.WriteLine("Option type          : " + obj1.Option);

            Console.WriteLine("\nd1 : " + obj1.d1());
            Console.WriteLine("d2 : " + obj2.d2());
            Console.WriteLine("\nN(d1) :" + Pricer.CND(obj1.d1()));
            Console.WriteLine("N(d2) :" + Pricer.CND(obj2.d2()));
            Console.WriteLine("\nN(-d1) :" + Pricer.CND(-obj1.d1()));
            Console.WriteLine("N(-d2) :" + Pricer.CND(-obj2.d2()));
           
            Console.WriteLine("\n............. Option Prices .....................\n");
            Console.WriteLine("Call price : " + callPrice);
            Console.WriteLine("Put price  : " + putPrice);

            Console.WriteLine("\n............. Greeks  ...........................\n");
            Console.WriteLine("Call option:");
            Console.WriteLine("Delta  : " + greeks1.delta());
            Console.WriteLine("Gamma  : " + greeks1.gamma());
            Console.WriteLine("Theta  : " + greeks1.theta());
            Console.WriteLine("Vega   : " + greeks1.vega());
            Console.WriteLine("Rho    : " + greeks1.rho());

            Console.WriteLine("\nPut option:");
            Console.WriteLine("Delta  : " + greeks2.delta());
            Console.WriteLine("Gamma  : " + greeks2.gamma());
            Console.WriteLine("Theta  : " + greeks2.theta());
            Console.WriteLine("Vega   : " + greeks2.vega());
            Console.WriteLine("Rho    : " + greeks2.rho());


            Console.WriteLine("\n..................................................");

        }
    }
}
