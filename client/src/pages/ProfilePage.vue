<script setup>
import { AppState } from '@/AppState';
import { profilesService } from '@/services/ProfilesService';
import { vaultsService } from '@/services/VaultsService';
import Pop from '@/utils/Pop';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';


const profile = computed(() => AppState.activeProfile)
const keeps = computed(() => AppState.activeProfileKeeps)
const vaults = computed(() => AppState.vaults)
const profileVaults = computed(() => vaults.value.filter(vault => vault.creatorId == profile.value?.id))

const route = useRoute()

watch(route, () => {
    getProfileById()
    getProfileVaults()
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

</script>


<template>
    <div v-if="profile" class="container">
        <section class="row heroImg justify-content-center align-items-center p-3"
            :style="{ backgroundImage: `url(${profile.coverImg})` }">
            <div class="col-5">
                <div class="d-flex justify-content-center align-items-center">
                    <img class="profilePicture" :src="profile.picture" :alt="profile.name">
                </div>
                <div class="text-center fs-1 oxygen-bold">{{ profile.name }}</div>
                <div>
                    {{ profileVaults.length}} Vaults
                </div>
            </div>
        </section>
    </div>
</template>


<style lang="scss" scoped>
.profilePicture {
    aspect-ratio: 1/1;
    border-radius: 50%;
    border: 3px solid var(--bs-light);
    height: 10em;
}

.heroImg {
    background-size: cover;
    height: 20em
}
</style>