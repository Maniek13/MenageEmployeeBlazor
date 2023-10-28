using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
    public interface IInternalLoginControllViewModel
    {
        public Models.User User { get; set; }
        public Task AsyncLogin();
    }
}
