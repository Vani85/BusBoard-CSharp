using BusBoard.src.DataClass;

namespace BusBoard.src.Utils {
    class UserInput {        
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

         public static string GetJourneyPlannerChoice() {
            string JourneyPlannerChoice = "";
            while(true) {
                Console.WriteLine("Do you wish to view the journey planner Y/N?");
                JourneyPlannerChoice = Console.ReadLine().ToUpper();
                if(JourneyPlannerChoice.Equals("Y") || JourneyPlannerChoice.Equals("N")) {
                    return JourneyPlannerChoice;
                } else {
                    Console.WriteLine($"Please enter a valid choice.");
                }
            }
        }

        public static string ChooseTheStopPoint(List<StopPointsForPostCode> stopPoints) {
            Console.WriteLine("Choose the stop point to which journey planner is required.");
            int i = 1;
            stopPoints.ForEach((stop) => Console.WriteLine($"{i++} : {stop.commonName}"));
            string choice = Console.ReadLine();
            return stopPoints[Convert.ToInt32(choice)-1].naptanId;
        }
    }
}

