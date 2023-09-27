using FabricAPP.Interfaces;
using FabricAPP.Pages;
using FabricAPP.ViewModels;

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
            Assert.Equal("Please write a name", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=FirstName]").Change("test");
			cut.Find("form").Submit();
			Assert.Equal("Please write a last name", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=LastName]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Please write a number in correct format", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=GetPhoneNr]").Change("123456789");
            cut.Find("form").Submit();
            Assert.Equal("Please write an email", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=Email]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Please write a city name", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=City]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Please write a street", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=Street]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Please write a street nr", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=StreetNr]").Change("test");
            cut.Find("form").Submit();
            Assert.Equal("Please write a zipcode in format: 00000", cut.Find("div[id=error]").TextContent);

            cut.Find("input[id=GetZipCode]").Change("12345");
            cut.Find("form").Submit();
        }
    }
}