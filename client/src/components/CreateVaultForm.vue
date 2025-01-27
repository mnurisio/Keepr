<script setup>
import { vaultsService } from '@/services/VaultsService';
import Pop from '@/utils/Pop';
import { Modal } from 'bootstrap';
import { ref } from 'vue';



const editableVaultData = ref({
    name: '',
    img: '',
    isPrivate: false,
})

async function createVault() {
    try {
        await vaultsService.createVault(editableVaultData.value)
        editableVaultData.value = {
            name: '',
            img: '',
            isPrivate: false
        }
        Modal.getInstance('#createVaultModal').hide
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <form @submit.prevent="createVault()">
        <div class="form-floating mb-3">
            <input v-model="editableVaultData.name" type="text" class="form-control" id="name" placeholder="Title"
                required minlength="3" maxlength="15">
            <label for="name">Title...</label>
        </div>
        <div class="form-floating mb-3">
            <input v-model="editableVaultData.img" type="url" class="form-control" id="img" placeholder="Image URL..."
                required maxlength="1000">
            <label for="img">Image URL...</label>
        </div>
        <div class="text-end">Private vaults can only be seen by you</div>
        <div class="row justify-content-end">
            <div class="form-check mb-3 col-md-6 text-end align-self-center">
                <input v-model="editableVaultData.isPrivate" type="checkbox" class="form-check-input fs-4" id="isPrivate">
                <label class="form-check-label fs-4" for="isPrivate">Make Vault Private?</label>
            </div>
        </div>
        <div class="text-end">
            <button type="submit" class="btn btn-danger">Create</button>
        </div>
    </form>
</template>


<style lang="scss" scoped></style>