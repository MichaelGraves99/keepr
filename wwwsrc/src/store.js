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
    userKeep: [],
    allKeep: [],
    vault: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setUserKeep(state, userKeep) {
      state.userKeep = userKeep
    },
    setAllKeep(state, allKeep) {
      state.allKeep = allKeep
    },
    setVault(state, vault) {
      state.vault = vault
    }
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
    logout({ commit, dispatch }, creds) {
      auth.delete('login', creds)
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
        .catch(e => {
          console.log('Logout Failed')
        })
    },
    createKeep({ commit, dispatch }, data) {
      api.post('/keep', data)
        .then(res => {
          // console.log(res.data);
          dispatch('getAllKeep')
        })
    },
    getAllKeep({ commit, dispatch }) {
      api.get('/keep')
        .then(res => {
          // console.log("Keeps success")
          commit('setAllKeep', res.data)
        })
    },
    getUserKeep({ commit, dispatch }) {
      api.get('/keep')
        .then(res => {
          // console.log("Keeps success")
          commit('setUserKeep', res.data)
        })
    },
    deleteKeep({ commit, dispatch }, data) {
      api.delete('/keep' + data)
        .then(res => {
          dispatch('getUserKeep')
        })
    },






  }
})
