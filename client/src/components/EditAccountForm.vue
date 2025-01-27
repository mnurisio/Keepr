<script setup>
import { AppState } from '@/AppState';
import { accountService } from '@/services/AccountService';
import Pop from '@/utils/Pop';
import { Modal } from 'bootstrap';
import { computed, onMounted, ref } from 'vue';


const account = computed(() => AppState.account)



const editableAccountData = ref({
    name: '',
    picture: '',
    coverImg: ''
})


async function editAccountInfo() {
    try {
        await accountService.editAccountInfo(editableAccountData.value)
        Modal.getInstance('#accountEditModal').hide()
    }
    catch (error) {
        Pop.error(error);
    }
}
</script>


<template>
    <form @submit.prevent="editAccountInfo()">
        <div class="form-floating mb-3">
            <input v-model="editableAccountData.name" type="text" class="form-control" id="name" placeholder="Name"
                required>
            <label for="name">Name...</label>
        </div>
        <div class="form-floating mb-3">
            <input v-model="editableAccountData.picture" type="url" class="form-control" id="img" placeholder="Image URL..."
                required>
            <label for="img">Image URL...</label>
        </div>
        <div class="form-floating mb-3">
            <input v-model="editableAccountData.coverImg" type="url" class="form-control" id="coverImg" placeholder="Cover Image URL..."
                required>
            <label for="coverImg">Cover Image URL...</label>
        </div>
        <div class="text-end">
            <button type="submit" class="btn btn-danger">Submit</button>
        </div>
    </form>
</template>


<style lang="scss" scoped></style>