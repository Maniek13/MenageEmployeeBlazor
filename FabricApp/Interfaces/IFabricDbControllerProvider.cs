using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
#pragma warning disable CS1998
    public interface IFabricDbControllerProvider
    {
        public List<Models.Employee> GetFromDB();

        public List<Models.Employee> GetFromXML(string xml);

        public Task AsyncSaveFromXML();


        public void DeleteFromDB(int id);
        public Task AsyncUpdateInDb(Models.Employee employee);

        public Task<int> AsyncAddToDb(Models.Employee employee);
    }
}

