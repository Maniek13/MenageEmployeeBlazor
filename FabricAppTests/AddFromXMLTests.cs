using Bunit;
using FabricAPP.Interfaces;
using FabricAPP.Pages;
using FabricAPP.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.IO;

namespace FabricAppTests
{
	/// <summary>
	/// These tests are written entirely in C#.
	/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
	/// </summary>
	public class AddFromXMLTests : TestContext
    {
        [Fact]
        public void AddFromXML()
        {
			Services.AddSingleton<IAddEmployeesFromXMLViewModel>(new AddEmployeesFromXMLViewModel());
			var cut = RenderComponent<AddEmployeesFromXML>();

            var path = Path.Combine(Environment.CurrentDirectory, "XML", "test.xml");
            var file = File.ReadAllBytes(path);

            IRenderedComponent<InputFile> inputFile = cut.FindComponent<InputFile>();
            inputFile.UploadFiles(InputFileContent.CreateFromBinary(file));

            cut.Find("button[id=Save]").Click();

            Assert.Equal("Element was saved. Added 2", cut.Find("div[id=SavedFilesStatus]").TextContent);
        }
    }
}