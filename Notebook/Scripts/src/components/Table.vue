<template>
  <b-table :items="items" :fields="fields" outlined>
    <template v-slot:cell(edit)="row">
      <b-button size="sm" variant="danger" class="mr-2">
        <b-icon-trash/>
      </b-button>
      <b-button size="sm">
          <b-icon-pencil/>
      </b-button>
    </template>
  </b-table>
</template>

<script>
export default {
  name: "Table",
  data() {
    return {
      fields: ["name", "lastname", "phone", "email", "edit"],
      items: [{name: "Мария", lastname:"Петрова", phone: "79137966287", email: "mail@mail.com"}]
    };
  }
};
</script>