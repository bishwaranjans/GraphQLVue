using GraphQL.Types;

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
