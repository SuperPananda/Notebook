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
              <form>
                <strong>Name:</strong>
                <input id="name" type="text" class="form-control" />
                <strong>Last Name:</strong>
                <input id="name" class="form-control" />
                <strong>Phone:</strong>
                <input class="form-control" />
                <strong>Email:</strong>
                <input id="email" class="form-control" />
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
  props: ["show"],
  data() {
    return {
      showModal: this.show
    };
  },
  methods:{
      closeModal(){
          this.showModal = false;
          this.$emit('close', this.showModal);
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