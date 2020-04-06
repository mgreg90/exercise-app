import ko from "knockout"

import usersApi from '../../api/controllers/usersApi'
import { routes } from '../../misc/routes'
import router from "../../misc/router"
import session from "../../misc/session"
import sessionsApi from "../../api/controllers/sessionsApi"

class SignupViewModel {
  constructor() {
    this.email = ko.observable('');
    this.password = ko.observable('');
    this.passwordConfirmation = ko.observable('');
    this.validationError = ko.observable('');
  }

  async submitHandler() {
    const elementIds = ['SignupView-input-email', 'SignupView-input-password', 'SignupView-input-passwordConfirmation']
    const body = {
      email: this.email(),
      password: this.password()
    }

    try {
      let response = await usersApi.create({
        ...body,
        passwordConfirmation: this.passwordConfirmation()
      })

      response = await sessionsApi.create(body)

      session.setToken(response.token)

      elementIds.forEach(id => {
        const element = document.getElementById(id)
        element.classList.remove('uk-form-danger')
        element.classList.add('uk-form-success')
      })

      this.validationError('')
      router.update(routes.HOME)

    } catch (error) {

      console.error(error)

      elementIds.forEach(id => {
        const element = document.getElementById(id)
        element.classList.remove('uk-form-success')
        element.classList.add('uk-form-danger')
      })

      this.validationError(error.message)
    }
  }
}

export default SignupViewModel