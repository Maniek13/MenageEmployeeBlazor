using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
    public interface IFabricDbController
    {
        public List<Models.Employee> Get();

        public Task AsyncSet(List<Models.Employee> employees);
        public Task<int> AsyncAdd(Models.Employee employee);


        public void Delete(int id);

        public Task AsyncUpdate(Models.Employee employee);

    }
}
