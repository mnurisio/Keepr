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
        await keepsService.getKeepById(activeKeep.value.id)
        if (activeKeep.value.creatorId == account.value?.id) return
        activeKeep.value.views++
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
    <div v-if="keep.creatorId == account?.id">
        <button @click="DeleteKeep(keep.id)" title="Delete Keep">
            <i class="mdi mdi-close"></i>
        </button>
    </div>
    <div @click="setActiveKeep()" role="button" data-bs-toggle="modal" data-bs-target="#keepModal" class="keep-card" title="Open Keep">
        <img :src="keep.img" alt="Keep" class="keep-img">
        <div class="marko-one text-text container-fluid">
            <div class="row">
                <div class="keep-name col-6">
                    {{ keep.name }}
                </div>
            </div>
        </div>
    </div>
    <div v-if="account?.id != keep.creatorId" class="col-6">
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
            <img :title="keep.creator.name + ' Profile Page'" :src="keep.creator.picture" :alt="keep.name" class="profile-pic">
        </router-link>
    </div>
    <div v-else class="col-6">
        <router-link :to="{ name: 'Account' }">
            <img title="Your Account Page" :src="keep.creator.picture" :alt="keep.name" class="profile-pic">
        </router-link>
    </div>
</template>


<style lang="scss" scoped>
.keep-img {
    width: 100%;
    object-fit: cover;
    object-position: center;
    border-radius: 10px;
    box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
    background: linear-gradient(to bottom, rgba(0, 0, 0, 0) 50%, rgba(0, 0, 0, 0.7) 100%)
}


@media (min-width: 768px) {
    .keep-name {
        font-size: 36px;
        position: absolute;
        left: 0%;
        top: calc(100% - 65px);
        color: #F9F6FA;
        text-shadow: 2px 2px 2px black;
        width: 100%;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        width: 100%;
        padding-right: 2em;
        background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 0.9) 100%);
        border-radius: 10px;
        padding-bottom: 3%;
        
    }
}

@media (max-width: 768px) {
    .keep-name {
        width: 100%;
        font-size: 16px;
        position: absolute;
        left: 0%;
        top: calc(100% - 30px);
        color: #F9F6FA;
        text-shadow: 2px 2px 2px black;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 0.9) 100%);
        border-radius: 10px;
        padding-bottom: 4%;

    }
}

@media (max-width: 768px) {
    .profile-pic {
        display: none;
    }
}

@media (min-width: 768px) {
    .profile-pic {
        position: absolute;
        left: 85%;
        top: calc(100% - 60px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        height: 3em;
        border: 2px solid #F9F6FA;
        object-fit: cover;
    }
}

.keep-card {
    box-shadow: 5px 5px -3px rgba(0, 0, 0, 0.329);

}

@media (min-width: 768px) {
    button {
        position: absolute;
        right: calc(0% - 3%);
        top: calc(0% - 15px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        color: #F9F6FA;
        background-color: rgb(182, 0, 0) !important
    }
}

@media (max-width: 768px) {
    button {
        position: absolute;
        right: calc(0% - 12px);
        top: calc(0% - 15px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        color: #F9F6FA;
        background-color: rgb(182, 0, 0) !important
    }
}
</style>