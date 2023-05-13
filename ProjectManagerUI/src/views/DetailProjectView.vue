
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
            <div class="col-xs-12">
                <div class="grid">
                    <button v-on:click="openAddNewGroupModal()">Neue Gruppe</button>
                    <button v-on:click="openAddNewItemToGroupModal()">Neues Item in Gruppe</button>
                </div>
            </div>
        </div>
        <div class="row">
            <ProjectDetailTable :project="project"></ProjectDetailTable>
        </div>
        <Modal v-model:open="addNewGroupModal">
            <label for="title">Titel</label>
            <input v-model="newGroup.title" name="title">
            <label for="description">Beschreibung</label>
            <textarea v-model="newGroup.description"></textarea>
            <button v-on:click="addNewGroup()">Erstellen</button>
        </Modal>

        <Modal v-model:open="addNewItemToGroupModal">
            <label for="group">Gruppe</label>
            <select v-model="newItem.timelineGroupId">
                <option v-for="group in project?.timelineGroups" :value="group.id">{{ group.title }}</option>
            </select>
            <label for="title">Titel</label>
            <input v-model="newItem.title" name="title">
            <label for="description">Beschreibung</label>
            <textarea v-model="newItem.description"></textarea>
            <div class="grid">
                <label for="StartDate">
                    Startdatum
                    <input name="StartDate" type="date" v-model="newItem.startDateTime">
                </label>
                <label for="EndDate">
                    Enddatum
                    <input name="EndDate" type="date" v-model="newItem.endDateTime">
                </label>
            </div>
            <button v-on:click="addNewTimeLineItem()">Erstellen</button>
        </Modal>
    </main>
</template>
<script setup lang="ts">
import ProjectDetailTable from '@/components/ProjectDetailTable.vue';
import Modal from '@/components/shared/Modal.vue';
import type { ProjectTimeLineGroupModel, ProjectTimeLineItemModel } from '@/models/project.model';
import { useProjectStore } from '@/stores/project.store';
import {computed, reactive, ref } from 'vue';

    const props = defineProps(["id"])
    const store = useProjectStore();

    const project = computed(() => {
        return store.getProjectById(props.id);
    });

    const newGroup = reactive({
        title: "",
        description: "",
        sortRank: 0,
    } as ProjectTimeLineGroupModel );

    const newItem = reactive({
        title: "",
        description: "",
        startDateTime: new Date(Date.now()),
        endDateTime: new Date(Date.now()),
        sortRank: 0,
    } as ProjectTimeLineItemModel );

    const addNewGroupModal = ref(false);
    const addNewItemToGroupModal = ref(false);

    const openAddNewGroupModal = () => {
        addNewGroupModal.value = true;
    }

    const addNewGroup= () => {
        store.addNewGroupToProject(project.value!.id!, newGroup)
            .then(() => {
                addNewGroupModal.value = false;
                newGroup.title = "";
                newGroup.description = "";
                newGroup.sortRank = 0;
            });
    }

    const openAddNewItemToGroupModal = () => {
        addNewItemToGroupModal.value = true;
    }

    const addNewTimeLineItem = () => {
        store.addNewTimelineItemToGroup(newItem.timelineGroupId, newItem)
            .then(() => {
                addNewItemToGroupModal.value = false;
                newItem.timelineGroupId = 0;
                newItem.title = "";
                newItem.description = "";
                newItem.startDateTime = new Date(Date.now());
                newItem.endDateTime = new Date(Date.now());
                newItem.sortRank = 0;
            });
    }

</script>