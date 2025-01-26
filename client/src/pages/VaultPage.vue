<script setup>
import { AppState } from '@/AppState';
import { vaultsService } from '@/services/VaultsService';
import Pop from '@/utils/Pop';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';



const vault = computed(() => AppState.activeVault)


const route = useRoute()

watch(route, () => {
    getVaultById()
}, { immediate: true })

async function getVaultById() {
    try {
        const vaultId = route.params.vaultId
        await vaultsService.getVaultById(vaultId)
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <div v-if="vault">
        {{ vault.name }}
    </div>
</template>


<style lang="scss" scoped></style>