<template>
   <h1 id="tableLabel">Tech Events</h1>

    <p>This component demonstrates fetching data from the GraphQL.</p>

    <p v-if="!techEvents"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="techEvents">
        <thead>
            <tr>
                <th>Event Name</th>
                <th>Speaker</th>
                <th>Date</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="techEvent of techEvents" v-bind:key="techEvent">
                <td>{{ techEvent.eventName }}</td>
                <td>{{ techEvent.speaker }}</td>
                <td>{{ techEvent.eventDate }}</td>
            </tr>
        </tbody>
    </table>
</template>

<script>
export default {
        name: "TechEvents",
        data() {
            return {
                techEvents: []
            }
        },
        methods: {
            getTechEvents() {
                this.techEvents.push({eventId:1,eventName:'Bish Demo',speaker:'Bishwaranjan Sandhu',eventDate:'2021-12-12'});
            }
        },
        mounted() {
            this.getTechEvents();
        }
    }
</script>

<style>

</style>