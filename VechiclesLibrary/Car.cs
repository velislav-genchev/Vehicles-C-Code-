using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //class for managing a car which is a specific type of motor vehicle
    public class Car : MotorVehichle, IMaintenance
    {
        public enum TypeOfCar //enumeration for the types of car we have
        {
            Sedan = 0, Hatch, Wagon, Van, Suv //types of car we have
        }

        private short           numberOfSeats;  //number of seats of the car
        private TypeOfCar       typeOfCar;      //type of the car
        private List<string>    extras;         //list of extras the car has (it can grow)

        //property for the number of seats of the car
        public short NumberOfSeats
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                if ( value > 0 ) //validating the input data
                {
                    numberOfSeats = value; //setting the number of seats value to the input value
                }
                else numberOfSeats = 5; //setting the number of seats value to the default value
            }
            get //standart get property
            {
                return numberOfSeats; //returning the number of seats value
            }
        }

        //private method for converting string to TypeOfCar inside the class
        private TypeOfCar StringToTypeOfCar( string type )
        {
            switch ( type ) //switch statement for the input string
            {
                //converting the string to TypeOfCar
                case "sedan":   return TypeOfCar.Sedan;
                case "hatch":   return TypeOfCar.Hatch;
                case "wagon":   return TypeOfCar.Wagon;
                case "van":     return TypeOfCar.Van;
                case "suv":     return TypeOfCar.Suv;
                
                default: throw new ArgumentException("The type seems to be invalid"); //displaying a message that the input is invalid
            }
        }

        //private method for converting TypeOfCar to string inside the class
        private string TypeOfCarToString( TypeOfCar str )
        {
            switch ( str ) //switch statement for the input TypeOfCar
            {
                //converting the TypeOfCar to string
                case TypeOfCar.Sedan:   return "sedan";
                case TypeOfCar.Hatch:   return "hatch";
                case TypeOfCar.Wagon:   return "wagon";
                case TypeOfCar.Van:     return "van";
                case TypeOfCar.Suv:     return "suv";
                
                //cannot go into default because the TypeOfCar enum has only 5 values
                default:                return "";
            }
        }

        //property for the type of car using the two convertion functions StringToTypeOfCar and TypeOfCarToString
        public string Type
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                //setting the type of car value using a convertion from string
                typeOfCar = StringToTypeOfCar( value );
            }
            get //standart get property
            {
                //returning the type of car value in string format using a convertion from TypeOfCar to string
                return TypeOfCarToString( typeOfCar );
            }
        }

        //property for the list of extras of the car
        public List<string> Extras
        {
            private set //making it usable only from inside the class
            {
                extras = value; //setting the extras value to the specified input
            }
            get //standart get property
            {
                return extras; //returning the list of extras of the car
            }
        }

        //indexer for accesing particular extra by index input
        public string this[ int index ]
        {
            get //standart get property
            {
                if ( index > 0 && index <= extras.Count ) //validating the input data
                {
                    return extras[index - 1]; //returning the element at the input index
                }
                else //if the index is invalid
                {
                    throw new ArgumentException("Invalid index"); //giving the user an adequate message about the error
                }
            }
        }

        //constructor using user input data
        public Car( double tankVolume, string brand, string model, short year, string generalConditionATM, short numberOfSeats, string typeOfCar) : base(tankVolume,brand,model,year,generalConditionATM )
        {
            NumberOfSeats = numberOfSeats;      //setting the number of seats to the input
            Type =          typeOfCar;          //setting the type of car to the input
            extras =        new List<string>(); //creating a new list of strings for the extras
        }

        //default constructor
        public Car() : this( 50.0,"Not Specified","Not Specified", 2015, "new", 5, "sedan" ) { }

        //copy constructor
        public Car( Car other ) : this( other.TankVolume, other.Brand, other.Model, other.Year, other.additionalInfo.Condition, other.numberOfSeats, other.Type ) { }

        //overriding the GiveInfo method for the car class
        public override void GiveInfo()
        {
            base.GiveInfo();                                                    //calling the base method
            Console.WriteLine();                                                //leaving one empty line for easier understanding
            Console.WriteLine( "The number of seats is: {0}", numberOfSeats );  //printing the number of seats of the car
            Console.WriteLine( "The type is: {0}", Type );                      //printing the type of the car
            Console.WriteLine( "List of extras: " );                            //printing the list of extras of the car
            if (Extras.Count == 0) //checking if the number of extras is equal to 0
            {
                Console.WriteLine( "None" ); //if it is, print that there are no extras
            }
            else //if the extras number is more than 0
            {
                foreach ( var extra in Extras ) //for each extra
                {
                    Console.WriteLine( extra ); //print the extra data
                }
            }
        }

        //method for adding a new extra of the car
        public void AddExtra( string extra )
        {
            extras.Add( extra ); //adding the new extra to the extras list of the car
        }

        //overriding the Equals method for the class car
        public override bool Equals( object obj )
        {
            if ( obj == null || GetType() != obj.GetType() ) //checking for valid input
            {
                return false; //returning false if the input is invalid
            }
            Car car = ( Car )obj;   //creating a new car object by casting the obj to car
                                    //checking if the current car and the the new car have the same main data
                                    //only additionalInfo and extras are not main data
            return ( car.TankVolume == TankVolume ) && ( car.Brand == Brand ) && ( car.Model == Model ) && ( car.NumberOfSeats == NumberOfSeats ) && ( car.Type == Type );
        }

        //overriding the GerHashCode method for the class car
        public override int GetHashCode()
        {
            return numberOfSeats; //returning the number of seats
        }

        //method for calculating the cost of the maintenance per year (from the interface IMaintenance)
        public decimal MaintenancePerYear()
        {
            //calculating the cost of the maintenance per year
            return Convert.ToDecimal( numberOfSeats * TankVolume * additionalInfo.Crashes.Count * 100 );
        }
    } //end class
}
