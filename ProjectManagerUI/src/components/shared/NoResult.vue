<template>
    <div class="center">
        <img src="@/assets/taken-bro.svg" alt="No Result" />
        <div>Keine Resultate</div>
    </div>
</template>
<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'NoResult'
})
</script>
<style scoped>
    img {
        max-height: 10em;
    }

    .center {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }
</style>