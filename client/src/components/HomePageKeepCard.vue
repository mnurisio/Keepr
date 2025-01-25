<script setup>
import { AppState } from '@/AppState';
import { Keep } from '@/models/Keep';
import { keepsService } from '@/services/KeepsService';
import { computed } from 'vue';



const account = computed(() => AppState.account)

const props = defineProps({
    keep: { type: Keep, required: true }
})


function setActiveKeep(){
  keepsService.setActiveKeep(props.keep)
}

</script>


<template>
    <div @click="setActiveKeep()">
        <img :src="keep.img" :alt="keep.name" class="keep-img">
        <div class="d-flex flex-column justify-content-between">
            <div class="col-6">
                <div v-if="keep.creatorId == account?.id">
                    <button title="Delete Keep" class="btn btn-danger"><i class="mdi mdi-close"></i></button>
                </div>
            </div>
            <div class="col-6">
                <div class="keep-name">
                    {{ keep.name }}
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.keep-img {
    width: 100%;
    background-size: cover;
    background-position: center;
    border-radius: 10px;
    box-shadow: 4px 8px 19px -3px rgba(0, 0, 0, 0.27);
}

.keep-name {
    position: absolute;
    left: 25px;
    top: 20px;
}

button {
    position: absolute;
    left: 184px;
    top: -20px;
    aspect-ratio: 1/1;
    border-radius: 50%;
}
</style>