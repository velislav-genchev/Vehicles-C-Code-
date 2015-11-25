using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //class for managing a bus which is a specific type of motor vehicle
    public class Bus : MotorVehichle, IUsedForMassTransport, IMaintenance
    {
        private int             numberOfPassengers; //the number of passengers that the bus can carry
        private short           starsOfQuality;     //number of stars for quality the bus has
        private bool            airCond;            //showing if the bus has an air conditioner
        private List<string>    trips;              //list of all the trips the bus has gone to

        //property for the number of passengers capacity of the bus
        public int NumberPassengers
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                if ( value > 0 ) //validating the input data
                {
                    numberOfPassengers = value; //setting the number of passengers value to the input value
                }
                else numberOfPassengers = 10; //setting the number of passengers value to the default value
            }
            get //standart get property
            {
                return numberOfPassengers; //returning the number of passengers value of the bus
            }
        }

        //property for the stars of quality of the bus
        public short StarsOfQuality
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                if ( value > 0 && value <= 5 ) //validating the input data
                {
                    starsOfQuality = value; //setting the stars of quality value to the input value
                }
                else starsOfQuality = 1; //setting the stars of quality value to the default value
            }
            get
            {
                return starsOfQuality; //returning the stars of quality value of the bus
            }
        }

        //property for the air conditioner of the bus
        public bool AirCond
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                airCond = value; //setting the air conditioner value to the input value
            }
            get
            {
                return airCond; //returning the air conditioner value
            }
        }

        //property for the list of trips of the bus
        public List<string> Trips
        {
            get //standart get property
            {
                return trips; //returning the list of trips of the bus
            }
        }

        //indexer for accesing particular trip by index input
        public string this[ int index ]
        {
            get //standart get property
            {
                if ( index > 0 && index <= trips.Count ) //validating the input data
                {
                    return trips[ index - 1 ]; //returning the element at the input index
                }
                else //if the index is invalid
                {
                    throw new ArgumentException("Invalid index"); //giving the user an adequate message about the error
                }
            }
        }

        //constructor using user input data
        public Bus( double tankVolume, string brand, string model, short year, string generalConditionATM, int numberOfPassengers, short starsOfQuality, bool airCond ) : base( tankVolume,brand,model,year,generalConditionATM )
        {
            NumberPassengers =  numberOfPassengers; //setting the number of passengers to the input
            StarsOfQuality =    starsOfQuality;     //setting the stars of quality to the input
            AirCond =           airCond;            //setting air conditioner state to the input
            trips =             new List<string>(); //creating a new list of strings for the trips
        }

        //default constructor
        public Bus() : this( 50.0, "Not Specified", "Not Specified", 2015, "New", 50, 3, true ) { }

        //copy constructor
        public Bus( Bus other ) : this( other.TankVolume, other.Brand, other.Model, other.Year, other.additionalInfo.Condition, other.numberOfPassengers, other.starsOfQuality, other.airCond ) { }

        //overriding the GiveInfo method for the bus class
        public override void GiveInfo()
        {
            base.GiveInfo();                                                                        //calling the base method
            Console.WriteLine( "The maximum number of passengers is: {0}", numberOfPassengers );    //printing the number of passengers of the bus
            Console.WriteLine( "The stars of quality number is: {0}", starsOfQuality );             //printing the number of stars of quality of the bus
            Console.WriteLine( "There is air conditioner: {0}", airCond );                          //printing if the bus has an air conditioner
            Console.WriteLine( "List of trips: " );                                                 //printing the list of trips of the bus
            if (trips.Count == 0) //checking if the number of trips is equal to 0
            {
                Console.WriteLine( "None" ); //if it is, print that there are no trips
            }
            else //if the trips number is more than 0
            {
                foreach ( var trip in trips ) //for each trip
                {
                    Console.WriteLine( trip ); //print the trip data
                }
            }
        }

        //method for adding a new trip of the bus
        public void AddTrip( string trip )
        {
            trips.Add( trip ); //adding the new trip to the list of trips
        }

        //overriding the Equals method for the class bus
        public override bool Equals( object obj )
        {
            if ( obj == null || GetType() != obj.GetType() ) //checking for valid input
            {
                return false; //returning false if the input is invalid
            }
            Bus bus = ( Bus )obj;   //creating a new bus object by casting the obj to bus
                                    //checking if the current bus and the the new bus have the same main data
                                    //only additional info and trips are not main data
            return ( bus.TankVolume == TankVolume ) && ( bus.Brand == Brand ) && ( bus.Model == Model ) && ( bus.Year == Year ) && ( bus.numberOfPassengers == numberOfPassengers ) && ( bus.starsOfQuality == starsOfQuality ) && ( bus.airCond == airCond );
        }

        //overriding the GerHashCode method for the class bus
        public override int GetHashCode()
        {
            return numberOfPassengers; //returning the number of passengers
        }

        //method for calculating the cost of a single trip (from the interface IUsedForMassTransport)
        public decimal CostForTrip( double routeDistance )
        {
            return Convert.ToDecimal( ( routeDistance / TankVolume ) * ( routeDistance / numberOfPassengers ) ); //calculating the cost of a single trip
        }

        //method for calculating the tax cost per year (from the interface IUsedForMassTransport)
        public decimal TaxPerYear()
        {
            return numberOfPassengers * 1000 * starsOfQuality; //calculating the tax cost per year
        }

        //method for calculating the cost of the maintenance per year (from the interface IMaintenance)
        public decimal MaintenancePerYear()
        {
            return numberOfPassengers * trips.Count * 10; //calculating the cost of the maintenance per year
        }
    }
}
