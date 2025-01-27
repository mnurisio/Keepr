<script setup>
import { AppState } from '@/AppState';
import { computed, ref } from 'vue';



const vaults = computed(()=> AppState.accountVaults)

const editableFormData = ref({
    vault: ''
})

</script>


<template>
<form id="vaultKeep-submit">
    <select v-model="editableFormData.vault" id="vault" class="form-select text-capitalize" aria-label="Vault Name" required>
        <option class="text-center" selected value="" disabled>Vaults</option>
        <option v-for="vault in vaults" :key="vault.id" :value="vault" class="text-capitalize">
            {{ vault.name }}
        </option>
    </select>
</form>
</template>


<style lang="scss" scoped>

</style>