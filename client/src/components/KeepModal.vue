<script setup>
import { AppState } from '@/AppState';
import { Keep } from '@/models/Keep';
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
                        <div class="row">
                            <div class="col-md-4 ms-2">
                                <MyVaultDropdown />
                            </div>
                            <div class="col-md-3">
                                <button form="vaultKeep-submit">Save</button>
                            </div>
                            <div class="col-md-4 text-end">
                                <div v-if="account?.id != keep.creatorId">
                                    <img :src="keep.creator.picture" :alt="keep.creator.name" class="profile-pic me-2">
                                    <router-link :to="{name: 'Profile', params: {profileId: keep.creatorId}}" >
                                        <span class="profile-name-button" role="button" @click="Modal.getInstance('#keepModal').hide()">{{ keep.creator.name }}</span>
                                    </router-link>
                                </div>
                                <div v-else>
                                    <img :src="keep.creator.picture" :alt="keep.creator.name" class="profile-pic me-2">
                                    <router-link :to="{name: 'Account'}" >
                                        <span class="profile-name-button" role="button" @click="Modal.getInstance('#keepModal').hide()">{{ keep.creator.name }}</span>
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

.modal-content {
    overflow: hidden;
}

.modal-info {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}

.profile-pic{
    aspect-ratio: 1/1;
    border-radius: 50%;
    height:2.5em;
}

.profile-name-button:hover{
    text-decoration: underline;
}
.profile-name-button{
    color:black;
}
</style>