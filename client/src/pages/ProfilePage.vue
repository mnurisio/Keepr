<script setup>
import { AppState } from '@/AppState';
import VaultCard from '@/components/VaultCard.vue';
import { keepsService } from '@/services/KeepsService';
import { profilesService } from '@/services/ProfilesService';
import { vaultsService } from '@/services/VaultsService';
import Pop from '@/utils/Pop';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';
import ProfileKeepCard from '@/components/ProfileKeepCard.vue';


const profile = computed(() => AppState.activeProfile)
const keeps = computed(() => AppState.activeProfileKeeps)
const vaults = computed(() => AppState.profileVaults)
const profileVaults = computed(() => vaults.value.filter(vault => vault.creatorId == profile.value?.id))

const route = useRoute()

watch(route, () => {
    getProfileById()
    getProfileVaults()
    getProfileKeeps()
}, { immediate: true })



async function getProfileById() {
    try {
        const profileId = route.params.profileId
        await profilesService.getProfileById(profileId)
    }
    catch (error) {
        Pop.error(error);
    }
}

async function getProfileVaults() {
    try {
        const profileId = route.params.profileId
        await vaultsService.getProfileVaults(profileId)

    }
    catch (error) {
        Pop.error(error);
    }
}

async function getProfileKeeps() {
    try {
        const profileId = route.params.profileId
        await keepsService.getProfileKeeps(profileId)

    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <div v-if="profile" class="container">
        <div class="background-wrapper">
            <section class="row heroImg justify-content-center align-items-center my-md-3 mt-md-0 mt-3 "
                :style="{ backgroundImage: `url(${profile?.coverImg})` }">
                <div class="col-md-5 account-info">
                    <div class="d-flex justify-content-center align-items-center">
                        <img class="profilePicture" :src="profile.picture" :alt="profile.name">
                    </div>
                    <div class="text-center fs-1 oxygen-bold">{{ profile.name }}</div>
                    <div class="text-center oxygen-bold">
                        {{ vaults.length }} Vaults | {{ keeps.length }} Keeps
                    </div>
                </div>
            </section>
        </div>
        <section>
            <div class="oxygen-bold fs-1 mb-2 vault-logo">
                Vaults
            </div>
            <div class="row mb-2">
                <div v-for="vault in vaults" :key="vault.id" class=" mb-3 col-md-3">
                    <VaultCard :vault="vault" />
                </div>
            </div>
            <div class="oxygen-bold fs-1 mb-2">
                Keeps
            </div>
            <div class="row mb-2">
                <div class="masonry-container">
                    <div v-for="keep in keeps" :key="keep.id" class="mb-3 masonry-object">
                        <ProfileKeepCard :keep="keep" />
                    </div>
                </div>
            </div>
        </section>
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
.profilePicture {
    aspect-ratio: 1/1;
    border-radius: 50%;
    border: 3px solid var(--bs-light);
    height: 10em;
    object-fit: cover;
}

@media(min-width: 768px) {

    .heroImg {
        background-size: cover;
        background-position: center;
        height: 20em;
        position: relative;
        border-radius: 10px;
    }
}

@media(max-width: 768px) {

    .heroImg {
        background-size: cover;
        background-position: center;
        height: 20em;
        position: relative;
        border-radius: 10px;
    }
}

@media(min-width: 768px) {
    .account-info {
        position: absolute;
        top: calc(0% + 220px);
    }
}

@media(max-width: 768px) {
    .account-info {
        position: absolute;
        top: calc(0% + 230px);
    }
}

@media(min-width: 768px) {
    .vault-logo {
        margin-top: 125px;
    }
}

@media(max-width: 768px) {
    .vault-logo {
        margin-top: 125px;
    }
}

@media(min-width: 768px) {
    .background-wrapper {
        padding: 30px 300px 0px;
    }
}

@media(max-width: 768px) {
    .background-wrapper {
        padding: 10px 30px;
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