using PetService.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetService.MVC
{
    /// <summary>
    /// The application global session objets.
    /// </summary>
    public class ApplicationSession
    {
        /// <summary>
        /// Provides collection of global parameters for PetSure Web Application.
        /// </summary>
        public static class GlobalParameters
        {
            private static int _selectedPetNameId;
            /// <summary>
            /// Gets or sets the unique id for the selected Pet.
            /// </summary>
            public static int SelectedPetNameId
            {
                get { return _selectedPetNameId = Convert.ToInt32(System.Web.HttpContext.Current.Session["SelectedPetNameId"]); }
                set { System.Web.HttpContext.Current.Session["SelectedPetNameId"] = _selectedPetNameId = value; }
            }

            private static string _selectedPetName;
            /// <summary>
            /// Gets or sets the name of the selected Pet.
            /// </summary>
            public static string SelectedPetName
            {
                get { return _selectedPetName = System.Web.HttpContext.Current.Session["SelectedPetName"] == null ? string.Empty : System.Web.HttpContext.Current.Session["SelectedPetName"].ToString(); }
                set { System.Web.HttpContext.Current.Session["SelectedPetName"] = _selectedPetName = value; }
            }

            private static string _selectedPetFileNameGUID;
            /// <summary>
            /// Gets or sets the file name of the selected Pet.
            /// </summary>
            public static string SelectedPetFileNameGUID
            {
                get { return _selectedPetFileNameGUID = System.Web.HttpContext.Current.Session["SelectedPetFileNameGUID"] == null ? string.Empty : System.Web.HttpContext.Current.Session["SelectedPetFileNameGUID"].ToString(); }
                set { System.Web.HttpContext.Current.Session["SelectedPetFileNameGUID"] = _selectedPetFileNameGUID = value; }
            }

            private static string _selectedPetFileName;
            /// <summary>
            /// Gets or sets the file name of the selected Pet.
            /// </summary>
            public static string SelectedPetFileName
            {
                get { return _selectedPetFileName = System.Web.HttpContext.Current.Session["SelectedPetFileName"] == null ? string.Empty : System.Web.HttpContext.Current.Session["SelectedPetFileName"].ToString(); }
                set { System.Web.HttpContext.Current.Session["SelectedPetFileName"] = _selectedPetFileName = value; }
            }

            private static string _selectedPetFilePath;
            /// <summary>
            /// Gets or sets the file path of the selected Pet.
            /// </summary>
            public static string SelectedPetFilePath
            {
                get { return _selectedPetFilePath = System.Web.HttpContext.Current.Session["SelectedPetFilePath"] == null ? string.Empty : System.Web.HttpContext.Current.Session["SelectedPetFilePath"].ToString(); }
                set { System.Web.HttpContext.Current.Session["SelectedPetFilePath"] = _selectedPetFilePath = value; }
            }

            private static List<PetClaimServiceViewModels> _petClaimServiceList;
            /// <summary>
            /// Gets or sets the list of PetClaimServiceList.
            /// </summary>
            public static List<PetClaimServiceViewModels> PetClaimServiceList
            {
                get { return _petClaimServiceList = System.Web.HttpContext.Current.Session["PetClaimServiceList"] == null ? null : (List<PetClaimServiceViewModels>)System.Web.HttpContext.Current.Session["PetClaimServiceList"]; }
                set { System.Web.HttpContext.Current.Session["PetClaimServiceList"] = _petClaimServiceList = value; }
            }
        }
    }
}