using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetService.MVC.Models;
using System.Text;

namespace PetService.MVC.Controllers
{
    /// <summary>
    /// The controller that provides methods that respond to HTTP requests for PetSure Home Web Site. 
    /// </summary>
    public class HomeController : Controller
    {
        private const string MAKE_A_CLAIM = "Make a claim";
        private const string PETSURE_APPLICATION_SYSTEM = "PetSure Application System";
        /// <summary>
        /// Private list for PetClaimService model.
        /// </summary>
        private List<PetClaimServiceViewModels> PetClaimServiceList = new List<PetClaimServiceViewModels>();

        //
        // GET: /Home/Index
        /// <summary>
        /// The action method that provides result for /Home/Index request.
        /// </summary>
        /// <returns>Return action result for /Home/Index request.</returns>
        public ActionResult Index()
        {
            this.ViewBag.Title = MAKE_A_CLAIM;
            this.ViewBag.ApplicationTitle = PETSURE_APPLICATION_SYSTEM; 
            return View();
        }

        //
        // POST: /Home/SelectedPet
        /// <summary>
        /// The action method that provides result for /Home/SelectedPet request.
        /// </summary>
        /// <param name="model">The PetService.MVC.Models.PetServiceViewModels model.</param>
        /// <returns>Return a boolean value of "true" for /Home/SelectedPet request... if ApplicationSession.GlobalParameters.SelectedPetNameId is not equals to 0, else returns "false".</returns>
        [HttpPost]
        public bool SelectedPet(PetClaimServiceViewModels model)
        {
            // Gets the selected pet value...
            ApplicationSession.GlobalParameters.SelectedPetNameId = model.Id;
            ApplicationSession.GlobalParameters.SelectedPetName = model.PetName;

            // Returns true if the selected pet value if not equals to 0, else returns false...
            return ApplicationSession.GlobalParameters.SelectedPetNameId != 0 ? true : false;
        }

        //
        // POST: /Home/SubmitClaim
        /// <summary>
        /// The action method that provides result for /Home/SubmitClaim request.
        /// </summary>
        /// <param name="model">The PetService.MVC.Models.PetServiceViewModels model.</param>
        /// <returns>Return string action message for /Home/SubmitClaim request.</returns>
        [HttpPost]
        public string SubmitClaim(PetClaimServiceViewModels model)
        {
            // Gets the selected filename...
            model.FileName = ApplicationSession.GlobalParameters.SelectedPetFileName;
            StringBuilder submitedfiles = new StringBuilder();
            submitedfiles.Clear();

            // Checks if file has been uploaded already, by checking the ApplicationSession.GlobalParameters.SelectedPetFileName value...
            if (!string.IsNullOrEmpty(model.FileName))
            {
                // Starts connecting to the database...
                using (PetSureDatabaseEntities dbo = new PetSureDatabaseEntities())
                {
                    // Start the database transaction to ensure that the Entity Framework executes commands on the database within the context of that transaction...
                    using (System.Data.Entity.DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            // Checks if the selected pet name is a valid petname...
                            int petId = dbo.PetLists.Where(x => x.PetName == model.PetName).FirstOrDefault().PetId;
                            int existCount = dbo.PetClaimServices.Where(x => x.PetId == petId).Count();
                            if (existCount > 0)
                            {
                                // Remove first all the existing records of the selected pet in PetClaimService table...
                                dbo.PetClaimServices.RemoveRange(dbo.PetClaimServices.Where(x => x.PetId == petId));
                                // Saves all the changes made on the PetClaimService table...
                                dbo.SaveChanges();

                                // Re-submit all the submitted new invoice file for the selected pet for pet claim...
                                foreach (var item in ApplicationSession.GlobalParameters.PetClaimServiceList)
                                {
                                    PetService.MVC.Models.PetClaimService petModel = new PetService.MVC.Models.PetClaimService();
                                    petModel.PetId = petId;
                                    submitedfiles.Append(string.IsNullOrEmpty(submitedfiles.ToString())? petModel.FileName = item.FileName: String.Concat(", ",petModel.FileName = item.FileName));
                                    petModel.FilePath = item.FilePath;
                                    petModel.PetClaimedDate = DateTime.Now;
                                    dbo.PetClaimServices.Add(petModel);
                                    dbo.SaveChanges();
                                }

                                // Commits the underlying store transaction...
                                transaction.Commit();
                                return String.Format("Thank you for re-submitting ''{0}'' for {1}", submitedfiles.ToString(), model.PetName);
                            }
                            else
                            {
                                // Submit all the submitted new invoice file for the selected pet for pet claim...
                                foreach (var item in ApplicationSession.GlobalParameters.PetClaimServiceList)
                                {
                                    PetService.MVC.Models.PetClaimService petModel = new PetService.MVC.Models.PetClaimService();
                                    petModel.PetId = petId;
                                    submitedfiles.Append(string.IsNullOrEmpty(submitedfiles.ToString()) ? petModel.FileName = item.FileName : String.Concat(", ", petModel.FileName = item.FileName));
                                    petModel.FilePath = item.FilePath;
                                    petModel.PetClaimedDate = DateTime.Now;
                                    dbo.PetClaimServices.Add(petModel);
                                    dbo.SaveChanges();
                                }

                                // Commits the underlying store transaction...
                                transaction.Commit();
                                return String.Format("Thank you for submitting ''{0}'' for {1}", submitedfiles.ToString(), model.PetName);
                            }
                        }
                        catch (Exception)
                        {
                            // ROLLBACK TRANSACTION FOR ANY UNHANDLED EXCEPTION...
                            transaction.Rollback();
                        }
                        // CLEANS UP TRANSACTION OBJECT AND ENSURES THE ENTITY FRAMEWORK IS NO LONGER USING THAT TRANSACTION...
                        transaction.Dispose();
                    }
                }
            }
            return "No Invoice Uploaded Yet!";
        }

