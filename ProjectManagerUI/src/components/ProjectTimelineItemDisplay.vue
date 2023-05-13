<template>
    <div :class=projectDurationClass>
        <div >
            <div v-if="item.type === 0">Meilenstein</div>
            <div v-else-if="item.type === 1">Task</div>
            <div v-else>Kein Typ definiert!</div>
        </div>
    </div>
</template>

<script lang="ts">
import type { ProjectTimeLineItemModel } from '@/models/project.model';
import { defineComponent, type PropType, computed } from 'vue';

    export default defineComponent({
        props:{
            item: {
            type: Object as PropType<ProjectTimeLineItemModel>,
            required: true
            }
        },
        setup(props) {
            const item = props.item;

            const projectDurationClass = computed(() => {
                if (props.item.type === 0) {
                    return 'meilenstein-color';
                } else if (props.item.type === 1) {
                    return 'task-color';
                } else {
                    return 'no-type-color';
                }
            });

            return {
                item,
                projectDurationClass
            }
        }
    });

</script>

<style scoped>
.timeline-item {
  position: relative;
  display: inline-block;
}

.meilenstein-color {
  background-color: #ff0000;
  color: white;
  height: 50px;
  width: 50px;
}

.task-color {
  background-color: #2196f3;
  color: white;
  height: 50px;
  width: 50px;
}

.no-type-color {
  background-color: #9e9e9e;
  color:white;
  height: 50px;
  width: 50px;
}
</style>