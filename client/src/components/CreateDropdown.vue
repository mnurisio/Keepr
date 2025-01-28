<script setup>

</script>


<template>
    <div class="dropdown">
        <button class="btn btn-page dropdown-toggle px-4 py-3 fs-5 ms-2" type="button" data-bs-toggle="dropdown" aria-expanded="false">
            <b>Create</b>
        </button>
        <ul class="dropdown-menu oxygen-bold p-2 bg-secondary">
            <li class="list-border pb-1">
                <button role="button" data-bs-toggle="modal" data-bs-target="#createKeepModal" class="dropdown-item"
                    type="button">Create Keep</button>
            </li>
            <li class="pt-1">
                <button role="button" data-bs-toggle="modal" data-bs-target="#createVaultModal" class="dropdown-item"
                    type="button">Create Vault</button>
            </li>
        </ul>
    </div>

</template>


<style lang="scss" scoped>
.list-border {
    border-bottom: 1px solid black;
    border-width: 25%;
}

.dropdown {
    border-radius: 10px;
}

.dropdown-menu {
    border: 1px solid black;
}

.dropdown-item:hover {
    background-color: transparent;
    font-weight: 700;
}


</style>