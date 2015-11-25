using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //interface with methods for vehicles which are used for transportation of cargo
    interface IUsedForCargoTransport
    {
        //method for calculating the cost for a specific destination by giving the distance as argument
        decimal CostForDestination( double routeDistance );

        //method for calculating the tax amount per year for the vehicle
        decimal TaxPerYear();
    }
}
