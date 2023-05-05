<script lang="ts">
import type { ProjectModel } from '@/models/project.model';
import { toRef, type PropType, toRefs, computed } from 'vue';


export default {
    props: {
        project: {
            type: Object as PropType<ProjectModel>,
            required: true
        }
    },
    setup(props){        
        const { project } = toRefs(props);

        const calcWeeks = computed(() => {

            // IMPORTANT:
            // This has to be done this way. When have to create a new Date before we can use the getTime() function.
            // Thanks fucking JavaScript!
            let fromDate = new Date(project.value.projectStartDate as Date);
            let toDate = new Date(project.value.projectEndDate as Date);

            // Get diff in Weeks between the two dates.
            let diff = Math.abs(fromDate.getTime() - toDate.getTime());
            let diffDays = Math.ceil(diff / (1000 * 3600 * 24)); 
            let diffWeeks = Math.ceil(diffDays / 7);

            return diffWeeks;
        });

        return {
            project,
            calcWeeks
        }
    }
}
</script>
<template>
    <figure>
        <table>
            <thead>
                <th scope="col">Beschreibung</th>
                <th v-for="w of calcWeeks" scope="col">{{ w }}</th>
            </thead>
            <tbody>
                <tr v-for="tg of project.timelineGroups">
                    <th v-bind:data-tooltip="tg.description" scope="row">{{ tg.title }}</th>
                    <td v-for="w of calcWeeks" ></td>
                </tr>
            </tbody>
        </table>
    </figure>
</template>