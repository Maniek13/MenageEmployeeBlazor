using FabricAPP.Data;
using FabricAPP.Exceptions;
using FabricAPP.Interfaces;
using FabricAPP.Models;
using FabricAPP.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace FabricAppTests.UnitTests
{
    public class ShowEmployeesViewModelTests : TestContext
    {
        IShowEmployeesViewModel ShowEmployeesViewModel { get; set; }
        readonly FabricContext context;

        public ShowEmployeesViewModelTests()
        {
            try
            {
                var options = new DbContextOptionsBuilder<FabricContext>()
                    .UseInMemoryDatabase(databaseName: "FabricDB")
                    .Options;


                context = new FabricContext(options);
                SetInDb();
                ShowEmployeesViewModel = new ShowEmployeesViewModel(context);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void DeleteTest()
        {
            try
            {
                Employee emp = new();


                Assert.Throws<Exception>(() =>
                {
                    ShowEmployeesViewModel.Delete(emp);
                });

                emp = new()
                {
                    ID = 1,
                    FirstName = "DeleteEmployeesViewModelSaveChange",
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
                    },
                };

                ShowEmployeesViewModel.Delete(emp);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void SaveChange()
        {
            try
            {
                Employee emp = new()
                {
                    ID = 1,
                    FirstName = "",
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


                Assert.ThrowsAsync<IncorectValueOfUserException>(async () =>
                {
                    _ = await ShowEmployeesViewModel.Save(emp);
                });


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private void SetInDb()
        {
            FabricAPP.DBModels.Employee deleteEmp = new()
            {
                FirstName = "ShowEmployeesViewModelDeleteTest",
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

            context.Add(deleteEmp);

            FabricAPP.DBModels.Employee saveEmp = new()
            {
                FirstName = "DeleteEmployeesViewModelSaveChange",
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
            context.Add(saveEmp);

            context.SaveChanges();
        }
    }
}
