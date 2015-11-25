using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //class for managing a truck which is a specific type of motor vehicle
    public class Truck : MotorVehichle,IUsedForCargoTransport,IMaintenance
    {
        private int             maxLoad;        //the maximum amount of cargo the truck can transport
        private bool            isTIR;          //a variable which shows whether the truck is a TIR or not
        private List<string>    destinations;   //list of all the destinations the truck has gone to

        //property for the maximum amount of cargo of the truck
        public int MaxLoad
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                if ( value > 0 ) //validating the input data
                {
                    maxLoad = value; //setting the maximum load value to the input value
                }
                else maxLoad = 10; //setting the maximum load value to the default value
            }
            get //standart get property
            {
                return maxLoad; //returning the maximum load value of the truck
            }
        }

        //property for the isTIR bool value of the truck
        public bool IsTIR
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                isTIR = value; //determining whether the truck is a TIR or not using the input value
            }
            get //standart get property
            {
                return isTIR; //returning whether the truck is a TIR or not
            }
        }

        //property for the list of destinations of the truck
        public List<string> Destinations
        {
            get //standart get property
            {
                return destinations; //returning a list of all of the destinations of the truck
            }
        }

        //indexer for accesing particular destination by index input
        public string this[ int index ]
        {
            get //standart get property
            {
                if ( index > 0 && index <= destinations.Count ) //validating the input data
                {
                    return destinations[ index - 1 ]; //returning the element at the input index
                }
                else //if the index is invalid
                {
                    throw new ArgumentException( "Invalid index" ); //giving the user an adequate message about the error
                }
            }
        }

        //constructor using user input data
        public Truck( double tankVolume, string brand, string model, short year, string generalConditionATM, int maxLoad, bool isTIR ) : base( tankVolume, brand, model, year, generalConditionATM )
        {
            MaxLoad =       maxLoad;            //setting the max load value to the input
            IsTIR =         isTIR;              //setting whether the truck is TIR or not by using the input
            destinations = new List<string>();  //creating a new list of strings for the destinations
        }

        //default constructor
        public Truck() : this( 50.0, "Not Specified", "Not Specified", 2015, "New", 10, false ) { }

        //copy constructor
        public Truck( Truck other ) : this( other.TankVolume, other.Brand, other.Model, other.Year, other.additionalInfo.Condition, other.maxLoad, other.isTIR ) { }

        //overriding the GiveInfo method for the truck class
        public override void GiveInfo()
        {
            base.GiveInfo(); //calling the base method
            Console.WriteLine( "The maximum load is: {0}", maxLoad );   //printing the max load value of the truck
            Console.WriteLine( "The truck is a TIR: {0}", isTIR );      //printing whether the truck is a TIR or not
            Console.WriteLine( "List of destinations: " );              //printing the list of destinations of the truck
            if ( destinations.Count == 0 ) //checking if the number of destinations is equal to 0
            {
                Console.WriteLine( "None" ); //if it is, print that there are no destinations
            }
            else //if the destinations number is more than 0
            {
                foreach ( var destination in destinations ) //for each trip
                {
                    Console.WriteLine( destination ); //print the trip data
                }
            }
        }

        //method for adding a new destination of the truck
        public void AddDestination( string destination )
        {
            destinations.Add( destination ); //adding the new destination to the list of destinations
        }

        //overriding the Equals method for the class bus
        public override bool Equals( object obj )
        {
            if ( obj == null || GetType() != obj.GetType() ) //checking for valid input
            {
                return false; //returning false if the input is invalid
            }
            Truck truck = ( Truck )obj; //creating a new truck object by casting the obj to truck
                                        //checking if the current truck and the the new truck have the same main data
                                        //only additional info and destinations are not main data
            return ( truck.TankVolume == TankVolume ) && ( truck.Brand == Brand ) && ( truck.Model == Model ) && ( truck.Year == Year ) && ( truck.maxLoad == maxLoad ) && ( truck.isTIR == isTIR );
        }

        //overriding the GerHashCode method for the class truck
        public override int GetHashCode()
        {
            return maxLoad; //returning the maximum load value
        }

        //method for calculating the cost of a single destination (from the interface IUsedForCargoTransport)
        public decimal CostForDestination( double routeDistance )
        {
            return Convert.ToDecimal( ( routeDistance / TankVolume ) * ( routeDistance / maxLoad ) ); //calculating the cost of a single destination
        }

        //method for calculating the tax cost per year (from the interface IUsedForCargoTransport)
        public decimal TaxPerYear()
        {
            return maxLoad * 1000 + Convert.ToInt16( isTIR ) * 10000; //calculating the tax cost per year
        }

        //method for calculating the cost of the maintenance per year (from the interface IMaintenance)
        public decimal MaintenancePerYear()
        {
            return maxLoad * destinations.Count * 100; //calculating the cost of the maintenance per year
        }
    }
}
