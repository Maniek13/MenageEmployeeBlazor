using FabricAPP.Models;
using System;
using System.Collections.Generic;

namespace FabricAPP.Interfaces
{
    public interface IShowEmployeesViewModel
    {
        public List<Employee> Employees { get; set; }
#pragma warning disable CS1998
        public void Delete(Employee employee) => throw new NotImplementedException();

        public async void Save(Models.Employee employee) => throw new NotImplementedException();
    }
}
