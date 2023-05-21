
<template>
    <main class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>
                    {{ project?.title }}
                </h1>
                <p>
                    {{ project?.description }} <br/>
                    {{ project?.projectStartDate }} bis {{ project?.projectEndDate }}
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="grid">
                    <button v-on:click="openAddNewGroupModal()">Neue Gruppe</button>
                    <button v-on:click="openAddNewItemToGroupModal()">Neues Item in Gruppe</button>
                    <button class="danger-button" v-on:click="openRemoveProjectModal()">Projekt löschen</button>
                </div>
            </div>
        </div>
        <div class="row">
            <ProjectDetailTable v-on:delete:group="deleteGroup($event.timelineGroup)" v-on:delete:item="deleteItem($event.timelineItem)" :project="project"></ProjectDetailTable>
        </div>
        <!-- Remove Project Modal -->
        <Modal v-model:open="removeProjectModal">
            <h3>"{{ project.title }}" wirklich löschen?</h3>
            <button class="danger-button" v-on:click="removeProject()">Unwiderruflich löschen</button>
        </Modal>

        <!-- Add New Group Modal -->
        <Modal v-model:open="addNewGroupModal">
            <h3>Neue Gruppe erstellen</h3>
            <label for="title">Titel</label>
            <input v-model="newGroup.title" name="title">
            <label for="description">Beschreibung</label>
            <textarea v-model="newGroup.description"></textarea>
            <button v-on:click="addNewGroup()">Erstellen</button>
        </Modal>

        <!-- Add New Item Modal -->
        <Modal v-model:open="addNewItemToGroupModal">
            <h3>Neues Item erstellen</h3>
            <label for="group">Gruppe</label>
            <select v-model="newItem.timelineGroupId">
                <option v-for="group in project?.timelineGroups" :value="group.id">{{ group.title }}</option>
            </select>
            <label for="title">Titel</label>
            <input v-model="newItem.title" name="title">
            <label for="description">Beschreibung</label>
            <textarea v-model="newItem.description"></textarea>
            <label for="type">Typ</label>
            <select v-model="newItem.type">
                <option v-for="t in itemTypes" :value="t.id">{{ t.title }}</option>
            </select>
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
import type { ProjectModel, ProjectTimeLineGroupModel, ProjectTimeLineItemModel } from '@/models/project.model';
import { useProjectStore } from '@/stores/project.store';
import {computed, reactive, ref } from 'vue';
import { useRouter } from 'vue-router';

    // Props.
    const props = defineProps(["id"])
    
    // Store and router.
    const store = useProjectStore();
    const router = useRouter();

    // Load project.
    const project = computed(() => {
        return store.getProjectById(props.id) as ProjectModel;
    });

    // New group and item for forms.
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
        type: 0,
    } as ProjectTimeLineItemModel );

    // Modal control refs.
    const addNewGroupModal = ref(false);
    const addNewItemToGroupModal = ref(false);
    const removeProjectModal = ref(false);

    // Default values.
    const itemTypes = [{id: 0, title: "Arbeitspaket"}, {id: 1, title: "Meilenstein"}];

    // Project logic.
    const openRemoveProjectModal = () => {
        removeProjectModal.value = true;
    }
    const removeProject = () => {
        removeProjectModal.value = false;
        store.deleteProject(project.value!.id!)
        router.push("/");
    }

    // Group logic.
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
    const deleteGroup = (timelineGroup: ProjectTimeLineGroupModel) => {
        store.deleteGroupFromProject(project.value!.id!, timelineGroup);
    }

    // Item logic.
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
    const deleteItem = (timelineItem: ProjectTimeLineItemModel) => {
        console.log(timelineItem);
        store.deleteTimelineItemFromGroup(project.value.id!, timelineItem);
    }
</script>