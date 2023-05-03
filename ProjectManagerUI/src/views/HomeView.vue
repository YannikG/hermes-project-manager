<script lang="ts">
import { useProjectStore } from '@/stores/project.store';
import { onMounted, ref, type Ref } from 'vue';

export default {
  setup() {
    const isLoading: Ref<boolean> = ref(false);
    const store = useProjectStore();

    return {
      store
    }
  }
}

</script>

<template>
  <main class="container">
    <h1>Projekte</h1>
    <ul>
      <li v-for=" p in store.$state.projects" :key="p.id as number">{{ p.title  }}</li>
    </ul>
  </main>
</template>
