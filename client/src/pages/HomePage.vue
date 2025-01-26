<script setup>
import { AppState } from '@/AppState';
import KeepCard from '@/components/KeepCard.vue';
import { keepsService } from '@/services/KeepsService';
import Pop from '@/utils/Pop';
import { computed, onMounted } from 'vue';

const keeps = computed(() => AppState.keeps)


onMounted(() => {
  getAllKeeps()
})

async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.meow(error);
  }
}




</script>

<template>
  <div class="container-fluid">
    <div class="masonry-container p-5">
      <div v-for="keep in keeps" :key="keep.id" class="mb-3 masonry-object">
        <KeepCard :keep="keep"/>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">

@media(min-width: 768px){

  .masonry-container {
    columns: 400px;
    column-gap: 2rem;
    row-gap: 2rem;
    width: 100%;
    
    
    .masonry-object {
      break-inside: avoid;
      display: inline-block;
      position: relative;
  
    }
  }
}
@media(max-width: 768px){

  .masonry-container {
    columns: 150px;
    width: 100%;
    
    
    .masonry-object {
      break-inside: avoid;
      display: inline-block;
      position: relative;
    }
  }
}


</style>
