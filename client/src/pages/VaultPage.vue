<script setup>
import { AppState } from '@/AppState';
import { vaultKeepService } from '@/services/VaultKeepService';
import { vaultsService } from '@/services/VaultsService';
import Pop from '@/utils/Pop';
import { AxiosError } from 'axios';
import { computed, watch } from 'vue';
import { useRoute, useRouter } from 'vue-router';



const vault = computed(() => AppState.activeVault)


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
            </div>
            <section class="row text-center">
                <div>
                    <span class="rounded rounded-pill bg-secondary p-3 oxygen-bold">keeps</span>
                </div>
            </section>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.background-wrapper {
    padding: 20px 350px;
    margin: 20px 0;
}

.heroImg {
    background-size: cover;
    background-position: center;
    border-radius: 10px;
    box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
    min-height: 20dvh;
}

.vault-name {
    color: #F9F6FA;
    text-shadow: 3px 3px 5px black;
    font-size: 23.59px;
}
</style>