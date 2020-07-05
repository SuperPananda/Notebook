<template>
  <div id="app">
    <ToolBar />
    <Table />
  </div>
</template>

<script>
//Подключаем компоненты
import ToolBar from './components/ToolBar'
import Table from './components/Table'

export default {
  name: 'app',
  components:{
    ToolBar,
    Table
  }
}
</script>

<style scoped>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 0;
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
