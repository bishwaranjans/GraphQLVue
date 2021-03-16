import 'bootstrap/dist/css/bootstrap.css'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import VueApollo from "vue-apollo";

import ApolloClient from "apollo-client";
import { HttpLink } from "apollo-link-http";
import { InMemoryCache } from "apollo-cache-inmemory";

// Create an http link:
const link = new HttpLink({
    uri: 'http://localhost:14995/GraphQL'
});
const client = new ApolloClient({
    link: link,
    cache: new InMemoryCache({
        addTypename: true
    }),
    connectToDevTools: true
});

const apolloProvider = new VueApollo({
    defaultClient: client,
    defaultOptions: {
        $loadingKey: 'loading'
    }
})


createApp(App).provide(apolloProvider.provide).use(router).mount('#app')
