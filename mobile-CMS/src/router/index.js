import Vue from 'vue'
import Router from 'vue-router'
import HomeContainer from '@/views/tabbar/HomeContainer'
import MemberContainer from '@/views/tabbar/MemberContainer'
import SearchContainer from '@/views/tabbar/SearchContainer'
import ShopcarContainer from '@/views/tabbar/ShopcarContainer'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HomeContainer',
      component: HomeContainer
    },
    {
      path: '/home',
      name: 'HomeContainer',
      component: HomeContainer
    },
    {
      path: '/member',
      name: 'MemberContainer',
      component: MemberContainer
    },
    {
      path: '/shopcar',
      name: 'ShopcarContainer',
      component: ShopcarContainer
    },
    {
      path: '/search',
      name: 'SearchContainer',
      component: SearchContainer
    }
  ],
  linkActiveClass:'mui-active' //覆盖默认多路由高亮的类，默认的类叫做route-link-active
})
