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

        public int DeleteFromDB(Models.Employee employee) => throw new NotImplementedException();
        public int UpdateInDb(Models.Employee employee);

        public void Add(Models.Employee employee);
    }
}

