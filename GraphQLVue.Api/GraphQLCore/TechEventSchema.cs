using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
