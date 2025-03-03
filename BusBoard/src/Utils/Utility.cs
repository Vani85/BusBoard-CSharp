using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

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
}