using RestSharp;
using BusBoard.src.DataClass;
using Microsoft.VisualBasic;
namespace BusBoard.src.Client {
    class TFLClient {
        private static string TFLUrl = "https://api.tfl.gov.uk/";
        private static RestClient client;
        public static async Task<List<StopPointsForPostCode>> GetStopPointsForthePostCode(double latitude, double longitude) {
            var request = GetRestRequest($"StopPoint/");
            request.AddQueryParameter("lat",latitude.ToString());
            request.AddQueryParameter("lon", longitude.ToString());
            request.AddQueryParameter("stopTypes","NaptanPublicBusCoachTram");
            request.AddQueryParameter("modes","bus");
            var response = await client.GetAsync<StopPointsAPIResponse>(request); 
            if (response == null) {
                throw new Exception($"Failed to fetch stop points for latitude : {latitude} and longitude : {longitude} .");
            }
            return response.stopPoints;               
        }  

        public static async Task<List<ArrivalsForAStopPoint>> GetBussesForAGivenStopPoint(string stopPoint) {
            var request = GetRestRequest($"StopPoint/{stopPoint}/Arrivals");
            var response = await client.GetAsync<List<ArrivalsForAStopPoint>>(request);
            if (response == null) {
                throw new Exception($"Failed to fetch arrival information for stop point : {stopPoint} ");
            } 
            return response;      
        }          

        public static RestRequest GetRestRequest(String resource) {
            client = new RestClient(TFLUrl);
            var request = new RestRequest(resource);
            return request;
        }
    }
}