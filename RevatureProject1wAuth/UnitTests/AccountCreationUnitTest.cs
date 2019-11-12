using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClasses.Models.Repositories;
using RevatureProject1wAuth.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Repositories;

namespace UnitTests
{
    public class AccountCreationUnitTest
    {
        [TestMethod]

        public void TestAccountCreation_CreatesAccount()

        {

            // Arrange.

            IAccountRepo repo = new AccountTestRepository();

            AccountController controller = new AccountController(repo);


            //var expected = "John";


            //// Act.

            //var result = controller.Details(102);

            //var fname = ((Customer)(result.Result as ViewResult).Model).Firstname;



            //// Assert.

            //Assert.AreEqual(expected, fname);

        }
    }
}
