using FabricAPP.Data;
using FabricAPP.DBControllers;
using FabricAPP.Exceptions;
using FabricAPP.Interfaces;
using FabricAPP.XMLModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FabricAPP.Providers
{
    public class FabricDbControllerProvider : IFabricDbControllerProvider
    {
        private readonly List<Models.Employee> EmployeesList = new();
        private readonly IFabricDbController fabric;

        public FabricDbControllerProvider(FabricContext dbContext)
        {
            fabric = new FabricDbController(dbContext);
        }

        public List<Models.Employee> GetFromDB()
        {
            try
            {
                return fabric.Get();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Models.Employee> GetFromXML(string xml)
        {

            XmlSerializer serializer = new(typeof(Employees));
            using StringReader reader = new(xml);
            try
            {
                EmployeesList.Clear();
                Employees employees = (Employees)serializer.Deserialize(reader);

                foreach (Employee employee in employees.Employee)
                {
                    Models.Address adress = new()
                    {
                        Street = employee.Address.Street,
                        StreetNr = employee.Address.StreetNr,
                        HouseNr = employee.Address.HouseNr,
                        City = employee.Address.City,
                        Zip = employee.Address.Zip
                    };

                    Models.Employee emp = new()
                    {
                        ID = EmployeesList.Count + 1,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        ContactNo = employee.ContactNo,
                        Email = employee.Email,
                        Address = adress
                    };
                    EmployeesList.Add(emp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return EmployeesList;
        }

        public async Task AsyncSaveFromXML()
        {
            try
            {
                if (EmployeesList.Count > 0)
                {
                    CheckIsCorrectListOfEmployee(EmployeesList);

                    await fabric.AsyncSet(EmployeesList);
                }
                else
                {
                    throw new Exception("No employee");
                }

            }
            catch (IncorectValueOfUserException ex)
            {
                throw new IncorectValueOfUserException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> AsyncAddToDb(Models.Employee employee)
        {
            try
            {
                CheckIsCorrectEmployee(employee);
                CheckIsCorrectEmployeeAdress(employee.Address);
                int id = await fabric.AsyncAdd(employee);
                employee.ID = id;
                return id;
            }
            catch (IncorectValueOfUserException ex)
            {
                throw new IncorectValueOfUserException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }



        public void DeleteFromDB(int id)
        {
            try
            {
                fabric.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task AsyncUpdateInDb(Models.Employee employee)
        {
            try
            {
                CheckIsCorrectEmployee(employee);
                CheckIsCorrectEmployeeAdress(employee.Address);
                await fabric.AsyncUpdate(employee);
            }
            catch (IncorectValueOfUserException ex)
            {
                throw new IncorectValueOfUserException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static void CheckIsCorrectEmployee(Models.Employee employee)
        {
            try
            {
                if (employee == null)
                    throw new IncorectValueOfUserException($"Please write a name");
                if (string.IsNullOrEmpty(employee.FirstName))
                    throw new IncorectValueOfUserException("Please write a name");
                if (string.IsNullOrEmpty(employee.LastName))
                    throw new IncorectValueOfUserException("Please write a last name");

                Helpers.CheckValueHelper.CheckIsPhoneNr(employee.ContactNo);

                if (string.IsNullOrEmpty(employee.Email))
                    throw new IncorectValueOfUserException("Please write an email");
            }
            catch (IncorectValueOfUserException ex)
            {
                throw new IncorectValueOfUserException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static void CheckIsCorrectEmployeeAdress(Models.Address address)
        {

            try
            {
                if (address == null)
                    throw new IncorectValueOfUserException("Adres is empty");
                if (string.IsNullOrEmpty(address.City))
                    throw new IncorectValueOfUserException("Please write a city name");
                if (string.IsNullOrEmpty(address.Street))
                    throw new IncorectValueOfUserException("Please write a street");
                if (string.IsNullOrEmpty(address.StreetNr))
                    throw new IncorectValueOfUserException("Please write a street nr");

                Helpers.CheckValueHelper.CheckIsZipNumbers(address.Zip);
            }
            catch (IncorectValueOfUserException ex)
            {
                throw new IncorectValueOfUserException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static void CheckIsCorrectListOfEmployee(List<Models.Employee> employees)
        {
            int id = 0;
            try
            {
                for (int i = 0; i < employees.Count; ++i)
                {
                    id = i + 1;
                    CheckIsCorrectEmployee(employees[i]);
                    CheckIsCorrectEmployeeAdress(employees[i].Address);
                }
            }
            catch (IncorectValueOfUserException ex)
            {
                throw new IncorectValueOfUserException($"Employee on id: {id}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
