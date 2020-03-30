import page from 'page'
import ko from 'knockout'

import router from './router'
import LoginView from '../views/LoginView'
import SignupView from '../views/SignupView'
import HomeView from '../views/HomeView'

const renderView = (element, view) => {
  element.innerHTML = view.template
  ko.cleanNode(element)
  ko.applyBindings(new view.viewModel())
}

export const routes = {
  LOGIN: '/login',
  SIGNUP: '/signup',
  HOME: '/home'
}

const registerRoutes = (element) => {
  router.register(routes.LOGIN, () => renderView(element, LoginView()))
  router.register(routes.SIGNUP, () => renderView(element, SignupView()))
  router.register(routes.HOME, () => renderView(element, HomeView()))
  router.finish()
}

export default registerRoutes