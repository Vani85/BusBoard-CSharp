using RestSharp;
using BusBoard.src.DataClass;
using Microsoft.VisualBasic;
namespace BusBoard.src.Client {
    class TFLClient : TFLClientAbstract {
        public override async Task<List<StopPointsForPostCode>> GetStopPointsForthePostCode(double latitude, double longitude) {
            var request = GetRestRequest($"StopPoint/")
                        .AddQueryParameter("lat",latitude.ToString())
                        .AddQueryParameter("lon", longitude.ToString())
                        .AddQueryParameter("stopTypes","NaptanPublicBusCoachTram")
                        .AddQueryParameter("modes","bus");

            return (await GetResponse<StopPointsAPIResponse>(request,$"Failed to fetch stop points for latitude : {latitude} and longitude : {longitude} .")).stopPoints;
        }  

        public override async Task<List<ArrivalsForAStopPoint>> GetBussesForAGivenStopPoint(string stopPoint) {
            var request = GetRestRequest($"StopPoint/{stopPoint}/Arrivals");
            return await GetResponse<List<ArrivalsForAStopPoint>>(request,$"Failed to fetch arrival information for stop point : {stopPoint} ");
        }       

        public override async Task<List<Journey>> GetDirectionToStopPoint(string postCode, string stopPoint) {
            var request = GetRestRequest($"Journey/JourneyResults/{postCode}/to/{stopPoint}");
            return (await GetResponse<JourneyPlannerAPIResponse>(request,$"Failed to fetch arrival information for stop point : {stopPoint} ")).journeys;               
        }
    }
}