using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Using Custom Modules
using CodingAssessmentDAL.Models;

namespace CodingAssessmentWebAPI
{
    public class CoddingAssessmentMapper : Profile
    {
        public CoddingAssessmentMapper()
        {
            //Users Mapper
            CreateMap<Users, Models.Users>();
            CreateMap<Models.Users, Users>();

            //Event Mapper
            CreateMap<EventList, Models.EventList>();
            CreateMap<Models.EventList, EventList>();
        }
       
    }
}
