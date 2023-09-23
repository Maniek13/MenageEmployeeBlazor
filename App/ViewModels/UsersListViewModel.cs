using FabricAPP.Exceptions;
using FabricAPP.Interfaces;
using FabricAPP.Models;
using System;
using System.Collections.Generic;

namespace FabricAPP.ViewModels
{
    public class UsersListViewModel : IUsersListViewModel
    {
        public List<Employee> Employees { get; set; } = Controllers.EmployeesController.GetFromDB();
        public void Delete(Employee employee)
        {
            try
            {
                if (Controllers.EmployeesController.DeleteFromDB(employee) == 1)
                    Employees.Remove(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Save(Models.Employee employee)
        {
            try
            {
                if (Controllers.EmployeesController.UpdateInDb(employee) != 1)
                {
                    throw new Exception("Server error");
                }
            }
            catch (IncorectValueOfUserException ex)
            {
                throw new IncorectValueOfUserException($"Employe on id:{employee.ID}: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
