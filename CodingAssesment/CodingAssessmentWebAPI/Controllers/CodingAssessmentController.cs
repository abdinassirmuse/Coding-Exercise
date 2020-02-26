using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingAssessmentDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessmentWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CodingAssessmentController : ControllerBase
    {

        Repository repository = new Repository();

        #region ***************** Login User ******************************
        [HttpGet]
        public JsonResult LoginUser(string userName, string userPassword)
        {
            string result;

            try
            {
                result = repository.LoginUser(userName, userPassword);
            }
            catch (Exception)
            {

                result = null;
            }

            return new JsonResult(result);
        }

        #endregion

        #region ****************** Add New Event *********************************
        [HttpPost]
        public JsonResult AddNewEvent(Models.EventList eventObj)
        {
            var status = false;

            try
            {
                CodingAssessmentDAL.Models.EventList events = new CodingAssessmentDAL.Models.EventList();

                events.EventId = eventObj.EventId;
                events.EventName = eventObj.EventName;
                events.EventDescription = eventObj.EventDescription;
                events.EventStartDate = eventObj.EventStartDate;
                events.EventEndDate = eventObj.EventEndDate;
                events.AddedBy = eventObj.AddedBy;

                status = repository.AddNewEvent(events);
            }
            catch (Exception)
            {

                status = false;
            }

            return new JsonResult(status);
        }

        #endregion

        #region ************* Get All Events ********************************
        [HttpGet]
        public JsonResult GetAllEvents()
        {
            List<Models.EventList> listOfEvents = new List<Models.EventList>();
            try
            {
                var eventsList = repository.GetAllEvents();
                if (eventsList.Any())
                {
                    foreach (var item in eventsList)
                    {
                        listOfEvents.Add(new Models.EventList()
                        {
                            EventId = item.EventId,
                            EventName = item.EventName,
                            EventDescription = item.EventDescription,
                            EventStartDate = item.EventStartDate,
                            EventEndDate = item.EventEndDate,
                            AddedBy = item.AddedBy
                        }
                        );
                    }
                }
            }
            catch (Exception)
            {
                listOfEvents = null;
            }
            return new JsonResult(listOfEvents);
        }

        #endregion

        // PUT: api/CodingAssessment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
