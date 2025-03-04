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


     public void PrintJourneyPlanner(List<Journey> journeys) {
        Console.WriteLine("=========================================================================================================================");   
        Console.WriteLine("+-------------------------------+------------------------------+----------------------------+----------------------------+");
        Console.WriteLine("| {0,-50} | {1,-30} | {2,-20} | {3,-20} |", "Step Description", "Step Direction", "Total Distance", "Total Time (in mins)");
        Console.WriteLine("+-------------------------------+------------------------------+----------------------------+----------------------------+");
        

        foreach(var journey in journeys) {
            foreach(var leg in journey.legs) {
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine(leg.instruction.summary);
                Console.WriteLine("========================================================================================================================");
                foreach(var step in leg.instruction.steps) {
                    Console.WriteLine("| {0,-50} | {1,-30} | {2,-20} | {3,-20} |", 
                        step.description.Trim(),
                        step.turnDirection.Trim(),
                        step.distance,
                        step.cumulativeTravelTime);  
                }
            }
        }
        Console.WriteLine("+-------------------------------+------------------------------+----------------------------+----------------------------+");
   }
}