        // POST: /Home/SaveForLater
        /// <summary>
        /// The action method that provides result for /Home/SaveForLater request.
        /// </summary>
        /// <param name="model">The PetService.MVC.Models.PetServiceViewModels model.</param>
        /// <returns>Return string action message for /Home/SaveForLater request.</returns>
        [HttpPost]
        public string SaveForLater(PetClaimServiceViewModels model)
        {
            // Gets the selected filename...
            model.FileName = ApplicationSession.GlobalParameters.SelectedPetFileName;
            StringBuilder submitedfiles = new StringBuilder();
            submitedfiles.Clear();

            // Checks if file has been uploaded already, by checking the ApplicationSession.GlobalParameters.SelectedPetFileName value...
            if (!string.IsNullOrEmpty(model.FileName))
            {

                // Starts connecting to the database...
                using (PetSureDatabaseEntities dbo = new PetSureDatabaseEntities())
                {
                    // Start the database transaction to ensure that the Entity Framework executes commands on the database within the context of that transaction...
                    using (System.Data.Entity.DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            // Checks if the selected pet name is a valid petname...
                            int petId = dbo.PetLists.Where(x => x.PetName == model.PetName).FirstOrDefault().PetId;
                            int existCount = dbo.PetClaimServiceTemps.Where(x => x.PetId == petId).Count();
                            if (existCount > 0)
                            {
                                // Remove first all the existing records of the selected pet in PetClaimServiceTemps table...
                                dbo.PetClaimServiceTemps.RemoveRange(dbo.PetClaimServiceTemps.Where(x => x.PetId == petId));
                                // Saves all the changes made on the PetClaimServiceTemps table...
                                dbo.SaveChanges();

                                // Re-submit all the submitted new invoice file for the selected pet to be save for later submission...
                                foreach (var item in ApplicationSession.GlobalParameters.PetClaimServiceList)
                                {
                                    PetService.MVC.Models.PetClaimServiceTemp petModel = new PetService.MVC.Models.PetClaimServiceTemp();
                                    petModel.PetId = petId;
                                    submitedfiles.Append(string.IsNullOrEmpty(submitedfiles.ToString()) ? petModel.FileName = item.FileName : String.Concat(", ", petModel.FileName = item.FileName));
                                    petModel.FilePath = item.FilePath;
                                    petModel.PetClaimedDate = DateTime.Now;
                                    dbo.PetClaimServiceTemps.Add(petModel);
                                    dbo.SaveChanges();
                                }

                                // Commits the underlying store transaction...
                                transaction.Commit();
                                return String.Format("Thank you for re-submitting ''{0}'' for {1}, the file(s) was now Saved for Later", submitedfiles.ToString(), model.PetName);
                            }
                            else
                            {
                                // Submit all the submitted new invoice file for the selected pet to be save for later submission...
                                foreach (var item in ApplicationSession.GlobalParameters.PetClaimServiceList)
                                {
                                    PetService.MVC.Models.PetClaimServiceTemp petModel = new PetService.MVC.Models.PetClaimServiceTemp();
                                    petModel.PetId = petId;
                                    submitedfiles.Append(string.IsNullOrEmpty(submitedfiles.ToString()) ? petModel.FileName = item.FileName : String.Concat(", ", petModel.FileName = item.FileName));
                                    petModel.FilePath = item.FilePath;
                                    petModel.PetClaimedDate = DateTime.Now;
                                    dbo.PetClaimServiceTemps.Add(petModel);
                                    dbo.SaveChanges();
                                }

                                // Commits the underlying store transaction...
                                transaction.Commit();
                                return String.Format("Thank you for submitting ''{0}'' for {1}, the file(s) was now Saved for Later", submitedfiles.ToString(), model.PetName);
                            }
                        }
                        catch (Exception)
                        {
                            // ROLLBACK TRANSACTION FOR ANY UNHANDLED EXCEPTION...
                            transaction.Rollback();
                        }
                        // CLEANS UP TRANSACTION OBJECT AND ENSURES THE ENTITY FRAMEWORK IS NO LONGER USING THAT TRANSACTION...
                        transaction.Dispose();
                    }
                }
            }
            return "No Invoice Uploaded Yet!";
        }

        // POST: /Home/UploadedFile
        /// <summary>
        /// The action method that provides result for /Home/UploadedFile request.
        /// </summary>
        /// <returns>Return Json Result for /Home/SaveForLater request.</returns>
        [HttpPost]
        public JsonResult UploadedFile()
        {
            // Set the methods local variables...
            bool isFileUploadedSuccessfully = true;
            string petFileNameGUID = string.Empty;

            // UPLOADING ALL THE INVOICE FILE(S)...
            try
            {
                // Checks each file request...
                foreach (string fileName in Request.Files)
                {
                    // Gets the uploaded file(s)...
                    HttpPostedFileBase requestFiles = Request.Files[fileName];
                    petFileNameGUID = Guid.NewGuid().ToString();
                    if (requestFiles != null && requestFiles.ContentLength > 0)
                    {

                        // Gets the base directory information using the Server.MapPath...
                        var baseDirectoryInfo = new System.IO.DirectoryInfo(string.Format("{0}Images\\uploaded", Server.MapPath(@"\")));
                        string pathString = System.IO.Path.Combine(baseDirectoryInfo.ToString(), "imagepath", ApplicationSession.GlobalParameters.SelectedPetName);
                        var petFileName = System.IO.Path.GetFileName(requestFiles.FileName);

                        // Checks if the directory path already exists, else create the directory...
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        // Save the uploaded file to the location path of the selected petname...
                        var locationPathToSave = string.Format("{0}\\{1}", pathString, petFileNameGUID);
                        requestFiles.SaveAs(locationPathToSave);

                        // Checks if the list of ApplicationSession.GlobalParameters.PetClaimServiceList has value...
                        if (ApplicationSession.GlobalParameters.PetClaimServiceList != null)
                        {
                            // Gets the existing list on the ApplicationSession.GlobalParameters.PetClaimServiceList and save it into the temporary PetClaimServiceList...
                            this.PetClaimServiceList = ApplicationSession.GlobalParameters.PetClaimServiceList;
                        }

                        // Add new list on the temporary PetClaimServiceList...
                        PetClaimServiceList.Add(new PetClaimServiceViewModels
                        {
                            FileNameGUID = ApplicationSession.GlobalParameters.SelectedPetFileNameGUID = petFileNameGUID,
                            FileName = ApplicationSession.GlobalParameters.SelectedPetFileName = petFileName,
                            FilePath = ApplicationSession.GlobalParameters.SelectedPetFilePath = locationPathToSave,
                        });

                        // Now save and set the new list of ApplicationSession.GlobalParameters.PetClaimServiceList...
                        ApplicationSession.GlobalParameters.PetClaimServiceList = this.PetClaimServiceList;
                    }
                }
            }
            catch (Exception)
            {
                // Set the flag value to false if any unhandled exception occourred...
                isFileUploadedSuccessfully = false;
            }
            // Return the file uploading message result...
            if (isFileUploadedSuccessfully)
                return Json(new { Message = petFileNameGUID });
            else
                return Json(new { Message = "Error in saving file" });
        }
    }
}
