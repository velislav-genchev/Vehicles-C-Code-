using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VechiclesLibrary;

namespace VehiclesApplication
{
    //an application for managing multiple vehicles
    public class Application
    {
        private List<Car>   carList;    //list of car objects
        private List<Bus>   busList;    //list of bus objects
        private List<Truck> truckList;  //list of truck objects
        private bool        running;    //bool variable for checking untill when should the run function run

        //constructor with user data
        public Application( List<Car> cars, List<Bus> buses, List<Truck> trucks )
        {
            carList =   new List<Car>( cars );          //creating a new list of car objects from input data
            busList =   new List<Bus>( buses );         //creating a new list of bus objects from input data
            truckList = new List<Truck>( trucks );      //creating a new list of truck objects from input data
            running =   true;                           //setting the running state of the Run method to true
        }

        //default constructor
        public Application()
        {
            carList =   new List<Car>();        //creating a new list of car objects
            busList =   new List<Bus>();        //creating a new list of bus objects
            truckList = new List<Truck>();      //creating a new list of truck objects
            running =   true;                   //setting the running state of the Run method to true
        }

        //copy constructor
        public Application( Application other ) : this( other.carList,other.busList,other.truckList ) { }

        //method for operating with the application
        public void Run()
        {
            ConsoleKeyInfo infoMain;    //variable for operating in the main menu
            ConsoleKeyInfo infoSub;     //variable for operating in the sub menus
            ConsoleKeyInfo infoModify;  //variable for operating in the modification sub menu

            while (running) //while the running state is true
            {
                Console.Clear();                                                    //clearing the console window
                Console.WriteLine( "To add a new object press 1" );                 //awaiting input
                Console.WriteLine( "To modify an object press 2" );                 //awaiting input
                Console.WriteLine( "To print a certain list of objects press 3" );  //awaiting input
                Console.WriteLine( "To exit press 0" );                             //awaiting input

                infoMain = Console.ReadKey();                                       //getting the input data

                switch( infoMain.Key )            //determining which action to take using the input
                {
                    case ConsoleKey.D0: //if 0 is pressed
                        {
                            running = false; //terminating the run
                            break;
                        } //end of main case 0
                    case ConsoleKey.D1: //if 1 is pressed
                        {
                            Console.Clear();                                            //clearing the console window
                            Console.WriteLine( "To add a new car press 1" );            //awaiting input
                            Console.WriteLine( "To add a new bus press 2" );            //awaiting input
                            Console.WriteLine( "To add a new truck press 3" );          //awaiting input
                            Console.WriteLine( "To return to the main menu press 4" );  //awaiting input
                            Console.WriteLine( "To exit press 0" );                     //awaiting input
                            infoSub = Console.ReadKey();                                //getting the input data
                            switch (infoSub.Key)                                        //determining which action to take using the input
                            {
                                case ConsoleKey.D0: //if 0 is pressed
                                    {
                                        running = false; //terminating the run
                                        break;
                                    } //end of sub case 0
                                case ConsoleKey.D4: //if 4 is pressed
                                    {
                                        //returning to the main menu
                                        break;
                                    } //end of sub case 4
                                case ConsoleKey.D1: //if 1 is pressed
                                    {
                                        double  tankVolume;             //the amount of fuel the vehicle can carry
                                        string  brand;                  //the brand of the vehicle
                                        string  model;                  //the model of the vehicle
                                        short   year;                   //the year the vehicle was created
                                        string  generalConditionATM;    //describing the general condition of the vehicle at the moment
                                        short   numberOfSeats;          //number of seats of the car
                                        string  typeOfCar;              //type of the car

                                        try //trying to parse the string input into double variable
                                        {
                                            Console.Clear();                                    //clearing the console window
                                            Console.Write( "Insert the tank volume: " );        //awaiting input
                                            tankVolume = double.Parse( Console.ReadLine() );    //parsing the input data
                                        }
                                        catch(FormatException ex) //if parsing fails
                                        {
                                            Console.Clear();                    //clearing the console window
                                            Console.WriteLine( ex.Message );    //giving appropriate message to the user
                                            running = false;                    //terminating the run
                                            break;
                                        }

                                        Console.Clear();                                    //clearing the console window
                                        Console.Write( "Insert the name of the brand: " );  //awaiting input
                                        brand = Console.ReadLine();                         //getting the input data

                                        Console.Clear();                                    //clearing the console window
                                        Console.Write( "Insert the name of the model: " );  //awaiting input
                                        model = Console.ReadLine();                         //getting the input data

                                        try //trying to parse the string input into short variable
                                        {
                                            Console.Clear();                                                    //clearing the console window
                                            Console.Write( "Insert the year in which the car was produced: " ); //awaiting input
                                            year = short.Parse( Console.ReadLine() );                           //parsing the input data
                                        }
                                        catch ( FormatException ex ) //if parsing fails
                                        {
                                            Console.Clear();                    //clearing the console window
                                            Console.WriteLine( ex.Message );    //giving appropriate message to the user
                                            running = false;                    //terminating the run
                                            break;
                                        }

                                        Console.Clear();                                                                //clearing the console window
                                        Console.Write( "Describe the general condition of the car at the moment: " );   //awaiting input
                                        generalConditionATM = Console.ReadLine();                                       //getting the input data

                                        try //trying to parse the string input into short variable
                                        {
                                            Console.Clear();                                    //clearing the console window
                                            Console.Write( "Insert the number of seats: " );    //awaiting input
                                            numberOfSeats = short.Parse( Console.ReadLine() );  //parsing the input data
                                        }
                                        catch (FormatException ex) //if parsing fails
                                        {
                                            Console.Clear();                    //clearing the console window
                                            Console.WriteLine( ex.Message );    //giving appropriate message to the user
                                            running = false;                    //terminating the run
                                            break;
                                        }

                                        Console.Clear();                                                                                        //clearing the console window
                                        Console.WriteLine( "Insert the type of the car(sedan, hatch, wagon, van or suv): " );                   //awaiting input
                                        typeOfCar = Console.ReadLine();                                                                         //getting the input data

                                        carList.Add(new Car( tankVolume, brand, model, year, generalConditionATM, numberOfSeats, typeOfCar) );  //adding the new object to the list
                                        Console.Clear();                                                                                        //clearing the console window
                                        Console.WriteLine( "The new car object has been successfully created" );                                //stating that the creation was successful
                                        Console.WriteLine( "Press any key to continue" );                                                       //awaiting input
                                        Console.ReadKey();                                                                                      //getting the input data

                                        break;
                                    } //end of subcase 1
                            } //end of sub switch 1
                            break;
                        } //end of main case 1
                    case ConsoleKey.D2: //if 2 is pressed
                        {
                            Console.Clear();                                            //clearing the console window
                            Console.WriteLine( "To modify a car press 1" );             //awaiting input
                            Console.WriteLine( "To modify a bus press 2" );             //awaiting input
                            Console.WriteLine( "To modify a truck press 3" );           //awaiting input
                            Console.WriteLine( "To return to the main menu press 4" );  //awaiting input
                            Console.WriteLine( "To exit press 0" );                     //awaiting input
                            infoSub = Console.ReadKey();                                //getting the input data
                            switch( infoSub.Key ) //determining which action to take using the input
                            {
                                case ConsoleKey.D0: //if 0 is pressed
                                    {
                                        running = false; //terminating the run
                                        break;
                                    } //end of sub case 0
                                case ConsoleKey.D4: //if 4 is pressed
                                    {
                                        //returning to the main menu
                                        break;
                                    } //end of sub case 4
                                case ConsoleKey.D1: //if 1 is pressed
                                    {
                                        Console.Clear();                                            //clearing the console window
                                        Console.WriteLine( "To add a crash press 1" );              //awaiting input
                                        Console.WriteLine( "To change the general info press 2" );  //awaiting input
                                        Console.WriteLine( "To return to the main menu press 3" );  //awaiting input
                                        Console.WriteLine( "To exit press 0" );                     //awaiting input
                                        infoModify = Console.ReadKey();                             //getting the input data
                                        switch( infoModify.Key ) //determining which action to take using the input
                                        {
                                            case ConsoleKey.D0: //if 0 is pressed
                                                {
                                                    running = false; //terminating the run
                                                    break;
                                                } //end of modification case 0
                                            case ConsoleKey.D4: //if 4 is pressed
                                                {
                                                    //returning to the main menu
                                                    break;
                                                } //end of modification case 4
                                            case ConsoleKey.D1: //id 1 is pressed
                                                {
                                                    string crash;
                                                    int index;
                                                    try
                                                    {
                                                        Console.Clear();                                                        //clearing the console window
                                                        Console.WriteLine( "Insert the index of the car you want to change");   //awaiting input
                                                        index = int.Parse( Console.ReadLine() );                                //parsing the input data
                                                        Console.Clear();                                                        //clearing the console window
                                                        Console.WriteLine( "Insert the crash description" );                    //awaiting input
                                                        crash = Console.ReadLine();                                             //getting the input data

                                                        if ( index > 0 && index <= carList.Count ) //validating input
                                                        {
                                                            carList[ index - 1 ].additionalInfo.AddCrash( crash );                      //adding the new crash
                                                            Console.Clear();                                                            //clearing the console window
                                                            Console.WriteLine( "The crash was successfully added to the object info" ); //giving information for the successful addition
                                                            Console.WriteLine( "Press any key to continue" );                           //awaiting input
                                                            Console.ReadKey();                                                          //getting the input data
                                                        }
                                                        else //if the input is incorrect
                                                        {
                                                            Console.Clear();                                //clearing the console window
                                                            throw new ArgumentException( "Invalid index" ); //giving the user appropriate error message
                                                        }
                                                    }
                                                    catch(FormatException ex) //if the parsing fails
                                                    {
                                                        Console.Clear();                    //clearing the console window
                                                        Console.WriteLine( ex.Message );    //giving the user appropriate error message
                                                        running = false;                    //terminating the run
                                                        break;
                                                    }
                                                    break;
                                                } //end of modification case 1
                                            case ConsoleKey.D2: //if 2 is pressed
                                                {
                                                    string info;
                                                    int index;
                                                    try
                                                    {
                                                        Console.Clear();                                                        //clearing the console window
                                                        Console.WriteLine( "Insert the index of the car you want to change" );  //awaiting input
                                                        index = int.Parse( Console.ReadLine() );                                //parsing the input data
                                                        Console.Clear();                                                        //clearing the console window
                                                        Console.WriteLine( "Insert the new general description" );              //awaiting input
                                                        info = Console.ReadLine();                                              //getting the input data

                                                        if ( index > 0 && index <= carList.Count ) //validating input
                                                        {
                                                            carList[ index - 1 ].additionalInfo.Condition = info;                           //changing the general info of the car
                                                            Console.Clear();                                                                //clearing the console window
                                                            Console.WriteLine( "The general info was successfully change for the object" ); //giving information for the successful change
                                                            Console.WriteLine( "Press any key to continue" );                               //awaiting input
                                                            Console.ReadKey();                                                              //getting the input data
                                                        }
                                                        else //if the input is incorrect
                                                        {
                                                            Console.Clear();                                //clearing the console window
                                                            throw new ArgumentException( "Invalid index" ); //giving the user appropriate error message
                                                        }
                                                    }
                                                    catch (FormatException ex) //if the parsing fails
                                                    {
                                                        Console.Clear();                    //clearing the console window
                                                        Console.WriteLine( ex.Message );    //giving the user appropriate error message
                                                        running = false;                    //terminating the run
                                                        break;
                                                    }
                                                    break;
                                                } //end of modification case 2
                                        } //end of modification switch
                                        break;
                                    }
                            }
                            break;
                        } //end of main case 2
                    case ConsoleKey.D3: //if 3 is pressed
                        {
                            Console.Clear();                                                    //clearing the console window
                            Console.WriteLine( "To display all cars press 1" );                 //awaiting input
                            Console.WriteLine( "To display all buses press 2" );                //awaiting input
                            Console.WriteLine( "To display all trucks press 3" );               //awaiting input
                            Console.WriteLine( "To return to the main menu press 4" );          //awaiting input
                            Console.WriteLine( "To exit press 0" );                             //awaiting input
                            infoSub = Console.ReadKey();                                        //getting the input data
                            switch( infoSub.Key) //determining which action to take using the input
                            {
                                case ConsoleKey.D0: //if 0 is pressed
                                    {
                                        running = false; //terminating the run
                                        break;
                                    } //end of sub case 0
                                case ConsoleKey.D4: //if 4 is pressed
                                    {
                                        //returning to the main menu
                                        break;
                                    } //end of sub case 4
                                case ConsoleKey.D1: //if 1 is pressed
                                    {
                                        if ( carList.Count == 0 ) //checking if the list of cars is empty
                                        {
                                            Console.Clear();                          //clearing the console window
                                            Console.WriteLine( "The list is empty" ); //giving info to the user
                                        }
                                        else //if the list has elements
                                        {
                                            Console.Clear();                            //clearing the console window
                                            var itemsForDisplay =                       //making a LINQ query
                                                from car in carList                     //from the list of cars
                                                orderby car.Brand, car.Model, car.Year  //ordering them first by brand, second by model and third by year
                                                select car;                             //finishing the query
                                            foreach (var item in itemsForDisplay) //foreach item in the query
                                            {
                                                item.GiveInfo(); //display the GiveInfo method for the current item
                                            }
                                        }
                                        Console.WriteLine( "Press any key to continue" ); //awaiting input
                                        Console.ReadKey();                                //getting the input
                                        break;
                                    } //end of sub case 1
                            }
                            break;
                        } //end of main case 3
                } //end of main case
            }
        }
    }
}
