<script setup>
import { keepsService } from '@/services/KeepsService';
import Pop from '@/utils/Pop';
import { Modal } from 'bootstrap';
import { ref } from 'vue';





const editableKeepData = ref({
    name: '',
    img: '',
    description: ''
})

async function createKeep() {
    try {
        await keepsService.createKeep(editableKeepData.value)
        editableKeepData.value = {
            name: '',
            img: '',
            description: ''
        }
        Modal.getInstance('#createKeepModal').hide
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>


<template>
    <form @submit.prevent="createKeep()">
        <div class="form-floating mb-3">
            <input v-model="editableKeepData.name" type="text" class="form-control" id="name" placeholder="Name" required minlength="3" maxlength="15">
            <label for="name">Name...</label>
        </div>
        <div class="form-floating mb-3">
            <input v-model="editableKeepData.img" type="url" class="form-control" id="img" placeholder="Image URL..." required maxlength="1000">
            <label for="img">Image URL...</label>
        </div>
        <div class="form-floating mb-3">
            <input v-model="editableKeepData.description" type="textarea" class="form-control" id="description" placeholder="Keep Description..." minlength="3" maxlength="250">
            <label for="description">Keep Description...</label>
        </div>
        <div class="text-end">
            <button type="submit" class="btn btn-danger">Create</button>
        </div>
    </form>
</template>


<style lang="scss" scoped></style>