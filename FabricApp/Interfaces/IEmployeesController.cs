using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
#pragma warning disable CS1998
    public interface IEmployeesController
    {
        public List<Models.Employee> GetFromDB() => throw new NotImplementedException();

        public List<Models.Employee> GetFromXML(string xml);

        public async void SaveFromXML() => throw new NotImplementedException();


        public int DeleteFromDB(int id);
        public async Task<int> UpdateInDb(Models.Employee employee) => throw new NotImplementedException();

        public async Task<int> AddToDb(Models.Employee employee) => throw new NotImplementedException();
    }
}

