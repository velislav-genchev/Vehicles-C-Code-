using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApplication
{
    //main class
    public class Program
    {
        //main method
        public static void Main(string[] args)
        {
            Application application = new Application();    //creating new Application object
            application.Run();                              //calling its run method
        }
    }
}
