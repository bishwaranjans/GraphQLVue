using GraphQL;
using GraphQL.Types;
using GraphQLVue.Api.Infrastucture.DBContext;
using GraphQLVue.Api.Infrastucture.Repositories;
using GraphQLVue.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Api.GraphQLCore
{
    public class TechEventMutation : ObjectGraphType
    {
        public TechEventMutation(ITechEventRepository repository)
        {
            Name = "TechEventMutation";

            FieldAsync<TechEventInfoType>(
                  "createTechEvent",
                  arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<TechEventInputType>> { Name = "techEventInput" }),
                  resolve: async context =>
                  {
                      var techEventInput = context.GetArgument<NewTechEventRequest>("techEventInput");
                      return await repository.AddTechEventAsync(techEventInput);
                  });

            FieldAsync<TechEventInfoType>(
                "updateTechEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TechEventInputType>> { Name = "techEventInput" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "techEventId" }),
                resolve: async context =>
                {
                    var techEventInput = context.GetArgument<TechEventInfo>("techEventInput");
                    var techEventId = context.GetArgument<int>("techEventId");

                    var existingEventInfo = await repository.GetTechEventByIdAsync(techEventId);
                    if (existingEventInfo == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Tech event info."));
                        return null;
                    }

                    existingEventInfo.EventName = techEventInput.EventName;
                    existingEventInfo.Speaker = techEventInput.Speaker;
                    existingEventInfo.EventDate = techEventInput.EventDate;

                    return await repository.UpdateTechEventAsync(existingEventInfo);
                });

            FieldAsync<StringGraphType>(
                "deleteTechEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "techEventId" }),
                resolve: async context =>
                {
                    var techEventId = context.GetArgument<int>("techEventId");
                    var techEvent = await repository.GetTechEventByIdAsync(techEventId);

                    if (techEvent == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Tech event info."));
                        return null;
                    }

                    await repository.DeleteTechEventAsync(techEvent);
                    return $"Tech Event ID {techEventId} with Name {techEvent.EventName} has been deleted succesfully.";
                });
        }
    }
}
