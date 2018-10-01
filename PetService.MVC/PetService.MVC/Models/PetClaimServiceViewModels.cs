using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetService.MVC.Models
{
    /// <summary>
    /// Provides model for PetClaimService
    /// </summary>
    public class PetClaimServiceViewModels
    {
        /// <summary>
        /// Gets or Sets the Pet Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the Pet Name.
        /// </summary>
        public string PetName { get; set; }

        /// <summary>
        /// Gets or Sets the Pet FileName.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or Sets the Pet FilePath.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or Sets the Pet FileNameGUID.
        /// </summary>
        public string FileNameGUID { get; set; }

        /// <summary>
        /// Gets or Sets the uploading date of invoice file first created.
        /// </summary>
        public Nullable<System.DateTime> CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets the last uploading date of invoice file.
        /// </summary>
        public Nullable<System.DateTime> UploadedDate { get; set; }

        /// <summary>
        /// Gets or Sets the save date for later submission.
        /// </summary>
        public Nullable<System.DateTime> SavedDate { get; set; }

        /// <summary>
        /// Gets or Sets submitted date for pet claim.
        /// </summary>
        public Nullable<System.DateTime> PetClaimedDate { get; set; }

        /// <summary>
        /// Gets or Sets the Pet List.
        /// </summary>
        public virtual PetList PetList { get; set; }
    }
}