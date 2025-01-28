<script setup>
import { AppState } from '@/AppState';
import { vaultKeepService } from '@/services/VaultKeepService';
import Pop from '@/utils/Pop';
import { Modal } from 'bootstrap';
import { computed, ref } from 'vue';



const vaults = computed(() => AppState.accountVaults)
const keep = computed(() => AppState.activeKeep)


const editableVaultKeepData = ref({
    vaultId: '',
    keepId: ''
})

async function createVaultKeep() {
    try {
        editableVaultKeepData.value.keepId = keep.value.id
        await vaultKeepService.createVaultKeep(editableVaultKeepData.value)
        keep.value.kept++
        Modal.getInstance('#keepModal').hide()
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <form @submit.prevent="createVaultKeep()" id="vaultKeep-submit" class="oxygen-regular mb-2">
        <select v-model="editableVaultKeepData.vaultId" id="vault" class="form-select text-uppercase submit-form" aria-label="Vault Name"
            required>
            <option class="text-center" selected value="" disabled>Vaults</option>
            <option v-for="vault in vaults" :key="vault.id" :value="vault.id" class="text-uppercase">
                {{ vault.name }}
            </option>
        </select>
    </form>
</template>


<style lang="scss" scoped>

.submit-form{
    appearance: none !important;
}
</style>