using FabricAPP.Data;
using FabricAPP.Interfaces;
using FabricAPP.Providers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FabricAPP.ViewModels
{
    public class AddEmployeeViewModel : ValidationAttribute, IAddEmployeeViewModel
    {
        readonly IFabricDbControllerProvider fabricControllerProvider;

        public AddEmployeeViewModel()
        {
            fabricControllerProvider = new FabricDbControllerProvider(new Data.FabricContext());
        }
        [ValidateComplexType]
   
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
                return await fabricControllerProvider.AddToDb(Employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #region forTests
        public AddEmployeeViewModel(FabricContext dbContext)
        {
            fabricControllerProvider = new FabricDbControllerProvider(dbContext);
        }
        #endregion
    }
}
