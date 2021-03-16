using GraphQLVue.Api.Infrastucture.DBContext;
using GraphQLVue.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Api.Infrastucture.Repositories
{
    public class TechEventRepository : ITechEventRepository
    {
        /// <summary>
        /// The _context.
        /// </summary>
        private readonly TechEventDBContext _context;

        public TechEventRepository(TechEventDBContext context)
        {
            this._context = context;
        }

        public async Task<TechEventInfo> AddTechEventAsync(NewTechEventRequest techEvent)
        {
            var savedEvent = (await _context.TechEventInfo.AddAsync(
                new TechEventInfo
                {
                    EventName = techEvent.EventName,
                    EventDate = techEvent.EventDate,
                    Speaker = techEvent.Speaker
                })).Entity;
            await _context.SaveChangesAsync();

            return savedEvent;
        }

        public async Task<bool> DeleteTechEventAsync(TechEventInfo techEvent)
        {
            _context.TechEventInfo.Remove(techEvent);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Participant>> GetParticipantsByEventIdAsync(int eventId)
        {
            var list = from ep in _context.EventParticipants
                       join p in _context.Participant on ep.ParticipantId equals p.ParticipantId
                       where ep.EventId == eventId
                       select p;

            return await list.ToListAsync();
        }

        public async Task<TechEventInfo> GetTechEventByIdAsync(int eventId)
        {
            return await _context.TechEventInfo.FirstOrDefaultAsync(s => s.EventId == eventId);
        }

        public async Task<TechEventInfo[]> GetTechEventsAsync()
        {
            return await _context.TechEventInfo.ToArrayAsync();
        }

        public async Task<TechEventInfo> UpdateTechEventAsync(TechEventInfo techEvent)
        {
            var updatedEntity = (_context.TechEventInfo.Update(techEvent)).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }
    }
}
