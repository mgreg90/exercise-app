import { baseUrl, basePostRequest } from '../apiBase'

const url = `${baseUrl}/sessions`
const sessionsApi = {
  create: async (body) => basePostRequest(url, body)
}

export default sessionsApi