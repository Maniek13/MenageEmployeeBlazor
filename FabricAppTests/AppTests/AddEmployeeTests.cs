using FabricAPP.Data;
using FabricAPP.Interfaces;
using FabricAPP.Pages;
using FabricAPP.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace FabricAppTests.AppTests
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
    /// </summary>
    public class AddEmployeeTests : TestContext
    {
        [Fact]
        public void AddEmployeClick()
        {
			Services.AddSingleton<IAddEmployeeViewModel>(new AddEmployeeViewModel());

            var cut = RenderComponent<AddEmployee>();
            cut.Find("form").Submit();
            Assert.Equal("First name is required", cut.Find("div[class=validation-message]").TextContent);

            cut.Find("input[id=FirstName]").Change("AddEmployeClick");
			cut.Find("form").Submit();
			Assert.Equal("Last name is required", cut.Find("div[class=validation-message]").TextContent);

            cut.Find("input[id=LastName]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Contact number is required", cut.Find("div[class=validation-message]").TextContent);


            #region number tests
            cut.Find("input[id=GetPhoneNr]").Change("12345678");
            cut.Find("form").Submit();
            Assert.Equal("Contact number must have between 9 and 15 character in length.", cut.Find("div[class=validation-message]").TextContent);

            cut.Find("input[id=GetPhoneNr]").Change("1234567890123456");
            cut.Find("form").Submit();
            Assert.Equal("Contact number must have between 9 and 15 character in length.", cut.Find("div[class=validation-message]").TextContent);

            cut.Find("input[id=GetPhoneNr]").Change("123456789");
            cut.Find("form").Submit();
            Assert.Equal("Email is required", cut.Find("div[class=validation-message]").TextContent);
            #endregion


            cut.Find("input[id=Email]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("City is required", cut.Find("div[class=validation-message]").TextContent);

            cut.Find("input[id=City]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Street is required", cut.Find("div[class=validation-message]").TextContent);

            cut.Find("input[id=Street]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Street nr is required", cut.Find("div[class=validation-message]").TextContent);

            #region zipcode tests
            cut.Find("input[id=StreetNr]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Zip code name is required", cut.Find("div[class=validation-message]").TextContent);

           
            cut.Find("input[id=GetZipCode]").Change("1234");
            cut.Find("form").Submit();
            Assert.Equal("Contact number must have 5 character.", cut.Find("div[class=validation-message]").TextContent);

            cut.Find("input[id=GetZipCode]").Change("123456");
            cut.Find("form").Submit();
            Assert.Equal("Contact number must have 5 character.", cut.Find("div[class=validation-message]").TextContent);
            #endregion


            cut.Find("input[id=GetZipCode]").Change("12345");
            cut.Find("form").Submit();

            Thread.Sleep(1000);

            Assert.Equal("Employee: AddEmployeClick test added succesfully", cut.Find("div[id=succes]").TextContent);

            FabricContext fabricContext = new();
            var x = fabricContext.Employees.Select(el => el).Where(el => el.FirstName == "AddEmployeClick").FirstOrDefault();
            fabricContext.Remove(x);
        }


        //Old 
        //[Fact]
        //public void AddEmployeClick()
        //{
        //    Services.AddSingleton<IAddEmployeeViewModel>(new AddEmployeeViewModel());

        //    var cut = RenderComponent<AddEmployee>();

        //    cut.Find("form").Submit();
        //    Assert.Equal("Please write a name", cut.Find("div[class=]").TextContent);

        //    cut.Find("input[id=FirstName]").Change("AddEmployeClick");
        //    cut.Find("form").Submit();
        //    Assert.Equal("Please write a last name", cut.Find("div[id=error]").TextContent);

        //    cut.Find("input[id=LastName]").Change("test");
        //    cut.Find("form").Submit();
        //    Assert.Equal("Plese write a number", cut.Find("div[id=error]").TextContent);

        //    cut.Find("input[id=GetPhoneNr]").Change("123456789");
        //    cut.Find("form").Submit();
        //    Assert.Equal("Please write an email", cut.Find("div[id=error]").TextContent);

        //    cut.Find("input[id=Email]").Change("test");
        //    cut.Find("form").Submit();
        //    Assert.Equal("Please write a city name", cut.Find("div[id=error]").TextContent);

        //    cut.Find("input[id=City]").Change("test");
        //    cut.Find("form").Submit();
        //    Assert.Equal("Please write a street", cut.Find("div[id=error]").TextContent);

        //    cut.Find("input[id=Street]").Change("test");
        //    cut.Find("form").Submit();
        //    Assert.Equal("Please write a street nr", cut.Find("div[id=error]").TextContent);

        //    cut.Find("input[id=StreetNr]").Change("test");
        //    cut.Find("form").Submit();
        //    Assert.Equal("Plese write a zip code", cut.Find("div[id=error]").TextContent);

        //    cut.Find("input[id=GetZipCode]").Change("12345");
        //    cut.Find("form").Submit();

        //    Thread.Sleep(1000);

        //    Assert.Equal("Employee: AddEmployeClick test added succesfully", cut.Find("div[id=succes]").TextContent);

        //    FabricContext fabricContext = new();
        //    var x = fabricContext.Employees.Select(el => el).Where(el => el.FirstName == "AddEmployeClick").FirstOrDefault();
        //    fabricContext.Remove(x);
        //}
    }
}