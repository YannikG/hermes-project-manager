import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createPinia } from 'pinia'

import "@picocss/pico/css/pico.min.css";
import "@picocss/pico/css/themes/default.min.css";
// Does not work?!
// import "flexboxgrid/css/flexboxgrid.min.css/";

import { useProjectStore } from './stores/project.store';

const app = createApp(App)
const pinia = createPinia()
app.use(pinia)

// make sure all data is loaded before the application has a chance to start up.
const store = useProjectStore();
await store.loadProjects();

app.use(router)

app.mount('#app')
