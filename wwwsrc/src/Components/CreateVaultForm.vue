<template>
  <div class="vaultform">
    <h3 class="text-center">Create Vault Here</h3>
    <form @submit.prevent="createVault" class="Form-newVault form-group">
      <input class="form-control" type="text" v-model="newVault.name" placeholder="Name">
      <input
        class="form-control"
        type="text"
        v-model="newVault.description"
        placeholder="Description"
      >
      <button type="submit" class="form-control btn btn-success mb-3 shadow">Create Vault</button>
    </form>
  </div>
</template>


<script>
export default {
  name: "vaultform",
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  computed: {},
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>