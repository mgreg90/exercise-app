import jwt_decode from "jwt-decode"

const TOKEN_KEY = "USER_TOKEN"

class Session {
  constructor() {
    this._token = null
  }

  setToken(token) {
    window.sessionStorage.setItem(TOKEN_KEY, token)
    this._token = this._fetchAndParseToken(token)
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
    const expirationTime = this._token?.expirationTime
    const currentTime = new Date().getTime() / 1000

    if (!expirationTime) return false
    
    return currentTime < expirationTime
  }

  _fetchAndParseToken(token = null) {
    token = token || window.sessionStorage.getItem(TOKEN_KEY)
    if (!token) return null

    token = jwt_decode(token)
    return {
      email: token.unique_name,
      id: token.nameid,
      expirationTime: token.exp
    }
  }
}

const session = new Session()

export default session