<script setup>
import { Vault } from '@/models/Vault';



defineProps({
    vault: {type: Vault, required: true}
})

</script>


<template>
    <div v-if="vault.isPrivate == false" title="Open Vault">
        <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}">
            <div :style="{backgroundImage: `linear-gradient(to bottom, rgba(0, 0, 0, 0) 50%, rgba(0, 0, 0, 0.7) 100%), url(${vault.img})`}" class="vault-image d-flex align-items-end p-3">
                <div class="row w-100 vault-row">
                    <span class="vault-name marko-one">{{ vault.name }}</span>
                </div>
            </div>
        </router-link>
    </div>
    <div v-else>
        <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}" title="Open Vault">
            <div :style="{backgroundImage: `linear-gradient(to bottom, rgba(0, 0, 0, 0.5) 100%, rgba(0, 0, 0, 1.0) 100%), url(${vault.img})`}" class="vault-image d-flex align-items-end p-3">
                <div class="row w-100 vault-row">
                    <span class="vault-name marko-one">{{vault.name}} <i class="mdi mdi-lock"></i></span>
                </div>
            </div>
        </router-link>
    </div>
</template>


<style lang="scss" scoped>
.vault-image{
    background-size: cover;
    background-position: center;
    border-radius: 10px;
    box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
    width: 100%;
    min-height: 15dvh;
}

.vault-name{
    color: #F9F6FA;
    text-shadow: 3px 2px 2px black;
    font-size: 23.59px;
}


</style>