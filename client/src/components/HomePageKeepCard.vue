<script setup>
import { AppState } from '@/AppState';
import { Keep } from '@/models/Keep';
import { keepsService } from '@/services/KeepsService';
import Pop from '@/utils/Pop';
import { computed, watch } from 'vue';



const account = computed(() => AppState.account)
const activeKeep = computed(() => AppState.activeKeep)

const props = defineProps({
    keep: { type: Keep, required: true }
})



async function setActiveKeep() {
    try {
        keepsService.setActiveKeep(props.keep)
        activeKeep.value.views++
    }
    catch (error) {
        Pop.error(error);
    }

}


async function getKeepById() {
    try {
        const keepId = activeKeep.value.id
        await keepsService.getKeepById(keepId)
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <div @click="setActiveKeep()" role="button" data-bs-toggle="modal" data-bs-target="#keepModal" class="keep-card">
        <img :src="keep.img" :alt="keep.name" class="keep-img">
        <div class="d-flex flex-column justify-content-between">
            <div>
                <div v-if="keep.creatorId == account?.id">
                    <button title="Delete Keep" class="btn btn-danger"><i class="mdi mdi-close"></i></button>
                </div>
            </div>
            <div>
                <div class="keep-name">
                    {{ keep.name }}
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.keep-img {
    width: 100%;
    background-size: cover;
    background-position: center;
    border-radius: 10px;
    box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
}

.keep-name {
    position: absolute;
    left: 25px;
    top: 20px;
}

.keep-card{
    box-shadow: 5px 5px -3px rgba(0, 0, 0, 0.329)
}

button {
    position: absolute;
    left: 184px;
    top: -20px;
    aspect-ratio: 1/1;
    border-radius: 50%;
}
</style>