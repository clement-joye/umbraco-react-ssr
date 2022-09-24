import axios, { AxiosPromise } from 'axios'

export const apiEndpoint: string = process.env.REACT_APP_API_ENDPOINT ?? 'http://localhost:7000/api/'
export const mediaEndpoint: string = process.env.REACT_APP_MEDIA_ENDPOINT ?? 'http://localhost:7000'

console.log(`ApiEndpoint: ${apiEndpoint}`)
console.log(`MediaEndpoint: ${mediaEndpoint}`)

export function apiRequest(path: string): AxiosPromise<any> {
  return axios(apiEndpoint + path)
}

export function parseHtml(raw: string): string {
  if (raw === null || raw === '') return ''
  else raw = raw.toString()

  return raw.replace(/(<([^>]+)>)/gi, '')
}
