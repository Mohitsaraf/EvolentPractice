using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolentPracticeApi;
using EvolentPracticeApi.Controllers;
using EvolentPracticeApi.Models;

namespace EvolentPracticeApi.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void GetAllContactsTest()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            var result = controller.GetAllContacts();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsInstanceOfType(result,typeof(List<Contact>));
        }

        [TestMethod]
        public void GetAllContactsTest_Active()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            var result = controller.GetAllActiveContacts();
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.IsInstanceOfType(result, typeof(List<Contact>));
        }

        [TestMethod]
        public void GetAllContactsTest_Inactive()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            var result = controller.GetAllInactiveContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.IsInstanceOfType(result, typeof(List<Contact>));
        }
        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            var result = controller.GetContactInfo("Sarafmohit1@gmail.com");

           // Assert
            Assert.IsInstanceOfType(result,typeof(Contact));
        }

        [TestMethod]
        public void PostContact()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            Contact mock = new Contact()
            {
                FirstName = "Demo",
                LastName = "dsds",
                EmailId = "killbill@gmail.com",
                Mobile = "8784567878",
                Status = "Active"
            };
            // Act
            var result =controller.PostContactInfo(mock);
            

            // Assert     
            Assert.AreEqual(true, result);


        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            Contact mock = new Contact()
            {
                FirstName = "Mohit",
                LastName = "Edge",
                EmailId = "Demo@gmail.com",
                Mobile = "9784567878",
                Status = "Active"
            };
            // Act
            var result=  controller.Put("Sarafmohit1@gmail.com",mock );

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete("argin@gmail.com");

            // Assert
        }
    }
}
