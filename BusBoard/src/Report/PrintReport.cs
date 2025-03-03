using BusBoard.src.DataClass;
using BusBoard.src.Utils;

namespace BusBoard.sr.Report;
class PrintReport() {
    public void printArrivalInformations(List<ArrivalsForAStopPoint> arrivals) {

        Console.WriteLine("+---------------------+---------------------+---------------------+---------------------+");
        Console.WriteLine("| {0,-15} | {1,-10} | {2,-30} | {3,-15} |", "Naptan ID", "Line ID", "Destination", "Time (in mins)");
        Console.WriteLine("+---------------------+---------------------+---------------------+---------------------+");

        foreach(var bus in arrivals) {
            Console.WriteLine("| {0,-15} | {1,-10} | {2,-30} | {3,-15} |", 
                bus.naptanId,
                bus.lineId,
                bus.destinationName,
                Utility.ConvertSecondsToMinutes(bus.timeToStation));   
        }
    }

    public void printStopPointsInformations(List<ArrivalsForAStopPoint> arrivals) {

        Console.WriteLine("+---------------------+---------------------+---------------------+---------------------+");
        Console.WriteLine("| {0,-15} | {1,-10} | {2,-30} | {3,-15} |", "Naptan ID", "Line ID", "Destination", "Time (in mins)");
        Console.WriteLine("+---------------------+---------------------+---------------------+---------------------+");

        foreach(var bus in arrivals) {
            Console.WriteLine("| {0,-15} | {1,-10} | {2,-30} | {3,-15} |", 
                bus.naptanId,
                bus.lineId,
                bus.destinationName,
                Utility.ConvertSecondsToMinutes(bus.timeToStation));   
        }
    }
}