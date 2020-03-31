import page from 'page'
import ko from 'knockout'

import router from './router'
import LoginView from '../views/LoginView'
import SignupView from '../views/SignupView'
import HomeView from '../views/HomeView'
import NotFoundView from '../views/NotFoundView'

const renderView = (element, view, viewArgs) => {
  element.innerHTML = view.template
  ko.cleanNode(element)

  try {
    ko.applyBindings(new view.viewModel(), element)
  } catch(e) {
    console.warn(`Attempted to reapply knockout bindings to:`, element)
  }
}

export const routes = {
  LOGIN: '/login',
  SIGNUP: '/signup',
  HOME: '/home',
  NOT_FOUND: '*'
}

const registerRoutes = (element) => {
  router.register(routes.LOGIN, () => renderView(element, LoginView()))
  router.register(routes.SIGNUP, () => renderView(element, SignupView()))
  router.register(routes.HOME, () => renderView(element, HomeView()))
  router.register(routes.NOT_FOUND, () => renderView(element, NotFoundView()))
  router.finish()
}

export default registerRoutes