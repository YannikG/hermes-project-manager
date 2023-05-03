import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import NotFoundView from '../views/NotFoundView.vue'
import HelpView from '@/views/HelpView.vue'
import NewProjectView from '@/views/NewProjectView.vue'
import DetailProjectView from '@/views/DetailProjectView.vue'

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
      path: '/projects/details/:id',
      name: 'detailProject',
      props: true,
      component: DetailProjectView
    },
    {
      path: '/:pathMatch(.*)*',
      component: NotFoundView
    }
  ]
})

export default router
