<template>
  <div>
    <h1><img class="main" src="@/assets/add.png"/>To do items</h1>        
    <b-table bordered striped :items="toDoItems" :fields="displayColumns" show-empty>
    
      <!-- A virtual column -->
      <template v-slot:cell(actions)="data">      
        <a href="http://23.101.213.122/index.html"><img src="@/assets/pencil.png"/></a><a href="http://23.101.213.122/index.html"><img src="@/assets/close.png"/></a>
      </template>
    </b-table>
  </div>
</template>

<script>
//import axios from 'axios'

export default {
  name: 'ToDoItems',
  props: {
    msg: String
  },
  data () {
    return {
        displayColumns: [{
          key: 'id',
          sortable: true
        },{
          key: 'title',
          sortable: true
        },{
          key: 'state',
          sortable: true
        },
        {
          key: 'actions'
        }],
   // Remove mock data once cors issue sorted
          toDoItems : [
  {
    "id": "2",
    "title": "Work on todo project",
    "state": "Doing"
  },
  {
    "id": "3",
    "title": "Fold clothes",
    "state": "To do"
  },
  {
    "id": "4",
    "title": "Exhausting task",
    "state": "Doing"
  },
  {
    "id": "6",
    "title": "baby duties",
    "state": "Doing"
  },
  {
    "id": "7",
    "title": "make it rain from the cloud",
    "state": "To do"
  },
  {
    "id": "10",
    "title": "Play dough with Sanaya",
    "state": "Doing"
  },
  {
    "id": "13",
    "title": "Make the vue app",
    "state": "To do"
  }
]
    }
  },
  mounted () {
    // axios
    //   .get('http://todoitemsapi.australiaeast.azurecontainer.io/todoitems')
    //   .then(response => (this.toDoItems = response))
    // todo: sort cors issues
  }
}
</script>

<style>
img{
    width: 20px;
    margin: 5px;
}
img.main{
    width: 40px;
    margin: 10px;
}
</style>
