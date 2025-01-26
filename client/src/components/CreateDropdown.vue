<script setup>

</script>


<template>
    <div class="dropdown">
        <button class="btn btn-page dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
            <b>Create</b>
        </button>
        <ul class="dropdown-menu">
            <li>
                <button data-bs-toggle="modal" data-bs-target="#createKeepModal" class="dropdown-item" type="button">Create Keep</button>
            </li>
            <li>
                <button class="dropdown-item" type="button">Create Vault</button>
            </li>
        </ul>
    </div>
    <ModalWrapper modalId="createKeepModal" modal-title="Create New Keep">
        <CreateKeepForm />
    </ModalWrapper>
</template>


<style lang="scss" scoped></style>