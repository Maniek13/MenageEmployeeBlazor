using FabricAPP.Interfaces;
using FabricAPP.Providers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FabricAPP.ViewModels
{
    public class InternalLoginControllViewModel : ValidationAttribute, IInternalLoginControllViewModel
    {
        readonly IFabricDbControllerProvider fabricControllerProvider;
        public InternalLoginControllViewModel()
        {
            fabricControllerProvider = new FabricDbControllerProvider(new Data.FabricContext());
        }
        [ValidateComplexType]

        public Models.User User { get; set; } = new Models.User()
        {
            Login = "",
            Password = "",
        };

        public async Task AsyncLogin()
        {
            try
            {
                throw new NotImplementedException();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
