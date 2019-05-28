import axios from 'axios'

const data = {
  query (name, start, end) {
    return axios.get('/api/v2data', {
      params: {
        name,
        start,
        end
      }
    })
  }
}

export default data
