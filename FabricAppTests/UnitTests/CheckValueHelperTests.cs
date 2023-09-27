using FabricAPP.Exceptions;
using FabricAPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricAppTests.UnitTests
{
    public class CheckValueHelperTests : TestContext
    {
        [Fact]
        public void CheckIsPhoneNr()
        {
            try
            {
                string test = "";
                Assert.Throws<IncorectValueOfUserException>(() =>
                {
                    CheckValueHelper.CheckIsPhoneNr(test);
                });
                

                test = "1234";
                Assert.Throws<IncorectValueOfUserException>(() =>
                {
                    CheckValueHelper.CheckIsPhoneNr(test);
                });


                test = "123a56789";
                Assert.Throws<IncorectValueOfUserException>(() =>
                {
                    CheckValueHelper.CheckIsPhoneNr(test);
                });


                test = "123456789";
                CheckValueHelper.CheckIsPhoneNr(test);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void CheckIsAllNumbers()
        {
            try
            {
                string test = "";
                Assert.Throws<IncorectValueOfUserException>(() =>
                {
                    CheckValueHelper.CheckIsZipNumbers(test);
                });


                test = "1234";
                Assert.Throws<IncorectValueOfUserException>(() =>
                {
                    CheckValueHelper.CheckIsZipNumbers(test);
                });


                test = "12a4";
                Assert.Throws<IncorectValueOfUserException>(() =>
                {
                    CheckValueHelper.CheckIsZipNumbers(test);
                });

                test = "123456";
                Assert.Throws<IncorectValueOfUserException>(() =>
                {
                    CheckValueHelper.CheckIsZipNumbers(test);
                });

                test = "12345";
                CheckValueHelper.CheckIsZipNumbers(test);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
