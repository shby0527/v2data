import axios from 'axios'

const data = {
  query (name, start, end, tag) {
    return axios.get('/api/v2data', {
      params: {
        name,
        start,
        end,
        tag
      }
    })
  }
}

export default data
