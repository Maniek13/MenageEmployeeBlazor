using FabricAPP.Models;
using System.Collections.Generic;

namespace FabricAPP.Interfaces
{
    public interface IShowEmployeesViewModel
    {
        public List<Employee> Employees { get; set; }
        public void Delete(Employee employee);

        public void Save(Models.Employee employee);
    }
}
