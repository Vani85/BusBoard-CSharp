namespace BusBoard.src.DataClass {
    public class PostCodeInformation {
        public required string postcode {get;set;}
        public double latitude {get;set;}
        public double longitude {get;set;}
    }
   public class PostCodeAPIResponse {
        public required PostCodeInformation Result { get; set; }
    }
}