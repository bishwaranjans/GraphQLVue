import 'bootstrap/dist/css/bootstrap.css'
import { createApp, h, provide } from "vue";
import {
  ApolloClient,
  InMemoryCache,
  from,
  HttpLink,
} from "@apollo/client/core";
import { ApolloClients } from "@vue/apollo-composable";
import App from "./App.vue";
import router from './router'

const additiveLink = from([
      new HttpLink({ uri: "http://localhost:14995/graphql" }),
  ]);
 
  const apolloClient = new ApolloClient({
    link: additiveLink,
    cache: new InMemoryCache(),
  });
  
  const app = createApp({
    setup() {
      provide(ApolloClients, {
        default: apolloClient,
      });
    },
    render: () => h(App),
  });

app.use(router).mount("#app");
