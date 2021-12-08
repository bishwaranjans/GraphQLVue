using GraphQL;
using GraphQL.Types;
using GraphQLVue.Api.Infrastucture.Repositories;

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

            FieldAsync<TechEventInfoType>(
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
