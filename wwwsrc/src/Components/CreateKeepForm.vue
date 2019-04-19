<template>
  <div class="keepform">
    <h3 class="text-center">Create Keep Here</h3>
    <form @submit.prevent="createKeep" class="Form-newkeep form-group">
      <input class="form-control" type="text" v-model="newKeep.name" placeholder="Name">
      <input
        class="form-control"
        type="text"
        v-model="newKeep.description"
        placeholder="Description"
      >
      <input class="form-control" type="text" v-model="newKeep.img" placeholder="Image">
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
  methods: {},
  components: {}
};
</script>

 
<style scoped>
</style>