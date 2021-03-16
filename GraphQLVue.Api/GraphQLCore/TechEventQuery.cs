using GraphQL;
using GraphQL.Types;
using GraphQLVue.Api.Infrastucture.DBContext;
using GraphQLVue.Api.Infrastucture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Api.GraphQLCore
{
    public class TechEventQuery : ObjectGraphType
    {
        public TechEventQuery(ITechEventRepository repository)
        {
            FieldAsync<ListGraphType<TechEventInfoType>>(
                "events",
                resolve: async context =>
                {
                    return await repository.GetTechEventsAsync();
                });

            FieldAsync<ListGraphType<TechEventInfoType>>(
                "event",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "eventId" }),
                resolve: async context =>
                 {
                     return await repository.GetTechEventByIdAsync(context.GetArgument<int>("eventId"));
                 });

        }
    }
}
