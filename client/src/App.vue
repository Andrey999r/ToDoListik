<template>
  <div id="app">
    <h1 style="font-style: italic;">Мой ToDo List</h1>
    <div>
      <input v-model="newTitle" placeholder="Заголовок">
      <input v-model="newContent" placeholder="Содержание">
      <button @click="addRecord">Добавить задачу</button>
    </div>
    <ul>
      <li v-for="(record, index) in records" :key="record.RecordId">
        <span>{{ record.title }} - {{ record.content }}-</span>
        <button @click="deleteRecord(record.recordId)">Удалить задачу</button>

      </li>
    </ul>
    <footer>
      Authors: Andrey Kustov, Ivan Konovalenko
    </footer>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      url:"http://localhost:5225/",
      records: [],
      newTitle: '',
      newContent: ''
    }
  },
  mounted() {
    this.getRecords();
  },
  methods: {
    async getRecords() {
      try {
        const response = await axios.get(`${this.url}showAllRecords`);
        this.records = response.data;
      } catch (error) {
        console.error('Error fetching records:', error);
      }

    },
    async addRecord() {
      if (!this.newTitle || !this.newContent) {
        alert('Заголовок и содержание не могут быть пустыми!');
        return;
      }

      try {
        const response = await axios.post(`${this.url}addRecord/${this.newTitle}/${this.newContent}`);
        this.newTitle = '';
        this.newContent = '';
        this.getRecords();
      } catch (error) {
        console.error('Error adding record:', error);
      }
    },
    async deleteRecord(id) {
      try {
        console.log(id);
        await axios.post(`${this.url}deleteRecord/${id}`);
        this.getRecords();
      } catch (error) {
        console.error('Error deleting record:', error);
      }
    },
    async editRecord(id, title, content) {
      try {
        const response = await axios.put(`${this.url}editRecord/${id}/${title}/${content}`);
        const index = this.records.findIndex(record => record.id === id);
        if (index !== -1) {
          this.records[index] = response.data;
        }
      } catch (error) {
        console.error('Error editing record:', error);
      }
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