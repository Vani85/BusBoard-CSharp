namespace BusBoard.src.DataClass {
    public class Journey
    {
        public DateTime startDateTime { get; set; }
        public int duration { get; set; }
        public DateTime arrivalDateTime { get; set; }
        public List<Leg> legs { get; set; }
    }
    public class Leg
    {
        public string type { get; set; }
        public int duration { get; set; }
        public Instruction instruction { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }       
    }
     public class Instruction
    {
        public string type { get; set; }
        public string summary { get; set; }
        public string detailed { get; set; }
        public List<Step> steps { get; set; }
    }

    public class Step
    {
        public string description { get; set; }
        public string turnDirection { get; set; }       
        public string descriptionHeading { get; set; }
        public int distance { get; set; }
        public int cumulativeTravelTime { get; set; }
    }

    public class JourneyPlannerAPIResponse {
        public List<Journey> journeys {get;set;}
    }
}