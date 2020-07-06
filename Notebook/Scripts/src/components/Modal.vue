<template>
  <transition name="modal">
    <div class="modal-mask">
      <div class="modal-wrapper">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Add Note</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true" @click="closeModal()">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form @submit="formSubmit">
                <strong>Name:</strong>
                <input id="name" type="text" class="form-control" v-model="formModal.FirstName" />
                <strong>Last Name:</strong>
                <input id="name" class="form-control" v-model="formModal.LastName" />
                <strong>Phone:</strong>
                <input class="form-control" v-model="formModal.Phone" />
                <strong>Email:</strong>
                <input id="email" class="form-control" v-model="formModal.Email" />
                <br />
                <button class="btn btn-success">Submit</button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  name: "Modal",
  props: ["show", "form", "edit"],
  data() {
    return {
      showModal: this.show,
      formModal: this.form,
      editModal: this.edit
    };
  },
  methods: {
    closeModal() {
      this.showModal = false;
      this.$emit("close", this.showModal);
    },
    formSubmit(e) {
      e.preventDefault();
      //console.log(this.form);
      const formData = new FormData();
      formData.append("FirstName", this.form.FirstName);
      formData.append("Phone", this.form.Phone);
      formData.append("Email", this.form.Email);
      formData.append("LastName", this.form.LastName);
      this.showModal = false;
      this.$emit("close", this.showModal);
      if (this.editModal)
      {
          formData.append("Id", this.form.Id);
          this.$emit("formsubmit", {
              Id: this.form.Id,
              value: formData
              })
      }
      else{
          this.$emit("formsubmit", formData); 
      }
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