import Vue from 'vue'
import VueRouter from 'vue-router'
import { BootstrapVue, LinkPlugin} from 'bootstrap-vue'
import '../node_modules/bootstrap/dist/css/bootstrap.css'
import '../node_modules/bootstrap-vue/dist/bootstrap-vue.css'
import ToDoItems from './components/ToDoItems.vue'
import App from './App.vue'

Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(LinkPlugin)
Vue.use(VueRouter)

const routes = [
  { path: '/', component: ToDoItems },
  { path: '/todoitems', component: ToDoItems }
]

const router = new VueRouter({
  routes // short for `routes: routes`
})

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
