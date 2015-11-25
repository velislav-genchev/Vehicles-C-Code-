using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //class for managing a motor vehicle which should be inherited by specific types of motor vehicles
    public class MotorVehichle : Vehicle
    {
        private static int      uniqueNum = 1;      //used for generating unique registration number for each object
        private string          regNum;             //unique number for each object
        private double          tankVolume;         //the amount of fuel the vehicle can carry
        private string          brand;              //the brand of the vehicle
        private string          model;              //the model of the vehicle
        private short           year;               //the year the vehicle was created
        public AdditionalInfo   additionalInfo;     //additional information about the car

        //property for the registration number of a vehicle
        public string RegNum //property for the registration number of a vehicle
        {
            protected set //making it usable only from inside the class and from the iherited classes 
            {
                regNum = value; //setting the registration number value to the input value
            }
            get //standart get property usable from everywhere
            {
                return regNum; //returning the registration number of the vehicle
            }
        }

        //property for the tank volume of the vehicle
        public double TankVolume 
        {
            protected set //making it usable only from inside the class and from the iherited classes 
            {
                if ( value > 0 ) //validating the input data
                {
                    tankVolume = value; //setting the tank volume value to the input value
                }
                else tankVolume = 10.0; //setting the tank volume value to a default one
            }
            get //standart get property usable from everywhere
            {
                return tankVolume; //returning the tank volume value of the vehicle
            }
        }

        //property for the brand of the car
        public string Brand
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                if ( value != "" ) //validating the input data
                {
                    brand = value; //setting the brand value to the input value
                }
                else //entering if the input is incorrect
                {
                    throw new ArgumentException( "The brand name should be an existing one" ); //displaying the user a message that the brand name he entered is an invalid one
                }
            }
            get //standart get property usable from everywhere
            {
                return brand; //returning the brand name of the vehicle
            }
        }

        //property for the model of the car
        public string Model
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                if ( value != "" ) //validating the input data
                {
                    model = value; //setting the model value to the input value
                }
                else //entering if the input is incorrect
                {
                    throw new ArgumentException( "The model name should be an existing one" ); //displaying the user a message that the model name he entered is an invalid one
                }
            }
            get //standart get property usable from everywhere
            {
                return model; //returning the model name of the vehicle
            }
        }

        //property for the year in which the car was made
        public short Year
        {
            protected set //making it usable only from inside the class and from the iherited classes
            {
                if ( value > 1900 && value < 2015 )  //validating the input data
                {
                    year = value; //setting the year value to the input value
                }
                else //entering if the input is incorrect
                {
                    throw new ArgumentException( "The year should be a valid one" ); //displaying the user a message that the year value he entered is an invalid one
                }
            }
            get //standart get property usable from everywhere
            {
                return year; //returning the year value of the vehicle
            }
        }

        //constructor using user input data
        public MotorVehichle( double tankVolume, string brand, string model, short year, string generalConditionATM ) 
        {
            RegNum =        Convert.ToString( uniqueNum.ToString( "D4" ) );     //setting the registration number value using the unique number generator for the class
            TankVolume =    tankVolume;                                         //setting the tank volume to the input
            uniqueNum++;                                                        //increasing the unique number value so it stays unique

            Brand =             brand;                                          //setting the brand value to the input
            Model =             model;                                          //setting the model value to the input
            Year =              year;                                           //setting the year value to the input

            additionalInfo =    new AdditionalInfo( generalConditionATM );      //setting the additional info using its constructor with input
        }

        //defaul constructor
        public MotorVehichle() : this( 50.0,"Not Specified","Not Specified",2015,"New" ) { }

        //copy constructor
        public MotorVehichle( MotorVehichle other ) : this( other.tankVolume,other.brand,other.model,other.year,other.additionalInfo.Condition ) { }

        //method for printing the class of the object and its current data
        public override void GiveInfo()
        {
            Console.WriteLine( "The type is: {0}", GetType() );                                             //printing the type of the class of the vehicle
            Console.WriteLine( "The registration number is: {0}", regNum );                                 //printing the registration number of the vehicle
            Console.WriteLine( "The tank volume's capacity is: {0} litres", tankVolume );                   //printing the tank volume of the vehicle
            Console.WriteLine( "The brand name is: {0}", brand );                                           //printing the brand name of the vehicle
            Console.WriteLine( "The model name is: {0}", model );                                           //printing the model name of the vehicle
            Console.WriteLine( "The year of construction is: {0}", year );                                  //printing the year of construction of the vehicle
            Console.WriteLine( "The general condition at the moment is: {0}",additionalInfo.Condition );    //printing the general condition of the vehicle
            Console.WriteLine( "The vehicle is insured: {0}", additionalInfo.IsSafe );                      //printing whether the cehicle has insurance
            Console.WriteLine( "List of crashes: " );                                                       //printing the list of crashes for the vehicle
            if ( additionalInfo.Crashes.Count == 0 ) //checking if the number of crashes is equal to 0
            {
                Console.WriteLine( "None" ); //if it is, print that there are no crashes
            }
            else //if the crashes number is more than 0
            {
                foreach ( var crash in additionalInfo.Crashes ) //for each crash
                {
                    Console.WriteLine( crash ); //print the crash data
                }
            }
        }
    } //end class
}
