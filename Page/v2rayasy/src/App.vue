<template>
  <div id="app">
    <router-view/>
    <div id="icp">
      ICP证号：<a href="http://www.beian.miit.gov.cn/publish/query/indexFirst.action">浙ICP备19022166号-1</a>
    </div>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

#icp {
  text-align: center;
}
</style>
