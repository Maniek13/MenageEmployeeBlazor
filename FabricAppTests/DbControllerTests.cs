﻿using FabricAPP.Data;
using FabricAPP.DBControllers;
using FabricAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricAppTests
{
	public class DbControllerTests : TestContext
	{
		FabricController fb = new(new FabricContext());
		[Fact]
		public async void AddEmployeeTests()
		{
			try
			{
				Employee emp = new()
				{
					FirstName = "test",
					LastName = "test",
					ContactNo = 123456789,
					Email = "test",
					Address = new()
					{
						City = "test",
						Street = "test",
						StreetNr = "test",
						HouseNr = "test",
						Zip = 12345
					}
				};

				int id = await fb.Add(emp);
				

				Assert.True(emp.ID > 0 && id > 0 && emp.ID == id);

				fb.Dispose();
				fb = new(new FabricContext());
				fb.Delete(emp);

				fb.Dispose();
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
					ContactNo = 123456789,
					Email = "test",
					Address = new()
					{
						City = "test",
						Street = "test",
						StreetNr = "test",
						HouseNr = "test",
						Zip = 12345
					}
				};

				int id = await fb.Add(emp);

				var list = fb.Get();

				Assert.True(list.Count > 0 && list.Select(el => el).Where(el => el.FirstName == "testget").ToList().Count != 0);

                fb.Dispose();
                fb = new(new FabricContext());
                fb.Delete(emp);

                fb.Dispose();

            }
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
