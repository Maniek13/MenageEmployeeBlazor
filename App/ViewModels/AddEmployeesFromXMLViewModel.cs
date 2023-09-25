using FabricAPP.Controllers;
using FabricAPP.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FabricAPP.ViewModels
{
    public class AddEmployeesFromXMLViewModel : IAddEmployeesFromXMLViewModel
    {
        readonly IEmployeesController employeesController = new EmployeesController();
        public bool ShowedInfo { get; set; }
        public List<Models.Employee> Employees { get; set; }

        public AddEmployeesFromXMLViewModel()
        {
            Employees = new List<Models.Employee>();
        }
        public void ShowInfo()
        {
            ShowedInfo = !ShowedInfo;
        }
        public async Task<bool> SetData(IReadOnlyList<IBrowserFile> files)
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
                Employees = employeesController.GetFromXML(xml);
                return true;
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
                employeesController.SaveFromXML();
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
    }
}
