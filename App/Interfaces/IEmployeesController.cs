using System;
using System.Collections.Generic;

namespace FabricAPP.Interfaces
{
    public interface IEmployeesController
    {
        public List<Models.Employee> GetFromDB();

        public List<Models.Employee> GetFromXML(string xml);

        public void Save();
        public int Edit(Models.Employee employee);

        public int DeleteFromDB(Models.Employee employee);
        public int UpdateInDb(Models.Employee employee);
#pragma warning disable CS1998
        public async void Add(Models.Employee employee) => throw new NotImplementedException();
#pragma warning restore CS1998
    }
}

