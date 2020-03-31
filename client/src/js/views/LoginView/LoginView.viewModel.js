import ko, { bindingEvent } from "knockout"
import page from "page"

import sessionsApi from '../../api/controllers/sessionsApi'
import { routes } from '../../misc/routes'
import router from "../../misc/router";

class LoginViewModel {
  constructor() {
    this.email = ko.observable('');
    this.password = ko.observable('');
    this.validationError = ko.observable('');
  }

  async submitHandler() {
    const elementIds = ['LoginView-input-email', 'LoginView-input-password']
    try {
      const response = await sessionsApi.create(this.email(), this.password())
      window.token = response.token
      
      elementIds.forEach(id => {
        const element = document.getElementById(id)
        element.classList.remove('uk-form-danger')
        element.classList.add('uk-form-success')
      })
      
      console.log('response', response)
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