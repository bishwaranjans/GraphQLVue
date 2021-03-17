<template>
<div>
   <h1 id="tableLabel">Tech Events</h1>

    <p>This component demonstrates fetching data from the GraphQL.</p>

  <div v-if="loading">Loading...</div>

<div v-else-if="error">Error: {{ error.message }}</div>

    <table class='table table-striped' aria-labelledby="tableLabel" v-else-if="techEvents">
        <thead>
            <tr>
                <th>Event Name</th>
                <th>Speaker</th>
                <th>Date</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="techEvent of techEvents" :key="techEvent.eventId">
                <td>{{ techEvent.eventName }}</td>
                <td>{{ techEvent.speaker }}</td>
                <td>{{ techEvent.eventDate }}</td>
            </tr>
        </tbody>
    </table>
    </div>
</template>

<script>

import { useQuery, useResult } from '@vue/apollo-composable'
import gql from 'graphql-tag'

export default {
        name: "TechEvents",
       setup () {
    const { result, loading, error  } = useQuery(gql`
      query allEvents {
  events{
    eventId
    eventName
    eventDate
    speaker
  }
}
    `)

    const techEvents = useResult(result, null, data => data.events)

    return {
      techEvents,
      loading,
      error 
    }
  },
    }
</script>

<style>

</style>