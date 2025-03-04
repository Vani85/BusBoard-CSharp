namespace BusBoard.src.Utils {
    class UserInput {        
        public static string GetPostCodeFromUser() {
            string PostCode = "";
            while(true) {
                Console.WriteLine("Please enter the post code.");
                PostCode = Console.ReadLine();
                if(Utility.validatePostCode(PostCode)) {
                    return PostCode;
                } else {
                    Console.WriteLine($"The postcode - {PostCode} is invalid.");
                }
            }
        }
    }
}

