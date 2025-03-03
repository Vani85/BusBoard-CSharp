namespace BusBoard.src.DataClass {
    public class PostCodeInformation {
        public string postcode {get;set;}
        public double latitude {get;set;}
        public double longitude {get;set;}
    }
   public class PostCodeAPIResponse {
        public PostCodeInformation Result { get; set; }
    }
}