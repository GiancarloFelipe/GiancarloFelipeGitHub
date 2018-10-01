using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetService.MVC;
using PetService.MVC.Controllers;
using PetService.MVC.Models;

namespace PetService.MVC.Tests.Controllers
{
    /// <summary>
    /// Test the controller for PetSure.
    /// </summary>
    [TestClass]
    public class PetSureControllerTest
    {
        /// <summary>
        /// Test the method for GET api/PetSure.
        /// </summary>
        [TestMethod]
        public void PetSure_Get_NoParam_ReturnsIEnumerablePetList()
        {
            // Arrange
            PetSureController controller = new PetSureController();
            List<PetList> comparisonPetList = new List<PetList>();
            comparisonPetList.Clear();
            comparisonPetList.Add(new PetList { PetId = 1, PetName = "Rover" });
            comparisonPetList.Add(new PetList { PetId = 2, PetName = "Fido" });
            comparisonPetList.Add(new PetList { PetId = 3, PetName = "Pixie" });

            // Act
            IEnumerable<PetService.MVC.Models.PetList> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(comparisonPetList.Where(x => x.PetName == "Rover").Select(x => x.PetName).ToString(), result.Where(x => x.PetName == "Rover").Select(x => x.PetName).ToString());
            Assert.AreEqual(comparisonPetList.Where(x => x.PetName == "Fido").Select(x => x.PetName).ToString(), result.Where(x => x.PetName == "Fido").Select(x => x.PetName).ToString());
            Assert.AreEqual(comparisonPetList.Where(x => x.PetName == "Pixie").Select(x => x.PetName).ToString(), result.Where(x => x.PetName == "Pixie").Select(x => x.PetName).ToString());
        }

        /// <summary>
        /// Test the method for GET api/PetSure/{id}.
        /// </summary>
        [TestMethod]
        public void PetSure_GetById_ParamId_ReturnsPetList()
        {
            // Arrange
            PetSureController controller = new PetSureController();
            List<PetList> comparisonPetList = new List<PetList>();
            comparisonPetList.Clear();
            comparisonPetList.Add(new PetList { PetId = 1, PetName = "Rover" });
            comparisonPetList.Add(new PetList { PetId = 2, PetName = "Fido" });
            comparisonPetList.Add(new PetList { PetId = 3, PetName = "Pixie" });

            foreach (var comparisonList in comparisonPetList)
            {
                // Act    
                List<PetList> result = controller.Get(comparisonList.PetId);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Count());
                Assert.AreEqual(comparisonPetList.Where(x => x.PetId == comparisonList.PetId).Select(x => x.PetName).ToString(), result.Where(x => x.PetId == comparisonList.PetId).Select(x => x.PetName).ToString());
            }
        }

        /// <summary>
        /// Test the method for POST api/PetSure/{value}.
        /// </summary>
        [TestMethod]
        public void PetSure_Post_ParamPetName_ReturnsBooleanIndicationIfPostSucceed()
        {
            // Arrange
            PetSureController controller = new PetSureController();
            List<PetList> comparisonPetList = new List<PetList>();
            comparisonPetList.Clear();
            comparisonPetList.Add(new PetList { PetId = 1, PetName = "Rover" });
            comparisonPetList.Add(new PetList { PetId = 2, PetName = "Fido" });
            comparisonPetList.Add(new PetList { PetId = 3, PetName = "Pixie" });

            foreach (var comparisonList in comparisonPetList)
            {
                // Act
                bool result = controller.Post(comparisonList.PetName);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
        }

        /// <summary>
        /// Test the method for PUT api/PetSure/{id,value}.
        /// </summary>
        [TestMethod]
        public void PetSure_Put_ParamPetIdPetName_ReturnsBooleanIndicationIfPutSucceed()
        {
            // Arrange
            PetSureController controller = new PetSureController();
            List<PetList> comparisonPetList = new List<PetList>();
            comparisonPetList.Clear();
            comparisonPetList.Add(new PetList { PetId = 1, PetName = "Rover1" });
            comparisonPetList.Add(new PetList { PetId = 2, PetName = "Fido2" });
            comparisonPetList.Add(new PetList { PetId = 3, PetName = "Pixie3" });

            foreach (var comparisonList in comparisonPetList)
            {
                // Act
                bool result = controller.Put(comparisonList.PetId, comparisonList.PetName);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
        }

        /// <summary>
        /// Test the method for DELETE api/PetSure/{id}.
        /// </summary>
        [TestMethod]
        public void PetSure_Delete_ParamPetIdPetName_ReturnsBooleanIndicationIfDeleteSucceed()
        {
            // Arrange
            PetSureController controller = new PetSureController();
            List<PetList> comparisonPetList = new List<PetList>();
            comparisonPetList.Clear();
            comparisonPetList.Add(new PetList { PetId = 1, PetName = "Rover" });
            comparisonPetList.Add(new PetList { PetId = 2, PetName = "Fido" });
            comparisonPetList.Add(new PetList { PetId = 3, PetName = "Pixie" });

            foreach (var comparisonList in comparisonPetList)
            {
                // Act
                bool result = controller.Delete(comparisonList.PetId);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
        }
    }
}
