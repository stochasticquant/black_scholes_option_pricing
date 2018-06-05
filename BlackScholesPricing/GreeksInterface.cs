using System;
namespace BlackScholesPricing
{
    public interface GreeksInterface
    {
        double delta();
        double gamma();
        double theta();
        double vega();
        double rho();



    }
}
