using BusBoard.src.DataClass;
using BusBoard.src.Utils;

namespace BusBoard.sr.Report;
class PrintReport() {
    public void printArrivalInformations(List<ArrivalsForAStopPoint> arrivals) {
        Console.WriteLine("=========================================================================================================================");   
        Console.WriteLine("+-------------------------------+------------------------------+----------------------------+----------------------------+");
        Console.WriteLine("| {0,-30} | {1,-10} | {2,-50} | {3,-15} |", "Station Name", "Line ID", "Destination", "Time (in mins)");
        Console.WriteLine("+-------------------------------+------------------------------+----------------------------+----------------------------+");
        
        foreach(var bus in arrivals) {
            Console.WriteLine("| {0,-30} | {1,-10} | {2,-50} | {3,-15} |", 
                bus.stationName,
                bus.lineId,
                bus.destinationName,
                Utility.ConvertSecondsToMinutes(bus.timeToStation));   
        }
         Console.WriteLine("========================================================================================================================");        
        
    }
}