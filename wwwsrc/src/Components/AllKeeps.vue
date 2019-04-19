<template>
  <div class="allKeeps">
    <h1>Keeps</h1>
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id">
        <div class="col col-md-4">
          <div class="card" style="width: 18rem;">
            <img :src="keep.img" class="card-img-top img-fluid" alt>
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <div class="d-flex justify-content-around mb-1">
                <button class="btn btn-sm btn-dark text-light">View</button>
                <button class="btn btn-sm btn-dark text-light">Share</button>
                <div class="dropdown">
                  <button
                    class="btn btn-sm btn-dark text-light dropdown-toggle"
                    type="button"
                    id="dropdownMenuButton"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                  >Keep</button>
                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <span
                      @click="createVaultKeep(keep.id, vault.id)"
                      class="dropdown-item"
                      v-for="vault in vaults"
                      :key="(vault.id)"
                    >{{vault.name}}</span>
                  </div>
                </div>
              </div>
              <button @click="deleteKeep(keep.id)" class="btn btn-primary btn-sm">Delete Keep</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "all-keeps",
  data() {
    return {};
  },
  props: ["keeps", "vaults"],
  methods: {
    deleteKeep(id) {
      this.$store.dispatch("deleteKeep", id);
    },
    createVaultKeep(keepId, vaultId) {
      let data = {
        keepId: keepId,
        vaultId: vaultId
      };
      this.$store.dispatch("createVaultKeep", data);
    }
  },
  computed: {}
};
</script>


 