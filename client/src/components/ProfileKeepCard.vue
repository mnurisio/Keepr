<script setup>
import { AppState } from '@/AppState';
import { Keep } from '@/models/Keep';
import { keepsService } from '@/services/KeepsService';
import Pop from '@/utils/Pop';
import { computed } from 'vue';



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

async function DeleteKeep(keepId) {
    try {
        const confirm = await Pop.confirm("Are you sure you want to delete this keep?")
        if (!confirm) return
        await keepsService.DeleteKeep(keepId)
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <div @click="setActiveKeep()" role="button" data-bs-toggle="modal" data-bs-target="#keepModal" class="keep-card">
        <img :src="keep.img" :alt="keep.name" class="keep-img">
        <div class="marko-one text-text">
            <div class="keep-name col-6">
                {{ keep.name }}
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


@media (min-width: 768px) {
    .keep-name {
        font-size: 23.59px;
        position: absolute;
        left: 5%;
        top: calc(100% - 45px);
        color: #F9F6FA;
        text-shadow: 2px 2px 2px black;
        width: 100%;
    }
}

@media (max-width: 768px) {
    .keep-name {
        width: 100%;
        font-size: 16px;
        color: #F9F6FA;
        text-shadow: 2px 2px 2px black;
        position: absolute;
        left: 5%;
        top: calc(100% - 30px)
    }
}

.keep-card {
    box-shadow: 5px 5px -3px rgba(0, 0, 0, 0.329);
}
</style>