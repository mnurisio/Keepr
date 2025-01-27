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
        <button @click="DeleteKeep(keep.id)" title="Delete Keep" class="btn btn-danger">
            <i class="mdi mdi-close"></i>
        </button>
    </div>
    <div @click="setActiveKeep()" role="button" data-bs-toggle="modal" data-bs-target="#keepModal" class="keep-card">
        <img :src="keep.img" :alt="keep.name" class="keep-img">
        <div class="marko-one text-text">
            <div class="row">
                <div class="keep-name col-6">
                    {{ keep.name }}
                </div>
            </div>
        </div>
    </div>
    <div v-if="account?.id != keep.creatorId" class="col-6">
        <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
            <img :src="keep.creator.picture" :alt="keep.name" class="profile-pic">
        </router-link>
    </div>
    <div v-else class="col-6">
        <router-link :to="{ name: 'Account' }">
            <img :src="keep.creator.picture" :alt="keep.name" class="profile-pic">
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
        font-size: 23.59px;
        position: absolute;
        left: 5%;
        top: calc(100% - 50px);
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
        left: 0%;
        top: calc(100% - 30px);
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;

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
    }
}

.keep-card {
    box-shadow: 5px 5px -3px rgba(0, 0, 0, 0.329);

}

@media (min-width: 768px) {
    button {
        position: absolute;
        left: 94%;
        top: calc(0% - 15px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        background-color: rgb(182, 0, 0) !important
    }
}

@media (max-width: 768px) {
    button {
        position: absolute;
        left: 138px;
        top: calc(0% - 10px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        background-color: rgb(182, 0, 0) !important
    }
}
</style>