
<template>
    <main class="container">
        <h1>Neues Projekt erstellen</h1>
        {{ error }}
        <form>
            <label for="title">Titel</label>
            <input v-model="newProject.title" name="title">
            <label for="description">Beschreibung</label>
            <textarea v-model="newProject.description"></textarea>
            <div class="grid">
                <label for="configWorkHoursPerDay">
                    Stunden pro Arbeitstag
                    <input name="configWorkHoursPerDay" type="date" v-model="newProject.configWorkHoursPerDay">
                </label>
                <label for="configWorkHoursPerWeek">
                    Stunden pro Woche
                    <input name="configWorkHoursPerWeek" type="date" v-model="newProject.configWorkHoursPerWeek">
                </label>
            </div>
        </form>
        <div class="grid">
            <button class="secondary" v-on:click="resetForm()">Zurücksetzten</button>
            <button v-bind:aria-busy="isLeading" v-on:click="createProject()">Erstellen</button>
        </div>
    </main>
</template>

<script setup lang="ts">
import { reactive } from 'vue';

    let error = "";
    let isLeading = false;

    // reactive weil ansonsten die Werte im Template nicht angepasst werden.
    let newProject = reactive({
        title: "New Project",
        description: "",
        configWorkHoursPerDay: 8,
        configWorkHoursPerWeek: 40,
        projectStartDate: Date.now(),
        projectEndDate: Date.now()
    });

    const createProject = ():void => {
        console.log(newProject);
    };

    const resetForm = ():void => {
        newProject.title = "New Project";
        newProject.description = "";
        newProject.configWorkHoursPerDay = 8;
        newProject.configWorkHoursPerWeek = 40;
        newProject.projectStartDate = Date.now();
        newProject.projectEndDate = Date.now();
    };


</script>