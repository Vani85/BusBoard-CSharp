using BusBoard.src.DataClass;
using BusBoard.src.Client;
using BusBoard.sr.Report;
using BusBoard.src.Utils;
namespace BusBoard {
    class BusBoardApp {
        private static PrintReport printReport;
        private static TFLClient tflClient = new();
        public async static Task Main () {
            try {
                // Post code to stop points
                string postCode = UserInput.GetPostCodeFromUser();                
                var postCodeInfo = await PostCodeClient.GetPostCodeInformation(postCode);        
                List<StopPointsForPostCode> stopPoints = await tflClient.GetStopPointsForthePostCode(postCodeInfo.latitude,postCodeInfo.longitude);                
                Console.WriteLine($"Count of stop points near the postcode - {postCode} is {stopPoints.Count()}");

                printReport =  new PrintReport(); 
                if(!Utility.IsListEmpty(stopPoints)) {
                    await FetchArrivals(stopPoints);
                    await PlanJourney(stopPoints,postCode);                   
                } else {
                    Console.WriteLine($"Could not find any stop points near the postcode - {postCode}");
                }

            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public async static Task FetchArrivals (List<StopPointsForPostCode> stopPoints) {            
            // Stop points to arrival information   
            foreach(var stop in stopPoints) {
                List<ArrivalsForAStopPoint> arrivals = await tflClient.GetBussesForAGivenStopPoint(stop.naptanId);  
                if(!Utility.IsListEmpty(arrivals)) {
                    arrivals = Utility.SortAndSliceArrivals(arrivals);
                    printReport.printArrivalInformations(arrivals);
                } else {
                    Console.WriteLine($"Could not find any arrivals at the stop point : {stop.commonName}");
                }
            } 
        }
        public async static Task PlanJourney (List<StopPointsForPostCode> stopPoints, string postCode) {            
            if(UserInput.GetJourneyPlannerChoice().Equals("Y")) {
                string ChoosenStopPoint = UserInput.ChooseTheStopPoint(stopPoints);
                List<Journey> journeys = await tflClient.GetDirectionToStopPoint(postCode, ChoosenStopPoint); 
                printReport.PrintJourneyPlanner(journeys);
            }
        }

    }
}