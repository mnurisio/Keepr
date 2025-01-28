<script setup>
import { AppState } from '@/AppState'
import { VaultKeep } from '@/models/VaultKeep'
import { keepsService } from '@/services/KeepsService'
import { vaultKeepService } from '@/services/VaultKeepService'
import Pop from '@/utils/Pop'
import { computed } from 'vue'



const account = computed(() => AppState.account)
const activeKeep = computed(() => AppState.activeKeep)
const vault = computed(() => AppState.activeVault)

const props = defineProps({
    vaultKeep: { type: VaultKeep, required: true }
})



async function setActiveKeep() {
    try {
        keepsService.setActiveKeep(props.vaultKeep)
        await keepsService.getKeepById(activeKeep.value.id)
        if (activeKeep.value.creatorId == account.value?.id) return
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
    <div v-if="vault.creatorId == account?.id">
        <button @click="DeleteVaultKeep(vaultKeep.vaultKeepId)" title="Remove Keep From Vault" class="px-2">
            <i class="mdi mdi-close"></i>
        </button>
    </div>
    <div @click="setActiveKeep()" role="button" data-bs-toggle="modal" data-bs-target="#keepModal" class="keep-card" title="Open Keep">
        <img :src="vaultKeep.img" alt="VaultKeep" class="keep-img">
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
            <img :title="vaultKeep.creator.name + ' Profile Page'" :src="vaultKeep.creator.picture" :alt="vaultKeep.name" class="profile-pic">
        </router-link>
    </div>
    <div v-else class="col-6">
        <router-link :to="{ name: 'Account' }">
            <img title="Your Account Page" :src="vaultKeep.creator.picture" :alt="vaultKeep.name" class="profile-pic">
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
        left: 0%;
        top: calc(100% - 40px);
        color: #F9F6FA;
        text-shadow: 2px 2px 2px black;
        width: 100%;
        background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 0.9) 100%);
        border-radius: 10px;
        padding-bottom: 3%;
        padding-left: 4%;
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
        top: calc(100% - 25px);
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 0.9) 100%);
        border-radius: 10px;
        padding-bottom: 1%;
        padding-left: 4%;

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
        top: calc(100% - 52px);
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
        right: calc(0% - 4%);
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
        right: calc(0% - 5%);
        top: calc(0% - 15px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        color: #F9F6FA;      
        background-color: rgb(182, 0, 0) !important
    }
}
</style>
