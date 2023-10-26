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
                fabricControllerProvider.DeleteFromDB(employee.ID);
                Employees.Remove(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AsyncSave(Models.Employee employee)
        {
            try
            {
                await fabricControllerProvider.AsyncUpdateInDb(employee);
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
