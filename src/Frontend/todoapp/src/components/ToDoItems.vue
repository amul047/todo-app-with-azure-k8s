<template>
  <div>
    <b-jumbotron>
      <h1>To do items</h1>
    </b-jumbotron>
    <h1>{{ msg }}</h1>
  </div>
</template>

<script>
export default {
  name: 'ToDoItems',
  props: {
    msg: String
  }
}
</script>
