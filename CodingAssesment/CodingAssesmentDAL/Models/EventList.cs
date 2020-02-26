using System;
using System.Collections.Generic;

namespace CodingAssessmentDAL.Models
{
    public partial class EventList
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public string AddedBy { get; set; }

        public Users AddedByNavigation { get; set; }
    }
}
