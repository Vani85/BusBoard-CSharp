using RestSharp;
using BusBoard.src.DataClass;
namespace BusBoard.src.Client {
    class TFLClient {
        public static async Task<PostCodeAPIResponse> getPostCodeInformation(string postCode) {
            var client = new RestClient("https://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{postCode}");
            var response = client.Get<PostCodeAPIResponse>(request);     
            if (response == null) {
                throw new Exception($"Failed to fetch data for postcode {postCode}:");
            } else
            {
                return response;
            }   
        }  

         public static async Task<StopPointsAPIResponse> getStopPointsForthePostCode(double latitude, double longitude) {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/");
            request.AddQueryParameter("lat",latitude.ToString());
            request.AddQueryParameter("lon", longitude.ToString());
            request.AddQueryParameter("stopTypes","NaptanPublicBusCoachTram");
            request.AddQueryParameter("modes","bus");
            var response = client.Get<StopPointsAPIResponse>(request);     
            if (response == null) {
                throw new Exception($"Failed to fetch stop points for latitude : {latitude} and longitude : {longitude}");
            } else
            {
                return response;
            }   
        }  

        public static async Task<List<ArrivalsForAStopPoint>> getBussesForAGivenStopPoint(string stopPoint) {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{stopPoint}/Arrivals");
            var response = client.Get<List<ArrivalsForAStopPoint>>(request);
            if (response == null) {
                throw new Exception($"Failed to fetch arrival information for stop point {stopPoint}:");
            } else
            {
                return response;

            }       
        }  

    }
}