<script lang="ts">
import type { ProjectModel, ProjectTimeLineGroupModel, ProjectTimeLineItemModel } from '@/models/project.model';
import { calcWeekNumberOfGivenDateBetweenARangeUtil, calcWeeksBetweenTwoDatesUtil } from '@/utils/dates/week-calc.utils';
import { type PropType, toRefs, computed } from 'vue';
import ProjectTimelineItemDisplay from '@/components/ProjectTimelineItemDisplay.vue';


export default {
    props: {
        project: {
            type: Object as PropType<ProjectModel>,
            required: true
        }
    },
    emits: ["delete:group", "delete:item"],
    setup(props, { emit }) {
        const { project } = toRefs(props);
        const sortedProject = computed(() => {
            let result = project.value;
            result.timelineGroups = result.timelineGroups.sort(i => i.sortRank);
            result.timelineGroups.forEach(tlg => {
                tlg.timelineItems = tlg.timelineItems.sort(tli => tli.sortRank);
            });
            return result;
        });
        const calcWeeks = computed(() => {
            // IMPORTANT:
            // This has to be done this way. When have to create a new Date before we can use the getTime() function.
            // Thanks fucking JavaScript!
            let fromDate = new Date(project.value.projectStartDate as Date);
            let toDate = new Date(project.value.projectEndDate as Date);
            return calcWeeksBetweenTwoDatesUtil(fromDate, toDate);
        });
        function calcMyWeekNumber(timelineItem: ProjectTimeLineItemModel) {
            // IMPORTANT:
            // This has to be done this way. When have to create a new Date before we can use the getTime() function.
            // Thanks fucking JavaScript!
            let fromDate = new Date(project.value.projectStartDate as Date);
            let toDate = new Date(project.value.projectEndDate as Date);
            let givenDate = new Date(timelineItem.startDateTime) as Date;
            return calcWeekNumberOfGivenDateBetweenARangeUtil(fromDate, toDate, givenDate);
        }
        function deleteItem(timelineItem: ProjectTimeLineItemModel) {
            emit("delete:item", { timelineItem })
        }

        function deleteGroup(timelineGroup: ProjectTimeLineGroupModel) {
            emit("delete:group", { timelineGroup })
        }

        return {
            sortedProject,
            calcWeeks,
            calcMyWeekNumber,
            deleteItem,
            deleteGroup
        };
    },
    components: { ProjectTimelineItemDisplay }
}
</script>
<template>
    <figure>
        <table>
            <thead>
                <th scope="col">Beschreibung</th>
                <th scope="col"></th>
                <th scope="col">Start Datum</th>
                <th scope="col">End Datum</th>
                <th v-for="w of calcWeeks" scope="col">{{ w }}</th>
            </thead>
            <tbody v-for="tg of sortedProject.timelineGroups">
                <tr class="tg-tr">
                    <th><strong>{{ tg.title }}</strong></th>
                    <td>
                        <button v-on:click="deleteGroup(tg)" data-tooltip="Gruppe Löschen" class="danger-button small-button">x</button>
                    </td>
                    <td colspan="2"></td>
                    <td v-bind:colspan="calcWeeks">{{ tg.description }}</td>
                </tr>
                <!-- Komponente ProjectTimelineItemDisplay -->
                <tr v-for="tli of tg.timelineItems">
                    <th v-bind:data-tooltip="tli.description" scope="row">{{ tli.title }}</th>
                    <td>
                        <button v-on:click="deleteItem(tli)" data-tooltip="Item Löschen" class="danger-button small-button">x</button>
                    </td>
                    <td>{{ tli.startDateTime }}</td>
                    <td>{{  tli.endDateTime }}</td>
                    <td v-for="w of calcWeeks">
                        <div v-if="calcMyWeekNumber(tli)  == w">
                            <ProjectTimelineItemDisplay v-bind:item="tli"></ProjectTimelineItemDisplay>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </figure>
</template>
<style>
    .tg-tr {
        background-color: #AFD3E2;
    }
</style>