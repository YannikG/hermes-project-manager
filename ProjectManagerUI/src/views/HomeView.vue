<script lang="ts">
import { onMounted, ref, type Ref } from 'vue';

export default {
  setup() {
    const projects: Ref<any[]> = ref<any[]>([]);
    const isLoading: Ref<boolean> = ref(false);
    onMounted(() => {
      isLoading.value = true;
      fetch("/api/projects")
        .then(response => response.json())
        .then(data => {
          projects.value = data;
          isLoading.value = false;
        })
    })

    return {
      projects,
      isLoading
    }
  }
}

</script>

<template>
  <main class="container">
    <h1>Projekte</h1>
    <progress v-if="isLoading"></progress>
    <ul>
      <li v-for=" p in projects" :key="p.id">{{ p.title  }}</li>
    </ul>
  </main>
</template>
