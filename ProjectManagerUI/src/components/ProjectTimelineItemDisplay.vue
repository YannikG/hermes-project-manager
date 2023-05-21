<template>
    <div :class=projectDurationClass :data-tooltip="itemTypeText"></div>
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
                if (props.item.type == 1) {
                    return 'meilenstein-color';
                } else if (props.item.type == 0) {
                    return 'task-color';
                } else {
                    return 'no-type-color';
                }
            });

            const itemTypeText = computed(() => {
                if (props.item.type == 1) {
                    return 'Meilenstein';
                } else if (props.item.type == 0) {
                    return 'Task';
                } else {
                    return 'Kein Typ definiert!';
                }
            });

            return {
                item,
                projectDurationClass,
                itemTypeText
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
  background-color: #E86A33;
  color: white;
  height: 30px;
  width: 30px;
}

.task-color {
  background-color: #A6D0DD;
  color: white;
  height: 30px;
  width: 30px;
}

.no-type-color {
  background-color: #9e9e9e;
  color:white;
  height: 30px;
  width: 30px;
}
</style>