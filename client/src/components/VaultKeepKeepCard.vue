<script setup>
import { AppState } from '@/AppState'
import { VaultKeep } from '@/models/VaultKeep'
import { keepsService } from '@/services/KeepsService'
import { vaultKeepService } from '@/services/VaultKeepService'
import Pop from '@/utils/Pop'
import { computed } from 'vue'



const account = computed(() => AppState.account)
const activeKeep = computed(() => AppState.activeKeep)

const props = defineProps({
    vaultKeep: { type: VaultKeep, required: true }
})



async function setActiveKeep() {
    try {
        keepsService.setActiveKeep(props.vaultKeep)
        activeKeep.value.views++
    }
    catch (error) {
        Pop.error(error);
    }

}


async function DeleteVaultKeep(vaultKeepId) {
    try {
        const confirm = await Pop.confirm("Are you sure you want to remove this keep from your vault?")
        if (!confirm) return
        await vaultKeepService.DeleteKeep(vaultKeepId)
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <div v-if="vaultKeep.creatorId == account?.id">
        <button @click="DeleteVaultKeep(vaultKeep.vaultKeepId)" title="Delete Keep" class="btn btn-danger">
            <i class="mdi mdi-close"></i>
        </button>
    </div>
    <div @click="setActiveKeep()" role="button" data-bs-toggle="modal" data-bs-target="#keepModal" class="keep-card">
        <img :src="vaultKeep.img" :alt="vaultKeep.name" class="keep-img">
        <div class="marko-one text-text">
            <div class="row">
                <div class="keep-name col-6">
                    {{ vaultKeep.name }}
                </div>
            </div>
        </div>
    </div>
    <div v-if="account?.id != vaultKeep.creatorId" class="col-6">
        <router-link :to="{ name: 'Profile', params: { profileId: vaultKeep.creatorId } }">
            <img :src="vaultKeep.creator.picture" :alt="vaultKeep.name" class="profile-pic">
        </router-link>
    </div>
    <div v-else class="col-6">
        <router-link :to="{ name: 'Account' }">
            <img :src="vaultKeep.creator.picture" :alt="vaultKeep.name" class="profile-pic">
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
        left: 80%;
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
        left: 92%;
        top: calc(0% - 15px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        background-color: rgb(182, 0, 0) !important
    }
}

@media (max-width: 768px) {
    button {
        position: absolute;
        left: 88%;
        top: calc(0% - 16px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        background-color: rgb(182, 0, 0) !important
    }
}
</style>
