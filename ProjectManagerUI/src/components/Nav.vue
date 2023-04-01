<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
    <header class="container">
        <nav>
            <ul>
                <li><strong>HERMES Projekt Manager</strong></li>
            </ul>
            <ul>
                <li>
                    <RouterLink to="/">Projekte</RouterLink>
                </li>
                <li>
                    <RouterLink to="/help">Hilfe</RouterLink>
                </li>
                <li>
                    <RouterLink role="button" to="/create">Neues Projekt erstellen</RouterLink>
                </li>
            </ul>
        </nav>
    </header>
</template>