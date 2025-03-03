using BusBoard.src.DataClass;
using BusBoard.src.Client;
using BusBoard.sr.Report;
using BusBoard.src.Utils;
namespace BusBoard {
    class BusBoardApp {
        public async static Task Main () {
            try {
                // Post code to stop points
                string postCode = GetPostCodeFromUser();                
                var postCodeInfo = await TFLClient.getPostCodeInformation(postCode);        
                StopPointsAPIResponse stopPoints = await TFLClient.getStopPointsForthePostCode(postCodeInfo.Result.latitude,postCodeInfo.Result.longitude);                
                Console.WriteLine($"Count of stop points near the postcode - {postCode} is {stopPoints.stopPoints.Count()}");

                // Stop points to arrival information   
                PrintReport printReport =  new PrintReport();        
                foreach(var stop in stopPoints.stopPoints) {
                    List<ArrivalsForAStopPoint> arrivals = await TFLClient.getBussesForAGivenStopPoint(stop.naptanId);            
                    printReport.printArrivalInformations(arrivals);
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public static string GetPostCodeFromUser() {
            string PostCode = "";
            while(true) {
                Console.WriteLine("Please enter the post code.");
                PostCode = Console.ReadLine();
                if(Utility.validatePostCode(PostCode)) {
                    return PostCode;
                } else {
                    Console.WriteLine($"The postcode - {PostCode} is invalid.");
                }
            }
        }
    }
}