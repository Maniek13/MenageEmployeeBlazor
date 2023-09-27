﻿using FabricAPP.Controllers;
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
                    Zip = "76200"
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
                    Zip = "76200"
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

                for (int i = 0; i < employees.Count; ++i)
                {
                    _ = EmployeesController.DeleteFromDB(employees[i].ID);
                }
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
                _ = await EmployeesController.AddToDb(employees[0]);


                employees[0].FirstName = "nowe";
                await EmployeesController.UpdateInDb(employees[0]);

                var list = EmployeesController.GetFromDB();

                Assert.True(list.Select(el => el).Where(el => el.ID == employees[0].ID && el.FirstName == "nowe") != null);

                _ = EmployeesController.DeleteFromDB(employees[0].ID);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [Fact]
        public async void GetFromDb()
        {
            try
            {
                _ = await EmployeesController.AddToDb(employees[0]);
                _ = await EmployeesController.AddToDb(employees[1]);

                var list = EmployeesController.GetFromDB();

                Assert.True(list.Select(el => el).Where(el => el.ID == employees[0].ID || el.ID == employees[1].ID).ToList().Count == 2);

                _ = EmployeesController.DeleteFromDB(employees[0].ID);
                _ = EmployeesController.DeleteFromDB(employees[1].ID);
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
                string XMLString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                        <Employees>
                                            <Employee>
                                                <FirstName>Adrian</FirstName>
                                                <LastName>Nowak</LastName>
                                                <ContactNo>123456789</ContactNo>
                                                <Email>test@gmail.com</Email>
                                                <Address>
                                                    <City>Słupsk</City>
                                                    <Street>Wojska Polskiego</Street>
                                                    <StreetNr>2</StreetNr>
                                                    <HouseNr>3</HouseNr>
                                                    <Zip>75200</Zip>
                                                </Address>
                                            </Employee>
                                            <Employee>
                                                <FirstName>Kamil</FirstName>
                                                <LastName>Nowak</LastName>
                                                <ContactNo>123456789</ContactNo>
                                                <Email>test@gmail.com</Email>
                                                <Address>
                                                    <City>Słupsk</City>
                                                    <Street>Wojska Polskiego</Street>
                                                    <StreetNr>2</StreetNr>
                                                    <HouseNr>3</HouseNr>
                                                    <Zip>75200</Zip>
                                                </Address>
                                            </Employee>
                                        </Employees>";
                var  list = EmployeesController.GetFromXML(XMLString);



                Assert.True(list.Count == 2);
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
                string XMLString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                        <Employees>
                                            <Employee>
                                                <FirstName>Adrian</FirstName>
                                                <LastName>Nowak</LastName>
                                                <ContactNo>123456789</ContactNo>
                                                <Email>test@gmail.com</Email>
                                                <Address>
                                                    <City>Słupsk</City>
                                                    <Street>Wojska Polskiego</Street>
                                                    <StreetNr>2</StreetNr>
                                                    <HouseNr>3</HouseNr>
                                                    <Zip>75200</Zip>
                                                </Address>
                                            </Employee>
                                            <Employee>
                                                <FirstName>Kamil</FirstName>
                                                <LastName>Nowak</LastName>
                                                <ContactNo>123456789</ContactNo>
                                                <Email>test@gmail.com</Email>
                                                <Address>
                                                    <City>Słupsk</City>
                                                    <Street>Wojska Polskiego</Street>
                                                    <StreetNr>2</StreetNr>
                                                    <HouseNr>3</HouseNr>
                                                    <Zip>75200</Zip>
                                                </Address>
                                            </Employee>
                                        </Employees>";
                var list = EmployeesController.GetFromXML(XMLString);
                EmployeesController.SaveFromXML();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public async void Delete()
        {
            try
            {
                _ = await EmployeesController.AddToDb(employees[0]);

                int status = EmployeesController.DeleteFromDB(employees[0].ID);

                Assert.True(status == 1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

       


    }
}
