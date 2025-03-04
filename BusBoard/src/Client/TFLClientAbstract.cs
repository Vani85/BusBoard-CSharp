using RestSharp;
using BusBoard.src.DataClass;
using Microsoft.VisualBasic;
namespace BusBoard.src.Client {
    public abstract class TFLClientAbstract {
        private static string TFLUrl = "https://api.tfl.gov.uk/";
        private static RestClient client;
        public abstract Task<List<StopPointsForPostCode>> GetStopPointsForthePostCode(double latitude, double longitude); 
        public abstract Task<List<ArrivalsForAStopPoint>> GetBussesForAGivenStopPoint(string stopPoint); 
        public abstract Task<List<Journey>> GetDirectionToStopPoint(string postCode, string stopPoint);

        protected static RestRequest GetRestRequest(String resource) {
            client = new RestClient(TFLUrl);
            var request = new RestRequest(resource);
            return request;
        }

        protected static async Task<T> GetResponse<T>(RestRequest request, string errorMessageOnError) {
            var response = await client.GetAsync<T>(request);
            return response == null ? throw new Exception(errorMessageOnError) : response;
        }
    }
}