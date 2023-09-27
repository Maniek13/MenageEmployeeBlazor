﻿using FabricAPP.Data;
using FabricAPP.DBControllers;
using FabricAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FabricAppTests
{
    public class DbControllerTests : TestContext
	{
        readonly FabricController fb = new(new FabricContext());
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
                var nrof = fb.Get().Count;
                List<Employee> list = new()
                {
                    new Employee
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
                    },
                    new Employee
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
                    }
                };

				_ = await fb.Set(list);

                Assert.True(nrof+2 == fb.Get().Count);
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
