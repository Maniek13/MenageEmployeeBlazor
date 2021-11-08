using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FabricAPP.DBModels;
using FabricAPP.Data;
using System.Linq;

namespace FabricAPP.DBControllers
{
    public class FabricController : Controller
    {
        private readonly FabricContext _context;

        public FabricController(FabricContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public List<Objects.Employee> Get()
        {
            var query = from emp in _context.Employees
                        join address in _context.Addresses
                        on emp.ID equals address.EmployeeID
                        select new Objects.Employee { 
                            ID = emp.ID, 
                            FirstName = emp.FirstName, 
                            LastName = emp.LastName, 
                            ContactNo = emp.ContactNo,
                            Email = emp.Email, 
                            Address = new Objects.Address
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

        public int Set(List<Objects.Employee> employees)
        {
            try
            {
                List<Employee> emps = new();
                int nrOfEmp = _context.Employees.Count();

                employees.ForEach(delegate (Objects.Employee emp)
                {
                    emps.Add(GetDBEmployee(emp));
                });

                _context.AddRange(emps);
                int numberOf =  _context.SaveChangesAsync().Result/2;

                return numberOf;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }


        public int Delete(Objects.Employee employee)
        {
            try
            {
                Employee emp = GetDBEmployee(employee);
                emp.ID = employee.ID;
                _context.Remove(emp);
                _context.SaveChangesAsync();
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public int Update(Objects.Employee employee)
        {
            try
            {
                Employee emp = _context.Employees.Where(el => el.ID == employee.ID).First();

                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.ContactNo = employee.ContactNo;
                emp.Email = employee.Email;

                Address adr = _context.Addresses.Where(el => el.EmployeeID == employee.ID).First();

                adr.Street = employee.Address.Street;
                adr.StreetNr = employee.Address.StreetNr;
                adr.HouseNr = employee.Address.HouseNr;
                adr.City = employee.Address.City;
                adr.Zip = employee.Address.Zip;

                emp.Address = adr;

                _context.Update(emp);
                _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        private static Employee GetDBEmployee(Objects.Employee emp)
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
