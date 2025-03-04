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

                if(!Utility.IsListEmpty(stopPoints)) {
                    // Stop points to arrival information   
                    PrintReport printReport =  new PrintReport();        
                    foreach(var stop in stopPoints) {
                        List<ArrivalsForAStopPoint> arrivals = await TFLClient.GetBussesForAGivenStopPoint(stop.naptanId);  
                        if(!Utility.IsListEmpty(stopPoints)) {
                            arrivals = Utility.SortAndSliceArrivals(arrivals);
                            printReport.printArrivalInformations(arrivals);
                        } else {
                            Console.WriteLine($"Could not find any arrivals at the stop point : {stop.commonName}");
                        }
                    }                

                    if(UserInput.GetJourneyPlannerChoice().Equals("Y")) {
                        string ChoosenStopPoint = UserInput.ChooseTheStopPoint(stopPoints);
                        List<Journey> journeys = await TFLClient.GetDirectionToStopPoint(postCode, ChoosenStopPoint); 
                        printReport.PrintJourneyPlanner(journeys);
                    }
                } else {
                    Console.WriteLine($"Could not find any stop points near the postcode - {postCode}");
                }

            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

    }
}