using PetService.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetService.MVC.Controllers
{
    /// <summary>
    /// The API controller that defines methods and properties that respond to HTTP requests for PetSure Home. 
    /// </summary>
    public class PetSureController : ApiController
    {
        /// <summary>
        /// Private list for PetList model.
        /// </summary>
        private List<PetList> petList = new List<PetList>();

        // GET api/<controller>
        /// <summary>
        /// Provides a list of Pet Names for PetSure Web Application System.
        /// </summary>
        /// <returns>Returns list of Pet Names.</returns>
        [HttpGet]
        public IEnumerable<PetList> Get()
        {
            // Starts connecting to the database...
            using (PetSureDatabaseEntities dbo = new PetSureDatabaseEntities())
            {
                // Start the database transaction to ensure that the Entity Framework executes commands on the database within the context of that transaction...
                using (System.Data.Entity.DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        // Get the available list of Pet Name on the database...
                        this.petList.Clear();
                        var petListQuery = from o in dbo.PetLists
                                      select new { o.PetId, o.PetName };
                        foreach (var list in petListQuery)
                        {
                            this.petList.Add(new PetList{
                                PetId = list.PetId,
                                PetName = list.PetName 
                            });
                        }
                        // Returns the pet list...
                        return this.petList;
                    }
                    catch (Exception)
                    {
                        // ROLLBACK TRANSACTION FOR ANY UNHANDLED EXCEPTION...
                        transaction.Rollback();
                        return this.petList;
                    }
                    finally
                    {
                        // CLEANS UP TRANSACTION OBJECT AND ENSURES THE ENTITY FRAMEWORK IS NO LONGER USING THAT TRANSACTION...
                        transaction.Dispose();
                    }
                }
            }
        }

        // GET api/<controller>/5
        /// <summary>
        /// Provides a list of Pet Names for PetSure Web Application System.
        /// </summary>
        /// <param name="id">The pet id to retrive data.</param>
        /// <returns>Returns a Pet Name base on the given id.</returns>
        public List<PetList> Get(int id)
        {
            // Starts connecting to the database...
            using (PetSureDatabaseEntities dbo = new PetSureDatabaseEntities())
            {
                // Start the database transaction to ensure that the Entity Framework executes commands on the database within the context of that transaction...
                using (System.Data.Entity.DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        // Get the available list of Pet Name on the database...
                        this.petList.Clear();
                        var petListQuery = from o in dbo.PetLists
                                           where o.PetId == id
                                           select new { o.PetId, o.PetName };
                        foreach (var list in petListQuery)
                        {
                            this.petList.Add(new PetList
                            {
                                PetId = list.PetId,
                                PetName = list.PetName
                            });
                        }
                        // Returns the pet list...
                        return this.petList;
                    }
                    catch (Exception)
                    {
                        // ROLLBACK TRANSACTION FOR ANY UNHANDLED EXCEPTION...
                        transaction.Rollback();
                        return this.petList;
                    }
                    finally
                    {
                        // CLEANS UP TRANSACTION OBJECT AND ENSURES THE ENTITY FRAMEWORK IS NO LONGER USING THAT TRANSACTION...
                        transaction.Dispose();
                    }
                }
            }
        }

        // POST api/<controller>
        /// <summary>
        /// Post the a list of Pet Names for PetSure Web Application System.
        /// </summary>
        /// <param name="value">The list of Pet Names to add for PetSure Web Application System.</param>
        [HttpPost]
        public bool Post(string value)
        {
            int affecteRecordCount = 0;
            try
            {                
                // Starts connecting to the database...
                using (PetSureDatabaseEntities dbo = new PetSureDatabaseEntities())
                {
                    // Start the database transaction to ensure that the Entity Framework executes commands on the database within the context of that transaction...
                    using (System.Data.Entity.DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            // Adds the list of Pet Names...
                            PetList petList = new PetList();
                            petList.PetName = value;
                            dbo.PetLists.Add(petList);
                            affecteRecordCount = dbo.SaveChanges();
                            
                            // Commits the underlying store transaction...
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            // ROLLBACK TRANSACTION FOR ANY UNHANDLED EXCEPTION...
                            transaction.Rollback();
                        }
                        finally
                        {
                            // CLEANS UP TRANSACTION OBJECT AND ENSURES THE ENTITY FRAMEWORK IS NO LONGER USING THAT TRANSACTION...
                            transaction.Dispose();
                            
                        }
                    }
                }
                return affecteRecordCount >= 0 ? true : false;
            }
            catch (Exception) { return affecteRecordCount >= 0 ? true : false; }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Put the a list of Pet Names for PetSure Web Application System.
        /// </summary>
        /// <param name="value">The list of Pet Names to be updated for PetSure Web Application System.</param>
        [HttpPut]
        public bool Put(int id, string value)
        {
            int affecteRecordCount = 0;
            try
            {
                // Starts connecting to the database...
                using (PetSureDatabaseEntities dbo = new PetSureDatabaseEntities())
                {
                    // Start the database transaction to ensure that the Entity Framework executes commands on the database within the context of that transaction...
                    using (System.Data.Entity.DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            // Finds the id of the pet and update it value...
                            PetList petList = dbo.PetLists.Find(id);
                            petList.PetName = value;
                            dbo.PetLists.Add(petList);
                            dbo.Entry(petList).State = System.Data.Entity.EntityState.Modified;
                            affecteRecordCount = dbo.SaveChanges();

                            // Commits the underlying store transaction...
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            // ROLLBACK TRANSACTION FOR ANY UNHANDLED EXCEPTION...
                            transaction.Rollback();
                        }
                        finally
                        {
                            // CLEANS UP TRANSACTION OBJECT AND ENSURES THE ENTITY FRAMEWORK IS NO LONGER USING THAT TRANSACTION...
                            transaction.Dispose();
                        }
                    }
                }
                return affecteRecordCount >= 0 ? true : false;
            }
            catch (Exception) { return affecteRecordCount >= 0 ? true : false; }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Delete the a list of Pet Names for PetSure Web Application System.
        /// </summary>
        /// <param name="value">The id of Pet to be deleted for PetSure Web Application System.</param>
        [HttpDelete]
        public bool Delete(int id)
        {
            int affecteRecordCount = 0;
            try
            {
                // Starts connecting to the database...
                using (PetSureDatabaseEntities dbo = new PetSureDatabaseEntities())
                {
                    // Start the database transaction to ensure that the Entity Framework executes commands on the database within the context of that transaction...
                    using (System.Data.Entity.DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            // Finds the id of the Pet to be deleted...
                            PetList petList = dbo.PetLists.Find(id);
                            dbo.PetLists.Remove(petList);
                            affecteRecordCount = dbo.SaveChanges();

                            // Commits the underlying store transaction...
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            // ROLLBACK TRANSACTION FOR ANY UNHANDLED EXCEPTION...
                            transaction.Rollback();
                        }
                        finally
                        {
                            // CLEANS UP TRANSACTION OBJECT AND ENSURES THE ENTITY FRAMEWORK IS NO LONGER USING THAT TRANSACTION...
                            transaction.Dispose();
                        }
                    }
                }
                return affecteRecordCount >= 0 ? true : false;
            }
            catch (Exception) { return affecteRecordCount >= 0 ? true : false; }
        }
    }
}