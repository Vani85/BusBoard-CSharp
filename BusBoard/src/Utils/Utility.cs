namespace BusBoard.src.Utils;
class Utility {
    public static int ConvertSecondsToMinutes(int seconds) {
        return TimeSpan.FromSeconds(seconds).Minutes;
    }
}