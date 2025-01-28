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
        const confirm = await Pop.confirm("Are you sure you want to delete this keep?")
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
                <section class="heroImg row justify-content-center p-3 text-center"
                    :style="{ backgroundImage: `linear-gradient(to bottom, rgba(0, 0, 0, 0) 50%, rgba(0, 0, 0, 0.7) 100%), url(${vault.img})` }">
                    <div class="align-self-end">
                        <div class="quando-regular vault-name fs-1">
                            {{ vault.name }}
                        </div>
                        <div class="quando-regular vault-name">
                            by {{ vault.creator.name }}
                        </div>
                    </div>
                </section>
                <div v-if="vault.creatorId == account?.id">
                    <button @click="deleteVault(vault.id)" class="delete-button"><i class="mdi mdi-trash-can"></i></button>
                </div>
            </div>
            <section class="row text-center mb-md-3 mb-5">
                <div>
                    <span v-if="vaultKeeps.length == 1" class="rounded rounded-pill bg-secondary p-3 oxygen-bold">{{
                        vaultKeeps.length }} Keep</span>
                    <span v-else class="rounded rounded-pill bg-secondary p-3 oxygen-bold">{{ vaultKeeps.length }}
                        Keeps</span>
                </div>
            </section>
            <section class="row mb-2">
                <div class="masonry-container">
                    <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id" class="mb-3 masonry-object">
                        <VaultKeepKeepCard :vaultKeep="vaultKeep" />
                    </div>
                </div>
            </section>
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
        left: 72.5%;
        top: calc(0% + 8px);
        aspect-ratio: 1/1;
        border-radius: 50%;
        background-color: rgb(182, 0, 0) !important;
        color: #F9F6FA;
    }
}

@media(max-width: 768px) {

    .delete-button {
        position: absolute;
        left: 74.5%;
        top: calc(0% + 90px);
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
        width: 100%;


        .masonry-object {
            break-inside: avoid;
            display: inline-block;
            position: relative;
        }
    }
}
</style>