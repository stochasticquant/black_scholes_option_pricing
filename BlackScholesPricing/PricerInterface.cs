using System;
namespace BlackScholesPricing
{
    public interface PricerInterface
    {
        /*
         * The interface implemetation method
         *  bs()  : implements the black scholes formula for option price calculation
         * 
         */

        // black scholes method
        double bs();
    }
}
