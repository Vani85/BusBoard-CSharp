using BusBoard.src.DataClass;
using BusBoard.src.Client;
using BusBoard.sr.Report;
namespace BusBoard {
    class BusBoardApp {
        public async static Task Main () {

             PrintReport printReport =  new PrintReport();

            // Post code to Stop points
            Console.WriteLine("Please enter the post code.");
            string postCode = Console.ReadLine();
            var postCodeInfo = await TFLClient.getPostCodeInformation(postCode);        
            StopPointsAPIResponse stopPoints = await TFLClient.getStopPointsForthePostCode(postCodeInfo.Result.latitude,postCodeInfo.Result.longitude);
            
            // Stop points to arrival information           
            foreach(var stop in stopPoints.stopPoints) {
                List<ArrivalsForAStopPoint> arrivals = await TFLClient.getBussesForAGivenStopPoint(stop.naptanId);            
                printReport.printArrivalInformations(arrivals);
            }
        }
    }
}