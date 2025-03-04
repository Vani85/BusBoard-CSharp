using RestSharp;
using BusBoard.src.DataClass;
namespace BusBoard.src.Client {
    class PostCodeClient {
        private static string PostCodeUrl = "https://api.postcodes.io/";
        public static async Task<PostCodeInformation> GetPostCodeInformation(string postCode) {
            var client = new RestClient(PostCodeUrl);
            var request = new RestRequest($"postcodes/{postCode}");
            var response = await client.GetAsync<PostCodeAPIResponse>(request);     
            if (response == null) {
                throw new Exception($"Failed to fetch data for postcode {postCode}:");
            }             
            return response.Result;
        }  
    }
}