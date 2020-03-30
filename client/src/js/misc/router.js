import page from 'page'

const register = (route, renderFunc) => {
  page(route, renderFunc)
}

const update = newRoute => {
  history.pushState('', '', newRoute)
  page(newRoute)
}

const finish = _ => page.start()

const router = {
  register,
  update,
  finish
}

export default router