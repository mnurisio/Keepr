<script setup>
import { AppState } from '@/AppState';
import { computed } from 'vue';




const keep = computed(() => AppState.activeKeep)


</script>


<template>
    <div class="container-fluid modal fade " id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel">
        <div class="modal-dialog modal-lg">
            <div v-if="keep" class="modal-content">
                <div class="row">
                    <div class="col-md-6">
                        <img class="img-fluid w-100 h-100" :src="keep.img" :alt="keep.name">
                    </div>
                    <div class="col-6">
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>