// 1
import gql from 'graphql-tag'

// 2
export const ALL_EVENTS_QUERY = gql`
query allEvents {
  events{
    eventId
    eventName
    eventDate
    speaker
  }
}
`
