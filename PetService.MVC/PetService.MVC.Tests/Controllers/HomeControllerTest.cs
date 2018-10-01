using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetService.MVC;
using PetService.MVC.Controllers;
using System;
using PetService.MVC.Models;

namespace PetService.MVC.Tests.Controllers
{
    /// <summary>
    /// Test the controller for Home.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Test the method for GET Home/Index.
        /// </summary>
        [TestMethod]
        public void Home_Index_NoParam_ReturnsTitle()
        {
            // Arrange 
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Make a claim", result.ViewBag.Title);
        }
    }
}
