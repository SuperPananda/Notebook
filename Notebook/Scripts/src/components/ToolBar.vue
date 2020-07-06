<template>
  <div>
    <b-navbar type="dark" variant="info" class="nav-content">
      <b-navbar-brand tag="h1" class="mb-0">Notebook</b-navbar-brand>
      <b-navbar-nav>
        <b-nav-item @click="show = true">
          <b-icon-plus-circle font-scale="1.5" class="dropdown" />
        </b-nav-item>
      </b-navbar-nav>
    </b-navbar>
    <Modal v-if="show" :edit="edit" :show="show" :form="note" v-on:formsubmit="AddNote" v-on:close="close"/>
  </div>
</template>

<script>
import axios from 'axios';
import Modal from './Modal';
export default {
  name: "ToolBar",
  data() {
    return {
      show: false,
      edit: false,
      note: {
          FirstName: null,
          LastName: null,
          Phone: null,
          Email: null
      }
    };
  },
  components:{
      Modal
  },
  methods:{
      close(value){
          this.show = value
      },
      AddNote(value){
          axios.post("Notes/Create", value)
          .catch(error => console.log(error));
      }
  }
};
</script>

<style scoped>
.nav-content {
  justify-content: space-between;
}
</style>