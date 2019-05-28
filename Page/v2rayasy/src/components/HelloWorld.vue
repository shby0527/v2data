<template>
  <div class="hello">
    <div id="chart" class="charts"></div>
    <div class="query">
      <el-form label-width="88px">
        <el-col :span="6">
          <el-form-item label="邮箱">
            <el-input v-model="name" />
          </el-form-item>
        </el-col>
        <el-col :span="6">
          <el-form-item label="开始时间">
            <el-date-picker
              v-model="start"
              type="date" />
          </el-form-item>
        </el-col>
        <el-col :span="6">
          <el-form-item label="结束时间">
            <el-date-picker
              v-model="end"
              type="date" />
          </el-form-item>
        </el-col>
        <el-col :span="6">
          <el-form-item>
            <el-button @click="loadData" type="primary">查询</el-button>
          </el-form-item>
        </el-col>
      </el-form>
    </div>
    <div class="tables">
      <el-table
        :data="v2ray"
        style="width: 100%"
      >
        <el-table-column
          prop="linkType"
          label="类型"
        />
        <el-table-column
          prop="user"
          label="用户"
          sortable
        />
        <el-table-column
          prop="size"
          label="流量（B）"
          sortable
        />
        <el-table-column
          prop="utype"
          label="用户类型"
        />
        <el-table-column
          prop="createTime"
          label="时间"
          sortable
          :formatter="formatter"
        />
      </el-table>
    </div>
  </div>
</template>

<script>
import api from '../api'
import memont from 'dayjs'

export default {
  name: 'HelloWorld',
  data () {
    let now = new Date()
    let start = new Date()
    start.setDate(start.getDate() - 1)
    return {
      name: '',
      start: start,
      end: now,
      v2ray: []
    }
  },
  mounted () {
    this.loadData()
  },
  methods: {
    loadData () {
      api.data.query(this.name, this.start, this.end)
        .then(response => {
          let echart = require('echarts')
          this.v2ray.splice(0, this.v2ray.length)
          response.data.forEach(e => this.v2ray.push(e))
          this.$nextTick(() => {
            let chart = echart.init(document.getElementById('chart'))
            chart.setOption(this.makeLine())
          })
        })
    },
    formatter (row, column, cellValue, index) {
      return memont(cellValue).format('YYYY年MM月DD日 HH:mm:ss')
    },
    makeLine () {
      let date = []
      let start = new Date()
      start.setDate(start.getDate() - 1)
      let now = new Date()
      // eslint-disable-next-line no-unmodified-loop-condition
      while (start < now) {
        start.setMinutes(start.getMinutes() + 10)
        date.push(memont(start).format('YYYY年MM月DD日 HH:mm:ss'))
      }
      let userData = Array.from(new Set(this.v2ray.map(item => item.user + '(' + item.linkType + ')')))
      let series = []
      userData.forEach(u => {
        let all = this.v2ray.filter(n => u === (n.user + '(' + n.linkType + ')'))
        let fixed = date.length - all.length
        let rtn = []
        for (var i = 0; i < fixed; i++) {
          rtn.push(0)
        }
        all.forEach(a => rtn.push(a.size))
        series.push({
          name: u,
          type: 'line',
          stack: '流量',
          data: rtn
        })
      })
      return {
        title: {
          text: '流量统计图'
        },
        tooltip: {
          trigger: 'axis'
        },
        legend: {
          data: userData
        },
        xAxis: {
          type: 'category',
          boundaryGap: false,
          data: date
        },
        yAxis: {
          type: 'value'
        },
        series: series
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.charts {
  width: 100%;
  height: 400px;
}
</style>
