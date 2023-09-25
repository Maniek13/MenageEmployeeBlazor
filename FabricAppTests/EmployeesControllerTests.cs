using FabricAPP.Controllers;
using FabricAPP.Interfaces;
using FabricAPP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FabricAppTests
{
    public class EmployeesControllerTests : TestContext
    {
        IEmployeesController EmployeesController { get; set; }

        static readonly List<Employee> employees = new()
        {
            new Employee()
            {
                FirstName = "test",
                LastName = "test",
                ContactNo = "123456789",
                Email = "test",
                Address = new()
                {
                    City = "test",
                    Street = "test",
                    StreetNr = "test",
                    HouseNr = "test",
                    Zip = 76200
                }
            },
            new Employee()
            {
                FirstName = "test1",
                LastName = "test1",
                ContactNo = "123456789",
                Email = "test1",
                Address = new()
                {
                    City = "test1",
                    Street = "test1",
                    StreetNr = "test1",
                    HouseNr = "test1",
                    Zip = 76200
                }
            }
        };

        public EmployeesControllerTests() 
        {
            EmployeesController = new EmployeesController();
        }

        [Fact]
        public async void AddToDb()
        {
            try
            {

                for(int i = 0; i < employees.Count; ++i)
                {
                    _ = await EmployeesController.AddToDb(employees[i]);

                }

                var list = EmployeesController.GetFromDB();

                Assert.True(list.Select(el => el).Where(el => el.ID == employees[0].ID || el.ID == employees[1].ID).ToList().Count == 2);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public async void UpdateInDb()
        {
            try
            {
                employees[0].FirstName = "nowe";
                await EmployeesController.UpdateInDb(employees[0]);

                var list = EmployeesController.GetFromDB();

                Assert.True(list.Select(el => el).Where(el => el.ID == employees[0].ID && el.FirstName == "nowe") != null);


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [Fact]
        public void GetFromDb()
        {
            try
            {
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void GetFromXML()
        {
            try
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public void SaveFromXML()
        {
            try
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public void Delete()
        {
            try
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

       


    }
}
