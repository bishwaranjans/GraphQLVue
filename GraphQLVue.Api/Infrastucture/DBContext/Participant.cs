using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Api.Infrastucture.DBContext
{
    public class Participant
    {
        public Participant()
        {
            EventParticipants = new HashSet<EventParticipants>();
        }

        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<EventParticipants> EventParticipants { get; set; }
    }
}
