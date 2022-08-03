using Employee.API.Models;

namespace Employee.API
{
    public class EmployeeData
    {
        public List<EmployeeViewModel> employeesList { get; set; }

        public EmployeeData()
        {
            employeesList = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel()
                {
                    Id = 1,
                    FirstName = "Radhika",
                    LastName = "Veeram",
                    MobileNumber = "9347818349",
                    Email = "Radhika@gmail.com",
                    AddressLine1 = "Flat No -7656",
                    AddressLine2 = "Devendar nagar, Jerssey Road",
                    City = "Hyderabad",
                    PostalCode = "987654",
                    Country = "India"
                },
                new EmployeeViewModel()
                {
                    Id = 2,
                    FirstName = "Rishi",
                    LastName = "Kumar",
                    MobileNumber = "9876547654",
                    Email = "Rishi@gmail.com",
                    AddressLine1 = "Flat No -11A03",
                    AddressLine2 = "Uppal",
                    City = "Hyderabad",
                    PostalCode = "876765",
                    Country = "India"
                },
                new EmployeeViewModel()
                {
                    Id = 3,
                    FirstName = "Keerthi",
                    LastName = "Sudha",
                    MobileNumber = "8768768764",
                    Email = "Keerthi@gmail.com",
                    AddressLine1 = "Flat No -12A03",
                    AddressLine2 = "uppal X road",
                    City = "Hyderabad",
                    PostalCode = "3445555",
                    Country = "India"
                }
            };
        }
    }
}

