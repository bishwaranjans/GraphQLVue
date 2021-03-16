using GraphQLVue.Api.Infrastucture.DBContext;
using GraphQLVue.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Api.Infrastucture.Repositories
{
    public interface ITechEventRepository
    {
        Task<TechEventInfo[]> GetTechEventsAsync();
        Task<TechEventInfo> GetTechEventByIdAsync(int eventId);
        Task<List<Participant>> GetParticipantsByEventIdAsync(int eventId);
        Task<TechEventInfo> AddTechEventAsync(NewTechEventRequest techEvent);
        Task<TechEventInfo> UpdateTechEventAsync(TechEventInfo techEvent);
        Task<bool> DeleteTechEventAsync(TechEventInfo techEvent);
    }
}
