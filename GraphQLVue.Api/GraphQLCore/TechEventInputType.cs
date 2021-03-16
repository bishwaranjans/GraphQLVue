using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLVue.Api.GraphQLCore
{
    public class TechEventInputType : InputObjectGraphType
    {
        public TechEventInputType()
        {
            Name = "AddEventInput";
            Field<NonNullGraphType<StringGraphType>>("eventName");
            Field<StringGraphType>("speaker");
            Field<NonNullGraphType<DateGraphType>>("eventDate");
        }
    }
}
