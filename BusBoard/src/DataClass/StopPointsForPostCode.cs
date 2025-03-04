namespace BusBoard.src.DataClass {
    public class StopPointsForPostCode {
        public required string naptanId {get;set;}       
        public required string commonName {get;set;}
        public double distance {get;set;}
    }
   public class StopPointsAPIResponse {      
        public required List<StopPointsForPostCode> stopPoints {get;set;}
    }
}