using System;
using System.Collections.Generic;
using System.Linq;


//Custom Modules
using CodingAssessmentDAL.Models;


namespace CodingAssessmentDAL
{
    public class Repository
    {
        private CodingAssessmentDBContext context { get; set; }

        public Repository()
        {
            this.context = new CodingAssessmentDBContext();
        }

        public Repository(CodingAssessmentDBContext context)
        {
            this.context = context;
        }

        #region ************************** LoginUser *******************************
        public string LoginUser(string userName, string userPassword)
        {
            string roleName = "";
            try
            {
                var objUser = (from usr in context.Users
                               where usr.UserName == userName && usr.UserPassword == userPassword
                               select usr).FirstOrDefault<Users>();

                if (objUser != null)
                {
                    roleName = objUser.UserRole;
                }
                else
                {
                    roleName = "Invalid credentials";
                }
                    
                
            }
            catch (Exception)
            {
                roleName = "Invalid credentials";
            }
            return roleName;
        }
        #endregion

        #region **************************** Add New Event ********************************
        public bool AddNewEvent(EventList eventObj)
        {
            bool isEventAdd = false;
            try
            {
                context.EventList.Add(eventObj);
                context.SaveChanges();

                isEventAdd = true;
            }
            catch (Exception)
            {

                isEventAdd = false;
            }

            return isEventAdd;
        }
        #endregion

        #region ************************** Get All Events *******************************
        public List<EventList> GetAllEvents()
        {
            List<EventList> listOfProducts = null;
            try
            {
                listOfProducts = (from p in context.EventList
                                  select p).ToList<EventList>();
            }
            catch (Exception)
            {
                listOfProducts = null;
            }
            return listOfProducts;
        }
        #endregion
    }
}
