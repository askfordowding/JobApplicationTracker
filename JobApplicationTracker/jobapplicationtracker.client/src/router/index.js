import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/components/Home.vue'; // Import your components
import AddApplication from '@/components/AddApplication.vue';

const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/add-application', name: 'AddApplication', component: AddApplication },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;



