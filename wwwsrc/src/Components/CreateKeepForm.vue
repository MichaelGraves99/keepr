<template>
  <div class="keepform">
    <h3 class="text-center">Create Keep Here</h3>
    <form @submit.prevent="createKeep" class="Form-newkeep form-group">
      <input class="form-control" type="text" required v-model="newKeep.name" placeholder="Name">
      <input
        class="form-control"
        type="text"
        rewquired
        v-model="newKeep.description"
        placeholder="Description"
      >
      <input class="form-control" type="url" v-model="newKeep.img" placeholder="Image Url">
      <button type="submit" class="form-control btn btn-success mb-3 shadow">Create Keep</button>
    </form>
  </div>
</template>


<script>
export default {
  name: "keepform",
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        views: 0,
        shares: 0,
        keeps: 0
      }
    };
  },
  computed: {},
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      this.newKeep = {
        name: "",
        description: "",
        img: "",
        views: 0,
        shares: 0,
        keeps: 0
      };
    }
  },
  components: {}
};
</script>

 
<style scoped>
</style>