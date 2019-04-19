<template>
  <div class="user-vaults">
    <h1>Vaults</h1>
    <div class="row">
      <div v-for="vault in vaults" :key="vault.id">
        <div class="col col-md-4">
          <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">{{vault.name}}</h5>
              <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
              <a href="#" class="btn btn-primary">View This</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "user-vaults",
  data() {
    return {};
  },
  props: ["vaults"],
  computed: {},
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>