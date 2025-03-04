using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using BusBoard.src.DataClass;

namespace BusBoard.src.Utils;
class Utility {
    public static int ConvertSecondsToMinutes(int seconds) {
        return TimeSpan.FromSeconds(seconds).Minutes;
    }

    public static Boolean validatePostCode(string postcode) {
        Regex regex = new Regex(@"^[A-Z]{1,2}\d[A-Z\d]? ?\d[A-Z]{2}$", RegexOptions.IgnoreCase);
        if (regex.IsMatch(postcode)){
            return true;
        } else  {
           return false;
        }
    }
    
    public static List<ArrivalsForAStopPoint> SortAndSliceArrivals(List<ArrivalsForAStopPoint> arrivals) {
        arrivals.Sort((x, y) => x.timeToStation.CompareTo(y.timeToStation));  
        if(arrivals.Count() > 5) {
            arrivals = arrivals.Slice(0,5);
        }
        return arrivals;
    }
    public static bool IsListEmpty<T>(List<T> list) {
        return list.Count == 0;
    }
}