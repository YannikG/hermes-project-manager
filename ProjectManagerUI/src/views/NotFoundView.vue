<script setup lang="ts">

</script>

<template>
    <main class="not-found-container">
        <img class="not-found-image" alt="not found" src="@/assets/horror.svg" />
        <p class="not-found-text"><i class="for-o-for">404</i> Seite nicht gefunden</p>
    </main>
</template>
<style scoped>
    .not-found-container {
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .not-found-text {
        font-size: 3pc;
        font-weight: bold;
    }
    .not-found-text > .for-o-for {
        font-size: 5pc;
        color: orangered;
    }

    .not-found-image {
        max-height: 20em;
    }
</style>