﻿using GraphQL.Types;
using GraphQLVue.Api.Infrastucture.DBContext;

namespace GraphQLVue.Api.GraphQLCore
{
    public class ParticipantType : ObjectGraphType<Participant>
    {
        public ParticipantType()
        {
            Field(d => d.ParticipantId).Description("Participant Id");
            Field(d => d.ParticipantName).Description("Participant Name");
            Field(d => d.Email).Description("Participant Email");
            Field(d => d.Phone).Description("Participant Phone");
        }
    }
}
