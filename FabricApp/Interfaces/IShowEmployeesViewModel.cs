using FabricAPP.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
    public interface IShowEmployeesViewModel
    {
        public List<Employee> Employees { get; set; }
#pragma warning disable CS1998
        public void Delete(Employee employee);

        public Task AsyncSave(Employee employee);
    }
}
