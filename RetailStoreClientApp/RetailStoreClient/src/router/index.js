import { createRouter, createWebHistory } from 'vue-router'
import ItemList from '../views/Item/ItemList.vue'
import AddItem from '../views/Item/AddItem.vue'
import EditItem from '../views/Item/EditItem.vue'
import AddCompany from '../views/Company/AddCompany.vue'
import CompanyDetails from '../views/Company/CompanyDetails.vue'
import EditCompany from '../views/Company/EditCompany.vue'
import Registration from '../views/Identity/Registration.vue'
import Login from '../views/Identity/Login.vue'
import GetData from '../views/RealApi/GetData.vue'
import HomeView from '../views/HomeView.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/item',
      name: 'Item',
      component: ItemList
    },
    {
      path: '/item/add',
      name: 'additem',
      component: AddItem
    },
    {
      path: '/item/edit/:id',
      name: 'edititem',
      component: EditItem
    },
    {
      path: '/company/add',
      name: 'addcompany',
      component: AddCompany
    },
    {
      path: '/company/Details',
      name: 'Details',
      component: CompanyDetails
    }
    ,
    {
      path: '/company/edit/:id',
      name: 'editcompany',
      component: EditCompany
    },
    {
      path: '/register',
      name: 'register',
      component: Registration
    },
    {
      path: '/Login',
      name: 'login',
      component: Login
    },
    {
      path: '/GetData',
      name: 'getdata',
      component: GetData
    }
  ]
})

export default router
