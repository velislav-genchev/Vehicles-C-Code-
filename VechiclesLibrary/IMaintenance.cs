using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //interface for the maintenance price of a vehicle
    interface IMaintenance
    {
        //method for calculating the maintenance price per year for a vehicle
        decimal MaintenancePerYear();
    }
}
