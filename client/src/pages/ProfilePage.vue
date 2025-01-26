<script setup>
import { AppState } from '@/AppState';
import { profilesService } from '@/services/ProfilesService';
import Pop from '@/utils/Pop';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';


const profile = computed(() => AppState.activeProfile)
const keeps = computed(() => AppState.activeProfileKeeps)

const route = useRoute()

watch(route, () => {
    getProfileById()
}, {immediate: true})

async function getProfileById() {
    try {
        const profileId = route.params.profileId
        await profilesService.getProfileById(profileId)
    }
    catch (error) {
        Pop.error(error);
    }
}
</script>


<template>
    <div v-if="profile" class="container">
        <section>{{ profile.name }}</section>
    </div>
</template>


<style lang="scss" scoped></style>