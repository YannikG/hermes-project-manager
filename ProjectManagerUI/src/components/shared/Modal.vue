<template>
    <dialog open v-if="open">
        <article>
            <slot></slot>
            <footer>
                <a href="#close"
                    role="button"
                    class="secondary"
                    data-target="modal-example"
                    @click="closeModal()">
                    Schliessen
                </a>
            </footer>
        </article>
    </dialog>
</template>
<script lang="ts">
import { defineComponent, ref, watch } from 'vue';


export default defineComponent({
    props : {
        open: {
            type: Boolean,
            required: true
        }  
    },
    setup(props, { emit }) {
        const open = ref(props.open);

        watch(() => props.open, (newValue) => {
            open.value = newValue;
        });

        const closeModal = () => {
            open.value = false;
            emit('update:open', open.value);
        }

        return {
            open,
            closeModal
        }
    }
})

</script>