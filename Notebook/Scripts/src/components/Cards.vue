<template>
  <div>
    <div class="container">
      <div v-for="item in items" :key="item.Id">
        <b-card
          border-variant="info"
          header-bg-variant="transparent"
          style="max-width: 30rem; margin: auto; margin-bottom: 20px"
        >
          <b-row no-gutters>
            <b-col md="9">
              <b-card-text>
                <div style="font-weight: 600;">{{item.FirstName}} {{item.LastName}}</div>
                <div>Телефон: {{item.Phone}}</div>
                <div>Почта: {{item.Email}}</div>
              </b-card-text>
            </b-col>
            <b-col md="3" style="display: flex; flex-direction: column; justify-content: center;">
              <div>
                <b-button variant="danger" @click="remove(item.Id)">
                  <b-icon-trash />
                </b-button>
                <b-button variant="primary" @click="show = true, note = item">
                  <b-icon-pencil />
                </b-button>
              </div>
            </b-col>
          </b-row>
        </b-card>
      </div>
    </div>
    <Modal v-if="show" :edit="edit" :show="show" :form="note" v-on:formsubmit="UpdateNote" v-on:close="close" />
  </div>
</template>

<script>
import axios from "axios";
import Modal from "./Modal";
export default {
  name: "Cards",
  data() {
    return {
      show: false,
      edit: true,
      items: [],
      note: []
    };
  },
  components: {
    Modal
  },
  created() {
    this.getall();
  },
  updated() {
    this.getall();
  },
  methods: {
    getall() {
      axios.get("Notes").then(response => (this.items = response.data))
      .catch(error => console.log(error));
    },
    remove(id) {
      axios.delete("Notes/Delete/" + id)
      .catch(error => console.log(error));
    },
    close(value) {
      this.show = value;
    },
    UpdateNote(data) {
      axios.put("Notes/Edit/" + data.Id, data.value)
      .catch(error => console.log(error));
    }
  }
};
</script>

<style scoped>
.container {
  padding-top: 20px;
}
</style>