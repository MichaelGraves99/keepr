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
  name: "all-keeps",
  data() {
    return {};
  },
  props: ["keeps"],
  computed: {
    // keeps() {
    //   return this.$store.state.keeps;
    // }
  }
};
</script>


 