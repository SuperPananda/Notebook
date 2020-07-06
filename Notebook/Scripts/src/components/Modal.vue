<template>
  <transition name="modal">
    <div class="modal-mask">
      <div class="modal-wrapper">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Добавить контакт</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true" @click="closeModal()">&times;</span>
              </button>
            </div>
            <div class="modal-body" style="text-align: left;">
              <div v-if="errors.length">
                <b>Пожалуйста, исправьте следующие ошибки:</b>
                <ul>
                  <li v-for="error in errors" :key="error.index">{{ error }}</li>
                </ul>
              </div>
              <form @submit="formSubmit">
                <div class="form-group">
                  <label style="font-weight: 600;">Имя</label>
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Иван"
                    v-model="formModal.FirstName"
                  />
                  <small class="form-text text-muted">Имя должно начинаться с большой буквы.</small>
                </div>
                <div class="form-group">
                  <label style="font-weight: 600;">Фамилия</label>
                  <input
                    type="text"
                    class="form-control"
                    placeholder="Иванов"
                    v-model="formModal.LastName"
                  />
                  <small class="form-text text-muted">Фамилия должна начинаться с большой буквы.</small>
                </div>
                <div class="form-group">
                  <label style="font-weight: 600;">Телефон</label>
                  <input
                    type="text"
                    class="form-control"
                    placeholder="79xxxxxxxxx"
                    v-model="formModal.Phone"
                  />
                  <small
                    class="form-text text-muted"
                  >Пример корректного номера телефона: 79xxxxxxxxx.</small>
                </div>
                <div class="form-group">
                  <label style="font-weight: 600;">Email</label>
                  <input
                    type="email"
                    class="form-control"
                    placeholder="name@example.com"
                    v-model="formModal.Email"
                  />
                  <small class="form-text text-muted">Пример корректного email: name@example.com.</small>
                </div>
                <button class="btn btn-primary">Добавить</button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
import axios from "axios";
export default {
  name: "Modal",
  props: ["show", "form", "edit"],
  data() {
    return {
      errors: [],
      showModal: this.show,
      formModal: this.form,
      editModal: this.edit,
    };
  },
  methods: {
    closeModal() {
      this.showModal = false;
      this.$emit("close", this.showModal);
    },
    formSubmit(e) {
      this.errors = [];
      
      if (!this.form.Phone) {
        this.errors.push("Вы должны указать номер телефона!");
      } else if (!this.validNumber(this.form.Phone)) {
        this.errors.push("Введите правильный номер телефона.");
      }
      if (!this.form.Email) {
        this.errors.push("Вы должны указать email!");
      } else if (!this.validEmail(this.form.Email)) {
        this.errors.push("Введите правильный email.");
      }
      if (!this.form.FirstName) {
        this.errors.push("Вы должны указать Имя!");
      } else if (!this.validName(this.form.FirstName)) {
        this.errors.push("Введите правильное имя.");
      }
      if (!this.form.LastName) {
        this.errors.push("Вы должны указать Фамилию!");
      } else if (!this.validName(this.form.LastName)) {
        this.errors.push("Введите правильную фамилию.");
      }

      if (!this.errors.length) {
        const formData = new FormData();
        formData.append("FirstName", this.form.FirstName);
        formData.append("Phone", this.form.Phone);
        formData.append("Email", this.form.Email);
        formData.append("LastName", this.form.LastName);
        this.showModal = false;
        this.$emit("close", this.showModal);
        if (this.editModal) {
          formData.append("Id", this.form.Id);
          this.$emit("formsubmit", {
            Id: this.form.Id,
            value: formData
          });
        } else {
          this.$emit("formsubmit", formData);
        }
        return true;
      }
      e.preventDefault();
    },
    validEmail: function(email) {
      var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email);
    },
    validNumber: function(number) {
      var re = /^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$/;
      return re.test(number);
    },
    validName: function(name) {
      var re = /^([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$/;
      return re.test(name);
    }
  }
};
</script>

<style scoped>
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}
</style>