using GraphQL.Types;
using GraphQLVue.Api.Infrastucture.DBContext;
using GraphQLVue.Api.Infrastucture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Api.GraphQLCore
{
    public class TechEventInfoType : ObjectGraphType<TechEventInfo>
    {
        public TechEventInfoType(ITechEventRepository repository)
        {
            Field(d => d.EventId).Description("Event Id");
            Field(d => d.EventName).Description("Event Name");
            Field(d => d.EventDate).Description("Event Date");
            Field(d => d.Speaker).Description("Event Speaker");

            Field<ListGraphType<ParticipantType>>(
                "participants",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
                resolve: context =>
                {
                    return repository.GetParticipantsByEventIdAsync(context.Source.EventId);
                });
        }
    }
}
