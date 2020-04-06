import ko from "knockout"

import sessionsApi from '../../api/controllers/sessionsApi'
import { routes } from '../../misc/routes'
import router from "../../misc/router";
import session from "../../misc/session"
import { getQueryParams } from "../../misc/queryString";

class LoginViewModel {
  constructor() {
    const { errorMessage = '' } = getQueryParams()
    this.email = ko.observable('');
    this.password = ko.observable('');
    this.validationError = ko.observable(errorMessage);
  }

  async submitHandler() {
    const elementIds = ['LoginView-input-email', 'LoginView-input-password']
    try {
      const response = await sessionsApi.create({
        email: this.email(),
        password: this.password()
      })
      session.setToken(response.token)
      
      elementIds.forEach(id => {
        const element = document.getElementById(id)
        element.classList.remove('uk-form-danger')
        element.classList.add('uk-form-success')
      })

      this.validationError('')
      router.update(routes.HOME)

    } catch(error) {

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

export default LoginViewModel