using FabricAPP.Data;
using FabricAPP.DBControllers;
using FabricAPP.Exceptions;
using FabricAPP.XMLObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FabricAPP.Controllers
{
    public class EmployeesController
    {
        private static readonly List<Models.Employee> EmployeesList = new();
        private readonly static FabricController fabric = new(new FabricContext());

        public static List<Models.Employee> GetFromDB()
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


        public static List<Models.Employee> GetFromXML(string xml)
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
            catch (Exception e)
            {
                throw new Exception("Save data from xml error: " + e.Message);
            }

            return EmployeesList;
        }

        public static int Save()
        {
            try
            {
                if (EmployeesList.Count > 0)
                {
                    CheckIsCorrectListOfEmployee(EmployeesList);

                    int res = fabric.Set(EmployeesList);

                    if (res > 0)
                    {
                        return res;
                    }
                }
                else
                {
                    throw new Exception("Number of new employers is 0");
                }

                return -1;

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

        public static int Edit(Models.Employee employee)
        {
            try
            {
                CheckIsCorrectEmployee(employee);
                CheckIsCorrectEmployeeAdress(employee.Address);
                var emp = EmployeesList.Find(el => el.ID == employee.ID);

                if (emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.ContactNo = employee.ContactNo;
                    emp.Email = employee.Email;
                    emp.Address = employee.Address;

                    return 1;
                }

                return 0;
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

        public static int DeleteFromDB(Models.Employee employee)
        {
            try
            {
                return fabric.Delete(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static int UpdateInDb(Models.Employee employee)
        {
            try
            {
                CheckIsCorrectEmployee(employee);
                CheckIsCorrectEmployeeAdress(employee.Address);
                return fabric.Update(employee);
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
