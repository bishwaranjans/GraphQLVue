# GraphQLVue

# API Commands

Add:
-----
mutation($techEvent : AddEventInput!) {
  createTechEvent(techEventInput:$techEvent) {
    eventId
    eventName
    eventDate
    participants {
      participantName
      email
    }
  }
}

{
  "techEvent": {
    "eventName": "Bish demonstartion of GraphQL",
    "speaker": "Bishwaranjan Sandhu",
    "eventDate": "2021-03-16"
  }
}

Update:
-------
mutation($techEvent : AddEventInput!, $techEventId: ID!) {
  updateTechEvent(techEventInput:$techEvent, techEventId:$techEventId) {
    eventId
    eventName
    eventDate
    participants {
      participantName
      email
    }
  }
}

{
  "techEvent": {
    "eventName": "Bish demonstartion of GraphQL",
    "speaker": "Bishwaranjan Sandhu",
    "eventDate": "2021-03-16"
  },
  "techEventId": 1
}

Delete:
=======
mutation($techEventId:ID!){
  deleteTechEvent(techEventId: $techEventId)
}
{
  "techEventId": 1
}
