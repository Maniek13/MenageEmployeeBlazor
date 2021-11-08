using System;
using System.IO;
using FabricAPP.XMLObjects;
using System.Xml.Serialization;
using System.Collections.Generic;
using FabricAPP.DBControllers;
using FabricAPP.Data;
using System.Linq;

namespace FabricAPP.Controllers
{
    public class EmployeesController
    {
        private static readonly List<Objects.Employee> EmployeesList = new();

        public static List<Objects.Employee> GetFromDB()
        {
            FabricController fabric = new(new FabricContext());
            return fabric.Get();
        }


        public static List<Objects.Employee> GetFromXML(string xml)
        {

            XmlSerializer serializer = new (typeof(Employees));
            using StringReader reader = new(xml);
            try
            {
                EmployeesList.Clear();
                Employees employees = (Employees)serializer.Deserialize(reader);
                
                foreach(Employee employee in employees.Employee)
                {
                    Objects.Address adress = new()
                    {
                        Street = employee.Address.Street,
                        StreetNr = employee.Address.StreetNr,
                        HouseNr = employee.Address.HouseNr,
                        City = employee.Address.City,
                        Zip = employee.Address.Zip
                    };

                    Objects.Employee emp = new()
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
                Console.WriteLine("Save data from xml error: " + e.Message);
            }

            return EmployeesList;
        }

        public static int Save()
        {
            FabricController fabric = new(new FabricContext());
            int res = fabric.Set(EmployeesList);
            if (res > 0 )
            {
                return res;
            }
            else
            {
                return 0;
            }
        }

        public static int Edit(Objects.Employee employee)
        {
            var emp = EmployeesList.Find(el => el.ID == employee.ID);

            if(emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.ContactNo = employee.ContactNo;
                emp.Email = employee.Email;
                emp.Address = employee.Address;

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int DeleteFromDB(Objects.Employee employee)
        {
            FabricController fabric = new(new FabricContext());
            return fabric.Delete(employee);
        }

        public static int UpdateInDb(Objects.Employee employee)
        {
            FabricController fabric = new(new FabricContext());
            return fabric.Update(employee);
        }
    }
}
