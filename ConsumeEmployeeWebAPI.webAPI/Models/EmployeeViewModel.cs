namespace ConsumeEmployeeWebAPI.webAPI.Models
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
