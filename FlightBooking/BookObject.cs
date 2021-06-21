using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking
{
    class BookObject
    {

        public static string FlightSeat { get; set; }
        public static string FlightSchedule { get; set; }
        public static string FlightDestinationFrom { get; set; }
        public static string FlightDestinationTo { get; set; }
       // public static string Fare { get; set; }
        
        /*ja*/
        public static string Firstname { get; set; }
        public static string Lastname { get; set; }

        /*ja modify 6/4/21*/
        public static string Fare_CashAmount { get; set; }
        public static string Fare_CardNum { get; set; }
        public static string Fare_CardAmount { get; set; }

    }
}
