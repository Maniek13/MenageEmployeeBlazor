using System;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
    public interface IAddEmployeeViewModel
    {
        public Models.Employee Employee { get; set; }
#pragma warning disable CS1998
        public async Task<int> AddUser() => throw new NotImplementedException();
    }
}
