using FabricAPP.Providers;
using FabricAPP.DBModels;
using FabricAPP.Interfaces;
using System;
using System.Threading.Tasks;
using FabricAPP.Data;
using FabricAPP.XMLModels;

namespace FabricAPP.ViewModels
{
    public class AddEmployeeViewModel : IAddEmployeeViewModel
    {
        readonly IFabricDbControllerProvider fabricControllerProvider;

        public AddEmployeeViewModel()
        {
            fabricControllerProvider = new FabricDbControllerProvider(new Data.FabricContext());
        }
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
