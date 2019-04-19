import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    userKeeps: [],
    keeps: [],
    vaults: [],
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
    },
    setKeeps(state, data) {
      state.keeps = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data
    },


  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
        .catch(e => {
          console.log('Logout Failed')
        })
    },
    // Keeps
    createKeep({ commit, dispatch }, data) {
      api.post('keeps', data)
        .then(res => {
          // console.log(res.data);
          dispatch('getUserKeeps')
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          // console.log("Keeps success")
          commit('setKeeps', res.data)
        })
    },
    getUserKeeps({ commit, dispatch, state }) {
      api.get('keeps/user')
        .then(res => {
          // console.log("UserKeeps success")
          commit('setUserKeeps', res.data)
        }).catch(err => { console.log(err) })
    },
    deleteKeep({ commit, dispatch }, data) {
      api.delete('keeps/' + data)
        .then(res => {
          dispatch('getUserKeeps')
        })
    },
    // Vaults
    getVaults({ commit, dispatch, state }) {
      let userId = state.user.id
      api.get('vaults', userId)
        .then(res => {
          // console.log("Vaults success")
          commit('setVaults', res.data)
        })
    },
    createVault({ commit, dispatch }, data) {
      api.post('vaults', data)
        .then(res => {
          // console.log(res.data);
          dispatch('getVaults')
        })
    },
    deleteVault({ commit, dispatch }, data) {
      api.delete('vaults/' + data)
        .then(res => {
          dispatch('getVaults')
        })
    },
    createVaultKeep({ commit, dispatch }, data) {
      api.post('vaultKeeps', data)
        .then(res => {
          console.log(res.data)
        })
    },
    getVaultKeeps({ commit, dispatch }, vaultId) {
      api.get('vaultKeeps/' + vaultId).then(res => {
        commit('setVaultKeeps', res.data)
      })
    }
  }
})
