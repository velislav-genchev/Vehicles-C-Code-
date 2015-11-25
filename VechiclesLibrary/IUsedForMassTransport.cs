using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //interface with methods for vehicles which are used for mass transportation of people
    interface IUsedForMassTransport
    {
        //method for calculating the cost for a specific trip by giving the distance as argument
        decimal CostForTrip( double routeDistance ); 

        //method for calculating the tax amount per year for the vehicle
        decimal TaxPerYear();
    }
}
