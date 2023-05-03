
<template>
    <main class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>
                    {{ project?.title }}
                </h1>
                <p>
                    {{ project?.description }}
                </p>
            </div>
        </div>
        <div class="row">
            
        </div>
    </main>
</template>
<script setup lang="ts">
import { useProjectStore } from '@/stores/project.store';

    const props = defineProps(["id"])
    const store = useProjectStore();

    const project = store.$state.projects.find(p => p.id == props.id);

</script>