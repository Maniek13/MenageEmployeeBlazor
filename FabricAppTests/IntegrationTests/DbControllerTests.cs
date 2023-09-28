using FabricAPP.Data;
using FabricAPP.DBControllers;
using FabricAPP.Interfaces;
using FabricAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FabricAppTests.IntegrationTests
{
    public class DbControllerTests : TestContext
    {
        readonly IFabricDbController fb = new FabricDbController(new FabricContext());
        [Fact]
        public async void AddEmployeeTests()
        {
            try
            {
                Employee emp = new()
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
                        Zip = "12345"
                    }
                };

                int id = await fb.Add(emp);


                Assert.True(emp.ID > 0 && id > 0 && emp.ID == id);
                fb.Delete(emp.ID);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async void Get()
        {
            try
            {
                Employee emp = new()
                {
                    FirstName = "testget",
                    LastName = "test",
                    ContactNo = "123456789",
                    Email = "test",
                    Address = new()
                    {
                        City = "test",
                        Street = "test",
                        StreetNr = "test",
                        HouseNr = "test",
                        Zip = "12345"
                    }
                };

                int id = await fb.Add(emp);

                var list = fb.Get();

                Assert.True(list.Count > 0 && list.Select(el => el).Where(el => el.FirstName == "testget").ToList().Count != 0);

                fb.Delete(emp.ID);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public async void DeleteEmployee()
        {
            try
            {
                Employee emp = new()
                {
                    FirstName = "testget",
                    LastName = "test",
                    ContactNo = "123456789",
                    Email = "test",
                    Address = new()
                    {
                        City = "test",
                        Street = "test",
                        StreetNr = "test",
                        HouseNr = "test",
                        Zip = "12345"
                    }
                };

                _ = await fb.Add(emp);
                fb.Delete(emp.ID);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [Fact]
        public async void SetEmployees()
        {
            try
            {
                List<Employee> list = new()
                {
                    new Employee
                    {
                        FirstName = "SetEmployeesTest1",
                        LastName = "test",
                        ContactNo = "123456789",
                        Email = "test",
                        Address = new()
                        {
                            City = "test",
                            Street = "test",
                            StreetNr = "test",
                            HouseNr = "test",
                            Zip = "12345"
                        }
                    },
                    new Employee
                    {
                        FirstName = "SetEmployeesTest2",
                        LastName = "test",
                        ContactNo = "123456789",
                        Email = "test",
                        Address = new()
                        {
                            City = "test",
                            Street = "test",
                            StreetNr = "test",
                            HouseNr = "test",
                            Zip = "12345"
                        }
                    }
                };

                _ = await fb.Set(list);
                List<Employee> res = fb.Get();
                Assert.True(res.Select(el => el).Where(el => el.FirstName == "SetEmployeesTest1" || el.FirstName == "SetEmployeesTest2").ToList().Count == 2);


                FabricContext ctx = new();
                var e1 = ctx.Employees.Select(el => el).Where(el => el.FirstName == "SetEmployeesTest1").FirstOrDefault();
                var e2 = ctx.Employees.Select(el => el).Where(el => el.FirstName == "SetEmployeesTest2").FirstOrDefault();
#pragma warning disable CS8602
                fb.Delete(e1.ID);
                fb.Delete(e2.ID);
#pragma warning restore CS8602
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [Fact]
        public async void UpdateEmployee()
        {
            try
            {
                Employee emp = new()
                {
                    FirstName = "testget",
                    LastName = "test",
                    ContactNo = "123456789",
                    Email = "test",
                    Address = new()
                    {
                        City = "test",
                        Street = "test",
                        StreetNr = "test",
                        HouseNr = "test",
                        Zip = "12345"
                    }
                };

                _ = await fb.Add(emp);

                emp.FirstName = "updated";
                await fb.Update(emp);
                fb.Delete(emp.ID);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
