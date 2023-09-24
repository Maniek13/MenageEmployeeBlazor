using FabricAPP.Controllers;
using FabricAPP.DBModels;
using FabricAPP.Interfaces;
using System;

namespace FabricAPP.ViewModels
{
    public class AddEmployeeViewModel : IAddEmployeeViewModel
    {
        readonly IEmployeesController employeesController = new EmployeesController();
        public Models.Employee Employee { get; set; } = new Models.Employee()
        {
            FirstName = "",
            LastName = "",
            ContactNo = 0,
            Email = "",
            Address = new()
            {
                City = "",
                Street = "",
                StreetNr = "",
                HouseNr = "",
                Zip = 0
            }
        };

        public void AddUser()
        {
            try
            {
                SetIsValueOk();
                employeesController.Add(Employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void SetIsValueOk()
        {
            if (String.IsNullOrEmpty(Employee.FirstName))
                throw new Exception("Please write a name");
            if (String.IsNullOrEmpty(Employee.LastName))
                throw new Exception("Please write a last name");
            if (Employee.ContactNo < 0 || Employee.ContactNo.ToString().Length < 9)
                throw new Exception("Please write a number in format: (0048123456789) 0048 is a code for poland");
            if (String.IsNullOrEmpty(Employee.Email))
                throw new Exception("Please write an email");

            if (String.IsNullOrEmpty(Employee.Address.City))
                throw new Exception("Please write a city name");
            if (String.IsNullOrEmpty(Employee.Address.Street))
                throw new Exception("Please write a street");
            if (String.IsNullOrEmpty(Employee.Address.StreetNr))
                throw new Exception("Please write a street nr");
            if (Employee.ContactNo < 0 || Employee.Address.Zip.ToString().Length != 5)
                throw new Exception("Please write a zipcode in format: 00000");
        }
    }
}
