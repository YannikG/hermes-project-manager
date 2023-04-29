import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import NotFoundView from '../views/NotFoundView.vue'
import HelpView from '@/views/HelpView.vue'
import NewProjectView from '@/views/NewProjectView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/help',
      name: 'help',
      component: HelpView
    },
    {
      path: '/projects/new',
      name: 'newProject',
      component: NewProjectView
    },
    {
      path: '/:pathMatch(.*)*',
      component: NotFoundView
    }
  ]
})

export default router
