<template>
  <div class="hello">
    <div class="charts-area">
      <div id="chart" class="charts"></div>
      <div id="chart2" class="charts"></div>
    </div>
    <div class="query">
      <el-form label-width="88px">
        <el-col :span="5">
          <el-form-item label="邮箱">
            <el-input v-model="name" />
          </el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="服务器名">
            <el-input v-model="tags" />
          </el-form-item>
        </el-col>
        <el-col :span="10">
          <el-form-item label="时间范围">
            <el-date-picker
              v-model="times"
              type="datetimerange"
              range-separator="至"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
            />
          </el-form-item>
        </el-col>
        <el-col :span="4">
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
          prop="tags"
          label="服务器名称"
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
import echart from 'echarts'

export default {
  name: 'HelloWorld',
  data () {
    let now = new Date()
    let start = new Date()
    start.setHours(start.getHours() - 3)
    return {
      name: '',
      tags: '',
      times: [start, now],
      v2ray: [],
      chart: null,
      chart2: null
    }
  },
  mounted () {
    this.loadData()
    this.chart = echart.init(document.getElementById('chart'))
    this.chart2 = echart.init(document.getElementById('chart2'))
  },
  methods: {
    loadData () {
      api.data.query(this.name, this.times[0], this.times[1], this.tags)
        .then(response => {
          this.v2ray = response.data
          this.$nextTick(() => {
            this.chart.clear()
            this.chart2.clear()
            this.makeLine1()
            this.makeLine2()
          })
        })
    },
    formatter (row, column, cellValue, index) {
      return memont(cellValue).format('YYYY年MM月DD日 HH:mm:ss')
    },
    makeLine1 () {
      var chartObj = {
        title: {
          text: '下行流量'
        },
        tooltip: {
          trigger: 'axis'
        },
        legend: {
          data: Array.from(new Set(this.v2ray.filter(e => e.utype === 'user').map(e => e.user)))
        },
        xAxis: {
          type: 'category',
          boundaryGap: false,
          data: Array.from(new Set(this.v2ray.map(e => memont(e.createTime).format('YYYY年MM月DD日 HH:mm:ss'))))
        },
        yAxis: {
          type: 'value'
        },
        series: []
      }
      var down = this.v2ray.filter(e => e.linkType === 'downlink' && e.utype === 'user')
      chartObj.legend.data.forEach(e => {
        let udata = down.filter(u => u.user === e)
        let sery = {
          name: e,
          type: 'line',
          data: []
        }
        chartObj.xAxis.data.forEach(time => {
          if (udata.some(ud => memont(ud.createTime).format('YYYY年MM月DD日 HH:mm:ss') === time)) {
            sery.data.push(udata.find(ud => memont(ud.createTime).format('YYYY年MM月DD日 HH:mm:ss') === time).size)
          } else {
            sery.data.push(0)
          }
        })
        chartObj.series.push(sery)
      })
      this.chart.setOption(chartObj)
    },
    makeLine2 () {
      var chartObj = {
        title: {
          text: '上行流量'
        },
        tooltip: {
          trigger: 'axis'
        },
        legend: {
          data: Array.from(new Set(this.v2ray.filter(e => e.utype === 'user').map(e => e.user)))
        },
        xAxis: {
          type: 'category',
          boundaryGap: false,
          data: Array.from(new Set(this.v2ray.map(e => memont(e.createTime).format('YYYY年MM月DD日 HH:mm:ss'))))
        },
        yAxis: {
          type: 'value'
        },
        series: []
      }
      var down = this.v2ray.filter(e => e.linkType === 'uplink' && e.utype === 'user')
      chartObj.legend.data.forEach(e => {
        let udata = down.filter(u => u.user === e)
        let sery = {
          name: e,
          type: 'line',
          data: []
        }
        chartObj.xAxis.data.forEach(time => {
          if (udata.some(ud => memont(ud.createTime).format('YYYY年MM月DD日 HH:mm:ss') === time)) {
            sery.data.push(udata.find(ud => memont(ud.createTime).format('YYYY年MM月DD日 HH:mm:ss') === time).size)
          } else {
            sery.data.push(0)
          }
        })
        chartObj.series.push(sery)
      })
      this.chart2.setOption(chartObj)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.charts {
  width: 100%;
  height: 400px;
  flex-shrink: 1;
}
.charts-area {
  display: flex;
}
</style>
