using FabricAPP.Controllers;
using FabricAPP.Exceptions;
using FabricAPP.Interfaces;
using FabricAPP.Models;
using System;
using System.Collections.Generic;

namespace FabricAPP.ViewModels
{
    public class ShowEmployeesViewModel : IShowEmployeesViewModel
    {
        readonly IEmployeesController employeesController = new EmployeesController();
        public List<Employee> Employees { get; set; }

        public ShowEmployeesViewModel()
        {
            Employees = employeesController.GetFromDB();
        }
        public async void Delete(Employee employee)
        {
            try
            {
                if (employeesController.DeleteFromDB(employee) == 1)
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
                if (employeesController.UpdateInDb(employee) != 1)
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
