<script setup>
import { AppState } from '@/AppState';
import VaultKeepKeepCard from '@/components/VaultKeepKeepCard.vue';
import { vaultsService } from '@/services/VaultsService';
import Pop from '@/utils/Pop';
import { computed, watch } from 'vue';
import { useRoute, useRouter } from 'vue-router';



const vault = computed(() => AppState.activeVault)
const vaultKeeps = computed(() => AppState.vaultKeeps)
const account = computed(() => AppState.account)


const route = useRoute()

const router = useRouter()

watch(route, () => {
    getVaultById()
    getVaultKeepsInVault()
}, { immediate: true })

async function getVaultById() {
    try {
        const vaultId = route.params.vaultId
        await vaultsService.getVaultById(vaultId)

    }
    catch (error) {
        router.push({ name: 'Home' })
        Pop.error(error);
    }
}

async function getVaultKeepsInVault() {
    try {
        const vaultId = route.params.vaultId
        await vaultsService.getVaultKeepsInVault(vaultId)
        
    }
    catch (error) {
        Pop.error(error);
    }
}

async function deleteVault(vaultId) {
    try {
        const confirm = await Pop.confirm("Are you sure you want to delete this vault?")
        if (!confirm) return
        await vaultsService.deleteVault(vaultId)
        router.push({name: 'Account'})
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <div v-if="vault">
        <div class="container">
            <div class="background-wrapper">
                <section class="heroImg row justify-content-center ps-3 pb-3 text-center"
                    :style="{ backgroundImage: `linear-gradient(to bottom, rgba(0, 0, 0, 0) 35%, rgba(0, 0, 0, 0.7) 100%), url(${vault.img})` }">
                    <div v-if="vault.creatorId == account?.id" class="text-end pe-0">
                        <button @click="deleteVault(vault.id)" title="Delete Vault" class="delete-button"><i class="mdi mdi-trash-can"></i></button>
                    </div>
                    <div class="align-self-end pe-3 ps-0">
                        <div class="quando-regular vault-name-top fs-1">
                            {{ vault.name }}
                        </div>
                        <router-link v-if="vault.creatorId != account?.id" :to="{ name: 'Profile', params: { profileId: vault.creatorId } }" title="Profile Page">
                            <div class="quando-regular vault-name">
                                by {{ vault.creator.name }}
                            </div>
                        </router-link>
                        <router-link v-if="vault.creatorId == account?.id" :to="{ name: 'Account' }" title="Your Account Page">
                            <div class="quando-regular vault-name">
                                by {{ vault.creator.name }}
                            </div>
                        </router-link>
                    </div>
                </section>
            </div>
            <section class="row text-center mb-md-3 mb-5">
                <div class="mb-md-4 mb-2">
                    <span v-if="vaultKeeps.length == 1" class="rounded rounded-pill bg-secondary p-3 oxygen-bold">{{
                        vaultKeeps.length }} Keep</span>
                    <span v-else class="rounded rounded-pill bg-secondary p-3 oxygen-bold">{{ vaultKeeps.length }}
                        Keeps
                    </span>
                </div>
            </section>
            <section class="row mb-2">
                <div class="masonry-container">
                    <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id" class="mb-4 masonry-object">
                        <VaultKeepKeepCard :vaultKeep="vaultKeep" />
                    </div>
                </div>
            </section>
        </div>
    </div>
    <div v-else class="container">
        <div class="row">
            <div class="col-12">
                <h2 class="text-center">Loading... <i class="mdi mdi-loading mdi-spin"></i></h2>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
@media(min-width: 768px) {

    .background-wrapper {
        padding: 20px 350px;
        margin: 20px 0;
        position: relative;
    }
}

@media(max-width: 768px) {

    .background-wrapper {
        padding: 20px 100px;
        margin: 20px 0;
    }
}

@media(min-width: 768px) {

    .delete-button {
        position: absolute;
        right: calc(0% + 327px);
        top: calc(0% + 8px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        background-color: rgb(182, 0, 0) !important;
        color: #F9F6FA;
    }
}

@media(max-width: 768px) {

    .delete-button {
        aspect-ratio: 1/1;
        border-radius: 50%;
        background-color: rgb(182, 0, 0) !important;
        color: #F9F6FA;
    }
}

.heroImg {
    background-size: cover;
    background-position: center;
    border-radius: 10px;
    box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
    min-height: 20dvh;
}

@media(min-width: 768px) {

    .vault-name-top {
        color: #F9F6FA;
        text-shadow: 3px 3px 5px black;
        font-size: 23.59px;
    }
}

@media(max-width: 768px) {

    .vault-name-top {
        color: #F9F6FA;
        text-shadow: 3px 3px 5px black;
        font-size: 16px;
    }
}
@media(min-width: 768px) {

    .vault-name {
        color: #F9F6FA;
        text-shadow: 3px 3px 5px black;
        font-size: 23.59px;
    }
}

@media(max-width: 768px) {

    .vault-name {
        color: #F9F6FA;
        text-shadow: 3px 3px 5px black;
        font-size: 16px;
    }
}

.vault-name:hover{
    text-decoration: underline;
}

@media(min-width: 768px) {

    .masonry-container {
        columns: 235px;
        column-gap: 2rem;
        row-gap: 2rem;
        width: 100%;


        .masonry-object {
            break-inside: avoid;
            display: inline-block;
            position: relative;
        }
    }
}

@media(max-width: 768px) {

    .masonry-container {
        columns: 150px;
        column-gap: 2rem;
        width: 100%;


        .masonry-object {
            break-inside: avoid;
            display: inline-block;
            position: relative;
        }
    }
}
</style>