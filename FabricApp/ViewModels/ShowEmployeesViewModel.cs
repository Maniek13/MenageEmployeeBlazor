using FabricAPP.Data;
using FabricAPP.Exceptions;
using FabricAPP.Interfaces;
using FabricAPP.Models;
using FabricAPP.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.ViewModels
{
    public class ShowEmployeesViewModel : IShowEmployeesViewModel
    {

        readonly IFabricDbControllerProvider fabricControllerProvider; 
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public ShowEmployeesViewModel()
        {
            fabricControllerProvider = new FabricDbControllerProvider(new Data.FabricContext());
            Employees = fabricControllerProvider.GetFromDB();
            
        }
        public void Delete(Employee employee)
        {
            try
            {
                if (fabricControllerProvider.DeleteFromDB(employee.ID) == 1)
                    Employees.Remove(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool>Save (Models.Employee employee)
        {
            try
            {
                if (await fabricControllerProvider.UpdateInDb(employee) != 1)
                {
                    throw new Exception("Server error");
                }
                return true;
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

        #region forTests
        public ShowEmployeesViewModel(FabricContext dbContext)
        {
            fabricControllerProvider = new FabricDbControllerProvider(dbContext);
            Employees = fabricControllerProvider.GetFromDB();
        }
        #endregion
    }
}
