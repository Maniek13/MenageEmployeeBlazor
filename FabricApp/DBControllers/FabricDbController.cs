using FabricAPP.Data;
using FabricAPP.DBModels;
using FabricAPP.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricAPP.DBControllers
{
    public class FabricDbController : Controller, IFabricDbController
    {
        private readonly FabricContext _context;

        public FabricDbController(FabricContext context)
        {
            _context = context;
        }
        public List<Models.Employee> Get()
        {
            try
            {
                var query = from emp in _context.Employees
                            join address in _context.Addresses
                            on emp.ID equals address.EmployeeID
                            select new Models.Employee
                            {
                                ID = emp.ID,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                ContactNo = emp.ContactNo,
                                Email = emp.Email,
                                Address = new Models.Address
                                {
                                    Street = address.Street,
                                    StreetNr = address.StreetNr,
                                    HouseNr = address.HouseNr,
                                    City = address.City,
                                    Zip = address.Zip
                                }
                            };

                return query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AsyncSet(List<Models.Employee> employees)
        {
            try
            {
                List<Employee> emps = new();
                int nrOfEmp = _context.Employees.Count();

                employees.ForEach(delegate (Models.Employee emp)
                {
                    emps.Add(GetDBEmployee(emp));
                });

                _context.AddRange(emps);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> AsyncAdd(Models.Employee employee)
        {
            try
            {
                Employee emp = GetDBEmployee(employee);
                _context.Add(emp);

                await _context.SaveChangesAsync();
                employee.ID = emp.ID;

                return employee.ID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public void Delete(int id)
        {
            try
            {
                var emp = _context.Employees.FirstOrDefault(x => x.ID == id);
                _context.Remove(emp);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AsyncUpdate(Models.Employee employee)
        {
            try
            {
                Employee emp = _context.Employees.Where(el => el.ID == employee.ID).FirstOrDefault();

                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.ContactNo = employee.ContactNo;
                emp.Email = employee.Email;

                Address adr = _context.Addresses.Where(el => el.EmployeeID == employee.ID).FirstOrDefault();

                adr.Street = employee.Address.Street;
                adr.StreetNr = employee.Address.StreetNr;
                adr.HouseNr = employee.Address.HouseNr;
                adr.City = employee.Address.City;
                adr.Zip = employee.Address.Zip;

                emp.Address = adr;

                _context.Update(emp);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static Employee GetDBEmployee(Models.Employee emp)
        {
            Address address = new()
            {
                Street = emp.Address.Street,
                StreetNr = emp.Address.StreetNr,
                HouseNr = emp.Address.HouseNr,
                City = emp.Address.City,
                Zip = emp.Address.Zip
            };

            Employee e = new()
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                ContactNo = emp.ContactNo,
                Email = emp.Email,
                Address = address
            };

            return e;
        }
    }
}
