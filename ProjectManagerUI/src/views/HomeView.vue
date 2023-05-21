<script lang="ts">
import { useProjectStore } from '@/stores/project.store';
import NoResult from '@/components/shared/NoResult.vue';

export default {
    setup() {
        const store = useProjectStore();
        return {
            store
        };
    },
    components: { NoResult }
}

</script>

<template>
  <main class="container">
    <h1>Projekte</h1>
    <div class="row">
      <div class="col-xs-12 col-md-6" v-for=" p in store.$state.projects" :key="p.id as number">
        <article>
          <div class="row">
            <div class="col-xs-12">
              <h1>{{ p.title }}</h1>
              <p>
                {{ p.description }}
              </p>
            </div>
          </div> 
          <div class="row end-xs">
              <div class="col-xs-12 col-md-6">
                  <RouterLink :to="{ name: 'detailProject', params : {id: p.id }}">Zum Projekt</RouterLink>
              </div>
          </div>
        </article>
      </div>
      <NoResult v-if="store.$state.projects.length == 0"></NoResult>
    </div>
  </main>
</template>
