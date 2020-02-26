using System;
using System.Collections.Generic;

namespace CodingAssessmentDAL.Models
{
    public partial class Users
    {
        public Users()
        {
            EventList = new HashSet<EventList>();
        }

        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserPassword { get; set; }

        public ICollection<EventList> EventList { get; set; }
    }
}
