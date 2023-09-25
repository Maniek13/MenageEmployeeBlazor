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

namespace FabricAPP.Controllers
{
    public class EmployeesController : IEmployeesController
    {
        private readonly List<Models.Employee> EmployeesList = new();
        private readonly FabricController fabric = new(new FabricContext());

        public List<Models.Employee> GetFromDB()
        {
            try
            {
                var list = fabric.Get();
                return list;
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

        public void SaveFromXML()
        {
            try
            {
                if (EmployeesList.Count > 0)
                {
                    CheckIsCorrectListOfEmployee(EmployeesList);

                    fabric.Set(EmployeesList);
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

        public async Task<int> AddToDb(Models.Employee employee)
        {
            try
            {
                CheckIsCorrectEmployee(employee);

                int id = await fabric.Add(employee);
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



        public int DeleteFromDB(int id)
        {
            try
            {
                return fabric.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<int> UpdateInDb(Models.Employee employee)
        {
            try
            {
                CheckIsCorrectEmployee(employee);
                CheckIsCorrectEmployeeAdress(employee.Address);
                return await fabric.Update(employee);
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
            if (employee == null)
                throw new IncorectValueOfUserException($"User is empty");
            if (string.IsNullOrEmpty(employee.FirstName))
                throw new IncorectValueOfUserException("User first name is empty");
            if (string.IsNullOrEmpty(employee.LastName))
                throw new IncorectValueOfUserException("User last name is empty");
            if (string.IsNullOrEmpty(employee.ContactNo) || employee.ContactNo.Length < 9)
                throw new IncorectValueOfUserException("Plese write a correct number");
            if (string.IsNullOrEmpty(employee.Email))
                throw new IncorectValueOfUserException("User email is empty");
        }

        private static void CheckIsCorrectEmployeeAdress(Models.Address address)
        {
            if (address == null)
                throw new IncorectValueOfUserException("Adres is empty");
            if (string.IsNullOrEmpty(address.City))
                throw new IncorectValueOfUserException("City is empty");
            if (string.IsNullOrEmpty(address.Street))
                throw new IncorectValueOfUserException("Street is empty");
            if (string.IsNullOrEmpty(address.StreetNr))
                throw new IncorectValueOfUserException("Street nr is empty");
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
