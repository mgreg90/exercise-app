import jwt_decode from "jwt-decode"

const TOKEN_KEY = "USER_TOKEN"

class Session {
  constructor() {
    this._token = null
  }

  setToken(token) {
    window.sessionStorage.setItem(TOKEN_KEY, token)
    this._token = jwt_decode(token)
  }

  isValid() {
    this.getToken()
    return this._isValid()
  }

  getToken() {
    if (this._isValid()) return this._token
    this._token = this._fetchAndParseToken()

    if (this._isValid()) return this._token
    window.sessionStorage.removeItem(TOKEN_KEY)

    return null
  }

  currentUserId() {
    return this._token?.unique_name
  }

  _isValid() {
    const expirationTime = this._token?.exp
    const currentTime = new Date().getTime() / 1000

    if (!expirationTime) return false
    
    return currentTime < expirationTime
  }

  _fetchAndParseToken() {
    const token = window.sessionStorage.getItem(TOKEN_KEY)
    if (!token) return null

    return jwt_decode(token)
  }
}

const session = new Session()

export default session