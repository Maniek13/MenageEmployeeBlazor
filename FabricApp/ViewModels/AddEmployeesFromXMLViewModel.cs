using FabricAPP.Data;
using FabricAPP.Interfaces;
using FabricAPP.Providers;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FabricAPP.ViewModels
{
    public class AddEmployeesFromXMLViewModel : IAddEmployeesFromXMLViewModel
    {
        readonly IFabricDbControllerProvider fabricControllerProvider;
        public bool ShowedInfo { get; set; }
        public List<Models.Employee> Employees { get; set; }

        public AddEmployeesFromXMLViewModel()
        {
            fabricControllerProvider = new FabricDbControllerProvider(new Data.FabricContext());
            Employees = new List<Models.Employee>();
        }
        public void ShowInfo()
        {
            ShowedInfo = !ShowedInfo;
        }
        public async Task AsyncSetData(IReadOnlyList<IBrowserFile> files)
        {
            try
            {
                string xml = "";

                foreach (var file in files)
                {
                    using var stream = file.OpenReadStream();
                    using var reader = new StreamReader(stream);
                    xml = await reader.ReadToEndAsync();
                }
                Employees = fabricControllerProvider.GetFromXML(xml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void Save()
        {
            try
            {
                fabricControllerProvider.AsyncSaveFromXML();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Delete(Models.Employee employee)
        {
            try
            {
                Employees.Remove(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #region forTests
        public AddEmployeesFromXMLViewModel(FabricContext dbContext)
        {
            fabricControllerProvider = new FabricDbControllerProvider(dbContext);
            Employees = fabricControllerProvider.GetFromDB();
        }
        #endregion
    }
}
