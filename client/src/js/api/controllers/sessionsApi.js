import { baseUrl, ApiError } from '../apiBase'

const url = `${baseUrl}/sessions`
const sessionsApi = {
  create: async (email, password) => {
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Cache-Control': 'no-cache'
      },
      body: JSON.stringify({ email, password })
    })
    const parsedResponse = await response.json()
    console.log(parsedResponse)

    if (response.status < 200 || response.status >= 300)
      throw new ApiError(parsedResponse.Message)

    return parsedResponse
  }
}

export default sessionsApi