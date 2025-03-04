using BusBoard.src.DataClass;
using BusBoard.src.Client;
using BusBoard.sr.Report;
using BusBoard.src.Utils;
namespace BusBoard {
    class BusBoardApp {
        public async static Task Main () {
            try {
                // Post code to stop points
                string postCode = UserInput.GetPostCodeFromUser();                
                var postCodeInfo = await PostCodeClient.GetPostCodeInformation(postCode);        
                List<StopPointsForPostCode> stopPoints = await TFLClient.GetStopPointsForthePostCode(postCodeInfo.latitude,postCodeInfo.longitude);                
                Console.WriteLine($"Count of stop points near the postcode - {postCode} is {stopPoints.Count()}");

                // Stop points to arrival information   
                PrintReport printReport =  new PrintReport();        
                foreach(var stop in stopPoints.stopPoints) {
                    List<ArrivalsForAStopPoint> arrivals = await TFLClient.GetBussesForAGivenStopPoint(stop.naptanId);    
                    arrivals = SortAndSliceArrivals(arrivals);
                    printReport.printArrivalInformations(arrivals);
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public static List<ArrivalsForAStopPoint> SortAndSliceArrivals(List<ArrivalsForAStopPoint> arrivals) {
            arrivals.Sort((x, y) => x.timeToStation.CompareTo(y.timeToStation));  
            if(arrivals.Count() > 5) {
                arrivals = arrivals.Slice(0,5);
            }
            return arrivals;
        }
    }
}