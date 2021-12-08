using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace GraphQLVue.Api.GraphQLCore
{
    public class TechEventSchema : Schema
    {
        public TechEventSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<TechEventQuery>();
            Mutation = provider.GetRequiredService<TechEventMutation>();
        }
    }
}
