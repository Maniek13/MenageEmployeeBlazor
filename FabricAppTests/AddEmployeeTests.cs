using FabricAPP.Interfaces;
using FabricAPP.Pages;
using FabricAPP.ViewModels;
using Microsoft.AspNetCore.Components.Forms;

namespace FabricAppTests
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
			cut.Find("input[id=FirstName]").Change("test");
			cut.Find("form").Submit();
			Assert.Equal("Please write a last name", cut.Find("div[id=error]").TextContent);
		}
    }
}