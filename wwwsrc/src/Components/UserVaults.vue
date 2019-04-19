<template>
  <div class="user-vaults">
    <h1>Vaults</h1>
    <div class="row">
      <div v-for="vault in vaults" :key="vault.id">
        <div class="col col-md-4">
          <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">{{vault.name}}</h5>
              <button @click="deleteVault(vault.id)" class="btn btn-danger">Delete This</button>
              <button @click="viewVault(vault.id)" class="btn btn-primary">View Vault</button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <all-keeps :vaults="vaults" :keeps="vaultKeeps"></all-keeps>
  </div>
</template>


<script>
import AllKeeps from "@/components/AllKeeps.vue";
export default {
  name: "user-vaults",
  data() {
    return {};
  },
  props: ["vaults"],
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    deleteVault(id) {
      this.$store.dispatch("deleteVault", id);
    },
    viewVault(vaultId) {
      this.$store.dispatch("getVaultKeeps", vaultId);
    }
  },
  components: {
    AllKeeps
  }
};
</script>


<style scoped>
</style>