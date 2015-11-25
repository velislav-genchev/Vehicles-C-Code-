using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechiclesLibrary
{
    //a struct for reviewing additional info about a vehicle
    public struct AdditionalInfo 
    {
        private string          generalConditionATM;    //describing the general condition of the vehicle at the moment
        private List<string>    crashes;                //list of all the crashesh with description into which the vehicle has been
        private bool            insured;                //variable for showing whether the vehicle has insurance

        //property for the current condition of the vehicle which can always be changed
        public string Condition
        {
            set //standart set property
            {
                generalConditionATM = value; //setting the general condition value to the input
            }
            get //standart get property
            {
                return generalConditionATM; //returning the general condition value
            }
        }

        //indexer for accesing particular crash by index input
        public string this[ int index ]
        {
            get //standart get property
            {
                if ( index >= 1 && index <= crashes.Count ) //validating index input
                {
                    return crashes[ index - 1 ]; //returing the desired crash info
                }
                else //if the input is incorrect
                {
                    throw new ArgumentException( "Invalid index request" ); //giving the user an error message because of invalid index input
                }
            }
        }

        //property for getting the list of crashes
        public List<string> Crashes
        {
            get //standart get property
            {
                return crashes; //returning the list of crashes
            }
        }

        //constructor with user data
        public AdditionalInfo( string generalConditionATM )
        {
            this.generalConditionATM =  generalConditionATM;    //setting the general condition value
            crashes =                   new List<string>();     //creaating a new list of strings for the crashes
            insured =                   false;                  //it is uninsured by default
        }

        //copy constructor
        public AdditionalInfo( AdditionalInfo other ) : this( other.generalConditionATM ) { }

        //method for adding a new crash to the crash list
        public void AddCrash( string newCrash )
        {
            crashes.Add( newCrash ); //adding the new crash to the list
        }

        //method for insuring a car
        public void AddInsurance()
        {
            insured = true; //changing the insurance state to true
        }

        //property for checking is it safe to drive the vehicle
        public bool IsSafe
        {
            get //standart get property
            {
                return insured; //returning whether the car is safe with true abd false
            }
        }
    } //end struct
}
