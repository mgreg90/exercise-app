import ko from 'knockout'

import session from '../../misc/session'

class HomeViewModel {
  constructor() {
    const token = session.getToken()
    this.firstName = ko.observable(token.email || '')
  }
}

export default HomeViewModel