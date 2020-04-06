const queryString = data => {
  if (!data) return ''

  const qs = Object.keys(data).map(key => `${key}=${data[key]}`).join('&')
  return `?${qs}`
}

const appendQueryString = (url, data) => `${url}${queryString(data)}`

const getQueryParams = _ => {
  const search = decodeURIComponent(window.location.search)
  const reducer = (params, str) => {
    const [key, value] = str.split('=')
    params[key] = value
    return params
  }

  return search.slice(1).split('&').reduce(reducer, {})
}

export {
  appendQueryString,
  queryString,
  getQueryParams
}