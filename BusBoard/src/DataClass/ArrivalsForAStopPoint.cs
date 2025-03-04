namespace BusBoard.src.DataClass {
    public class ArrivalsForAStopPoint {
        public required string naptanId {get;set;}
        public required string stationName {get;set;}
        public required string lineId {get;set;}
        public required string destinationName {get;set;}
        public int timeToStation {get;set;}
    }
}