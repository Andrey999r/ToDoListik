<template>
  <div id="app">
    <h1 style="font-style: italic;">Мой ToDo List</h1>
    <div>
      <input v-model="newTitle" placeholder="Заголовок">
      <input v-model="newContent" placeholder="Содержание">
      <button @click="addRecord">Добавить задачу</button>
    </div>
    <ul>
      <li v-for="(record, index) in records" :key="record.id">
        <span>{{ record.title }} - {{ record.content }}</span>
        <input type="checkbox" @click="deleteRecord(index)">
      </li>
    </ul>
    <footer>
      Authors: Andrey Kustov, Ivan Konovalenko
    </footer>
  </div>
</template>

<style>
#app {
  max-width: 600px;
  margin: 0;
  padding: 20px;
  text-align: left;
  font-family: Arial, sans-serif;
}

ul {
  list-style-type: disc;
  padding-left: 20px;
}

li::marker {
  font-size: 20px;
}

input[type="checkbox"] {
  margin-left: 10px;
}

button {
  background-color: #4CAF50;
  color: white;
  border: none;
  padding: 8px;
  cursor: pointer;
}

button:hover {
  background-color: #45a049;
}

li {
  background-color: #fff;
  padding: 10px;
  margin-top: 5px;
  border-radius: 5px;
}

input {
  margin-right: 5px;
  padding: 8px;
}

footer {
  margin-top: 20px;
  font-size: 14px;
}
</style>


<script>
export default {
  data() {
    return {
      records: [],
      newTitle: '',
      newContent: '',
      nextId: 1
    }
  },
  methods: {
    addRecord() {
      if (!this.newTitle || !this.newContent) {
        alert('Заголовок и содержание не могут быть пустыми!');
        return;
      }

      this.records.push({
        id: this.nextId++,
        title: this.newTitle,
        content: this.newContent
      });
      this.newTitle = '';
      this.newContent = '';
    },
    deleteRecord(index) {
      this.records.splice(index, 1);
    }
  }
}
</script>

<style>
#app {
  max-width: 600px;
  margin: 0 auto;
  font-family: Arial, sans-serif;
  padding: 20px;
}

input[type="checkbox"] {
  margin-left: 10px;
}

button {
  background-color: #4CAF50;
  color: white;
  border: none;
  padding: 8px;
  cursor: pointer;
}

button:hover {
  background-color: #45a049;
}

li {
  background-color: #fff;
  padding: 10px;
  margin-top: 5px;
  border-radius: 5px;
}

input {
  margin-right: 5px;
  padding: 8px;
}

h1 {
  color: #333;
}
</style>
