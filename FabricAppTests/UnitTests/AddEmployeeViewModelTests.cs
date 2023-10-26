using FabricAPP.Data;
using FabricAPP.Exceptions;
using FabricAPP.Interfaces;
using FabricAPP.Models;
using FabricAPP.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace FabricAppTests.UnitTests
{
    public class AddEmployeeViewModelTests : TestContext
    {
        IAddEmployeeViewModel AddEmployeeViewModel { get; set; }
        readonly FabricContext context;

        public AddEmployeeViewModelTests()
        {
            try
            {
                var options = new DbContextOptionsBuilder<FabricContext>()
                    .UseInMemoryDatabase(databaseName: "FabricDB")
                    .Options;


                context = new FabricContext(options);
                AddEmployeeViewModel = new AddEmployeeViewModel(context);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void AddUserTest()
        {
            try
            {
                AddEmployeeViewModel.Employee = new()
                {
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

                Assert.ThrowsAsync<Exception>(async () =>
                {
                    await AddEmployeeViewModel.AsyncAddUser();
                });

                AddEmployeeViewModel.Employee = new();
                

                Assert.ThrowsAsync<Exception>(async () =>
                {
                    await AddEmployeeViewModel.AsyncAddUser();
                });

            }
            catch(Exception ex) { Assert.Fail(ex.Message);}
        }

    }
}
