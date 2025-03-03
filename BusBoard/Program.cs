using BusBoard.src.DataClass;
using BusBoard.src.Client;
using BusBoard.sr.Report;
using BusBoard.src.Utils;
namespace BusBoard {
    class BusBoardApp {
        public async static Task Main () {
            try {
                PrintReport printReport =  new PrintReport();
                string postCode = "";
                while(true) {
                    // Post code to Stop points
                    Console.WriteLine("Please enter the post code.");
                    postCode = Console.ReadLine();
                    if(Utility.validatePostCode(postCode)) {
                        break;
                    } else {
                        Console.WriteLine($"The postcode - {postCode} is invalid.");
                    }
                }
                var postCodeInfo = await TFLClient.getPostCodeInformation(postCode);        
                StopPointsAPIResponse stopPoints = await TFLClient.getStopPointsForthePostCode(postCodeInfo.Result.latitude,postCodeInfo.Result.longitude);                
                Console.WriteLine($"Count of stop points near the postcode - {postCode} is {stopPoints.stopPoints.Count()}");

                // Stop points to arrival information           
                foreach(var stop in stopPoints.stopPoints) {
                    List<ArrivalsForAStopPoint> arrivals = await TFLClient.getBussesForAGivenStopPoint(stop.naptanId);            
                    printReport.printArrivalInformations(arrivals);
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}