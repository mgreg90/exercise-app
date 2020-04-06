export const baseUrl = "https://localhost:5001/api/v1"
// TODO update to use no-cache only in dev (maybe?)

export const basePostRequest = async (url, body, headers = {}) => {
  const response = await fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
      ...headers
    },
    body: JSON.stringify(body)
  })
  const parsedResponse = await response.json()

  if (response.status < 200 || response.status >= 300)
    throw new ApiError(parsedResponse.Message)

  return parsedResponse
}

export class ApiError extends Error {}