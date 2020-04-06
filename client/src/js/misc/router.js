import page from 'page'
import { unauthenticatedRoutes, routes } from './routes'
import session from './session'
import { appendQueryString } from './queryString'

const register = (route, renderFunc) => {
  page(route, renderFunc)
}

const update = (newRoute, data) => {
  const userCanAccessRoute = unauthenticatedRoutes.includes(newRoute) || session.isValid()
  const errorMessage = "session expired"

  userCanAccessRoute ? _update(newRoute, data) : _update(routes.LOGIN, { errorMessage })
}

const _update = (newRoute, data) => {
  const route = appendQueryString(newRoute, data)

  history.pushState('', '', route)
  page(route)
  console.info(`Routed to ${newRoute}`)
}

const finish = _ => page.start()

const router = {
  register,
  update,
  finish
}

export default router