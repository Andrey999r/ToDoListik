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
  </div>
</template>

<script>
export default {
  data() {
    return {
      records: [],
      newTitle: '',
      newContent: '',
      nextId: 1  // Уникальный идентификатор для каждой задачи
    }
  },
  methods: {
    addRecord() {
      if (!this.newTitle || !this.newContent) {
        alert('Заголовок и содержание не могут быть пустыми!');
        return;
      }
      // Добавляем новую запись в массив records
      this.records.push({
        id: this.nextId++,
        title: this.newTitle,
        content: this.newContent
      });
      // Очищаем поля ввода
      this.newTitle = '';
      this.newContent = '';
    },
    deleteRecord(index) {
      // Удаляем запись из массива по индексу
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
  margin-left: 10px; /* Добавляем отступ слева от чекбокса */
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
