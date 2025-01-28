<script setup>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import CreateDropdown from './CreateDropdown.vue';
import ModalWrapper from './ModalWrapper.vue';
import CreateKeepForm from './CreateKeepForm.vue';
import CreateVaultForm from './CreateVaultForm.vue';
import { AppState } from '@/AppState.js';

const theme = ref(loadState('theme') || 'light')
const account = computed(() => AppState.account)

onMounted(() => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
})

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}

</script>

<template>
  <div class="navbar-border py-2">
    <nav class="navbar navbar-expand-sm navbar-dark bg-page px-5">
      <router-link class="navbar-brand d-flex m-0 p-0" :to="{ name: 'Home' }">
        <div class="d-flex align-items-center">
          <button class="btn btn-primary fw-bold px-4 py-3 fs-5" title="Home Page">Home</button>
        </div>
      </router-link>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse justify-content-between p-3" id="navbarText">
        <CreateDropdown v-if="account" />
        <div v-else></div>
        <!-- LOGIN COMPONENT HERE -->
        <Login />
      </div>
    </nav>
  </div>
  <ModalWrapper modalId="createKeepModal" modalTitle="Create New Keep">
    <CreateKeepForm />
  </ModalWrapper>
  <ModalWrapper modalId="createVaultModal" modalTitle="Create New Vault">
    <CreateVaultForm />
  </ModalWrapper>
</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.navbar-border {
  box-shadow: 0px 0px 3px rgba(0, 0, 0, 0.425);
  ;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
