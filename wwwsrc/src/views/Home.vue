<template>
  <div class="home">
    <h1>The Keepr</h1>
    <div class="row">
      <div class="col">
        <button class="btn btn-warning" @click="logout">Logout</button>
        <button
          class="btn btn-secondary"
          @click="buttonkeep=!buttonkeep"
          :disabled="buttonkeep"
        >Vault</button>
      </div>
      <div class="col-6">
        <button
          class="btn btn-secondary"
          @click="buttonkeep=!buttonkeep"
          :disabled="!buttonkeep"
        >Keep</button>
      </div>
    </div>
    <div>
      <create-keep-form v-if="!buttonkeep"></create-keep-form>
      <create-vault-form v-if="buttonkeep"></create-vault-form>
    </div>
    <div>
      <all-keeps v-if="!buttonkeep" :keeps="userKeeps"></all-keeps>
      <user-vaults v-if="buttonkeep" :vaults="vaults"></user-vaults>
    </div>
  </div>
</template>

<script>
import CreateVaultForm from "@/components/CreateVaultForm.vue";
import CreateKeepForm from "@/components/CreateKeepForm.vue";
import UserVaults from "@/components/UserVaults.vue";
import AllKeeps from "@/components/AllKeeps.vue";
export default {
  name: "home",
  data() {
    return {
      buttonkeep: false
    };
  },
  components: {
    CreateVaultForm,
    CreateKeepForm,
    AllKeeps,
    UserVaults
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");

    //blocks users not logged in
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    }
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  }
};
</script>