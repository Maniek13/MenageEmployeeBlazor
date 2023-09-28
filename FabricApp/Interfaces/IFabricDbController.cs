using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
    public interface IFabricDbController
    {
        public List<Models.Employee> Get();

        public async Task<bool> Set(List<Models.Employee> employees) => throw new NotImplementedException();

        public async Task<int> Add(Models.Employee employee) => throw new NotImplementedException();


        public int Delete(int id);

        public async Task<int> Update(Models.Employee employee) => throw new NotImplementedException();

    }
}
