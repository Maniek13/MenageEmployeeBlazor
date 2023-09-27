using FabricAPP.Controllers;
using FabricAPP.DBModels;
using FabricAPP.Interfaces;
using System;
using System.Threading.Tasks;

namespace FabricAPP.ViewModels
{
    public class AddEmployeeViewModel : IAddEmployeeViewModel
    {
        readonly IEmployeesController employeesController = new EmployeesController(new Data.FabricContext());
        public Models.Employee Employee { get; set; } = new Models.Employee()
        {
            FirstName = "",
            LastName = "",
            ContactNo = "",
            Email = "",
            Address = new()
            {
                City = "",
                Street = "",
                StreetNr = "",
                HouseNr = "",
                Zip = ""
            }
        };

        public async Task<int> AddUser()
        {
            try
            {
                return await employeesController.AddToDb(Employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
