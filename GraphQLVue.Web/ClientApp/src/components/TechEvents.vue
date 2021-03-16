<template>
    <div class="hello">
        <h1>Hi Bish! Welcome to Tech Events!</h1>
    </div>
    <hr />

    <h4 v-if="loading">Loading...</h4>
    <div v-if="error">{{ error }}</div>
    <table border='1' width='100%' style='border-collapse: collapse;'>
        <tr>
            <th>Event Name</th>
            <th>Speaker</th>
            <th>Date</th>
        </tr>

        <tr v-for='event in events' v-bind:key="event">
            <td>{{ event.eventName }}</td>
            <td>{{ event.speaker }}</td>
            <td>{{ event.eventDate }}</td>
            <td>
                <input type="button" @click="selectTechEvent(event)" value="Select">
                <input type="button" @click="deleteTechEvent(event.eventId)" value="Delete">
            </td>
        </tr>
    </table>
    <br />
    <form>
        <label>Event Name</label>
        <input type="text" name="eventName" v-model="eventName">
        <br />

        <label>Speaker</label>
        <input type="text" name="speaker" v-model="speaker">
        <br />

        <label>Event Date</label>
        <input type="datetime" name="eventDate" v-model="eventDate">
        <br />

        <input v-if="!eventId" type="button" @click="createTechEvent(eventName, speaker, eventDate)" value="Add">
        <input v-if="eventId" type="button" @click="updateTechEvent(eventId,eventName, speaker, eventDate)" value="Update">
        <input type="button" @click="clearForm()" value="Clear">

    </form>
</template>

<script>
    import { ALL_EVENTS_QUERY } from '../constants/graphql'

    export default {
        name: "TechEvents",       
        data() {
            return {
                events: [],
                error: null
            }
        },
        apollo: {
            events: {
                query: ALL_EVENTS_QUERY,
                error(error) {
                    this.error = JSON.stringify(error.message);
                }
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    /* Thick red border */
    hr {
        border: 1px solid red;
    }
</style>
