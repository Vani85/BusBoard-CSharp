namespace BusBoard.src.DataClass {
    public class StopPointsForPostCode {
        public string naptanId {get;set;}       
        public string commonName {get;set;}
        public double distance {get;set;}
    }
   public class StopPointsAPIResponse {      
        public List<StopPointsForPostCode> stopPoints {get;set;}
    }
}