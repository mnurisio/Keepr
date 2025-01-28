<script setup>
import { AppState } from '@/AppState';
import { Modal } from 'bootstrap';
import { computed } from 'vue';
import MyVaultDropdown from './MyVaultDropdown.vue';




const keep = computed(() => AppState.activeKeep)
const account = computed(() => AppState.account)


</script>


<template>
    <div class="container-fluid modal fade" id="keepModal" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div v-if="keep" class="modal-content container-fluid">
                <div class="row">
                    <div class="col-md-6 p-0">
                        <img class="img-fluid w-100 h-100" :src="keep.img" :alt="keep.name">
                    </div>
                    <div class="col-md-6 p-0 modal-info">
                        <div class="row justify-content-center text-center">
                            <div class="col-4 p-1">
                                <span class="m-2"><i class="mdi mdi-eye-outline"></i> {{ keep.views }}</span>
                                <span class="m-2"><i class="mdi mdi-pin-outline"></i> {{ keep.kept }}</span>
                            </div>
                        </div>
                        <div class="p-5">
                            <div class="text-center">
                                <h1>{{ keep.name }}</h1>
                            </div>
                            <div class="text-start">
                                <p>{{ keep.description }}</p>
                            </div>
                        </div>
                        <div v-if="account" class="container-fluid">
                            <div class="row justify-content-between">
                                <div class="col-md-5 col-8 ms-md-4 mb-md-3 mb-4 px-md-0 ps-md-0 ps-2">
                                    <div class="d-flex justify-content-start">
                                        <MyVaultDropdown />
                                        <button class="ms-md-2 mb-md-2 mb-2 ms-1 btn btn-success save-button oxygen-bold" form="vaultKeep-submit" title="Save to your selected Vault">
                                            Save
                                        </button>
                                    </div>
                                </div>
                                <div class="col-md-5 col-4 me-md-3 px-0 oxygen-bold profile-div">
                                    <div v-if="account?.id != keep.creatorId">
                                        <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }" :title="keep.creator.name + ' Profile Page'">
                                            <div class="d-flex justify-content-center text-center">
                                                <img :src="keep.creator.picture" :alt="keep.creator.name"
                                                    class="profile-pic me-2">
                                                <span class="profile-name-button align-self-center text-start"
                                                    role="button" @click="Modal.getInstance('#keepModal').hide()">
                                                    {{ keep.creator.name }}
                                                </span>
                                            </div>
                                        </router-link>
                                    </div>
                                    <div v-else>
                                        <router-link :to="{ name: 'Account' }" title="Your Account Page">
                                            <div class="d-flex justify-content-center text-center">
                                                <img :src="keep.creator.picture" :alt="keep.creator.name"
                                                    class="profile-pic me-2">
                                                <span class="profile-name-button align-self-center text-start"
                                                    role="button" @click="Modal.getInstance('#keepModal').hide()">
                                                    {{ keep.creator.name }}
                                                </span>
                                            </div>
                                        </router-link>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div v-else>
                            <div class="col-12 oxygen-bold profile-div mb-5">
                                <div>
                                    <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
                                        <div class="d-flex justify-content-center text-center">
                                            <img :src="keep.creator.picture" :alt="keep.creator.name"
                                                class="profile-pic">
                                            <span class="profile-name-button align-self-center ms-3" role="button"
                                                @click="Modal.getInstance('#keepModal').hide()">
                                                {{ keep.creator.name }}
                                            </span>
                                        </div>
                                    </router-link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
img {
    object-fit: cover;
    object-position: center;
}

.save-button {
    border-radius: 10px;
    color: #F9F6FA;
}

.modal-content {
    overflow: hidden;
}

.modal-info {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}

.profile-pic {
    aspect-ratio: 1/1;
    border-radius: 50%;
    height: 2.5em;
}

.profile-name-button:hover {
    text-decoration: underline;
}

.profile-name-button {
    color: black;
}

.profile-div {
    overflow: hidden;
}
</style>