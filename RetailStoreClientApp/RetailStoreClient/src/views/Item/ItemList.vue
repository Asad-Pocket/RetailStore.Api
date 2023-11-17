<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import ConfirmDeletePopUp from '../../components/ConfirmDeletePopUp.vue';

const itemList = ref([]);
const token = localStorage.getItem("token");
let deletepopupinstance;
const deleteid = ref(0);

onMounted(async () => {
    deletepopupinstance = new window.bootstrap.Modal(document.getElementById('deleteConfirmation'));
    
    try {
        const response = await axios.get("https://localhost:7001/api/items",{
            headers:{
              Authorization:`Bearer ${token}`
            }
        });
        itemList.value = response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
    }
});

const openDeletePopup = (id) => {
    deleteid.value = id;
    deletepopupinstance.show();
}
const closeDeletePopup = () => {
  axios.delete(`https://localhost:7001/api/items/${deleteid.value}`,{
            headers:{
              Authorization:`Bearer ${token}`
            }
        })
  .then(() => {
    itemList.value = itemList.value.filter(x => x.id != deleteid.value); 
  })
  deletepopupinstance.hide();
}
</script>

<template>
  <div class="background-image">
    <div class="content-container">
      <h1 class="title">Product List</h1>
      <div class="col-12 text-center">
        <RouterLink class="btn btn-primary Add-button" to="/item/add">Add New Item</RouterLink>
      </div>
      <div class="table-container">
        <table class="table">
          <thead>
            <tr>
              <th style="width: 15%;">Name</th>
              <th style="width: 10%;">Quantity</th>
              <th style="width: 10%;">Reorder Level</th>
              <th style="width: 10%;">Company</th>
              <th style="width: 10%;">Action</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in itemList" :key="item.id">
              <td>{{ item.name }}</td>
              <td>{{ item.quantity }}</td>
              <td>{{ item.reOrderLevel }}</td>
              <td>{{ item.company.name }}</td>
              <td class="text-center">
                <RouterLink class="btn btn-primary edit-button" :to="`/item/edit/${item.id}`">Edit</RouterLink>
                <button type="button" @click="openDeletePopup(item.id)" class="btn btn-danger">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <ConfirmDeletePopUp @confirm-delete-click="closeDeletePopup"></ConfirmDeletePopUp>
    </div>
  </div>
</template>

<style scoped>
.background-image {
  background-image: url('https://img.freepik.com/free-vector/flat-design-forest-landscape_23-2149155031.jpg?w=740&t=st=1700085486~exp=1700086086~hmac=c863e69790bb87946a6602f6ccf64e3b3329ef83f5fbced1dfcd0655339b1545');
  background-size: cover;
  background-position: center;
  min-height: 100vh;
  display: flex;
  flex-direction: column; /* Adjust to column layout */
  align-items: center; /* Center content horizontally */
  justify-content: flex-start; /* Align content to the top */
  backdrop-filter: blur(30px);
}

.content-container {
  width: 70%;
  max-width: 120%;
  margin-top: 20px;
}

.title {
  color: #fff;
}

.table-container {
  width: 100%;
  background-color: rgba(255, 255, 255, 0.8);
  border-radius: 4px;
  padding: 20px;
  overflow-x: auto; /* Enable horizontal scrolling */
}

.table {
  width: 100%;
  background-color: #93b0ce;
  border-radius: 0.5rem;
  border-collapse: collapse;
}

th, td {
  text-align: center;
  padding: 0.8rem;
  border: 1px solid #6c7d8f; /* Border color */
}

.bold-and-big {
  font-weight: bold;
  font-size: 1.2rem;
  color: #6c7d8f;
}

tr:nth-child(even) {
  background-color: #f2f2f2be;
}

tr:hover {
  background-color: #5498c5;
  color: #ffffff;
}

.text-center {
  justify-content: space-between;
  color: #f7f5f5;
}

.edit-button, .delete-button {
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 0.5rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.edit-button {
  background-color: #007bff;
  color: #fff;
}

.delete-button {
  background-color: coral;
  color: #fff;
}

.edit-button:hover {
  background-color: #0056b3;
}

.delete-button:hover {
  background-color: darkred;
}

.Add-button {
  padding-right: 20px;
  background-color: transparent;
  color: #04152e; /* Button text color */
  border: 5px solid #3b3d3d; /* Button border color */
  border-radius: 0.5rem;
  transition: background-color 0.3s, color 0.3s, border-color 0.3s;
}

.Add-button:hover {
  background-color: #007bff;
  color: #fff;
  font-weight: bold;
  border-color: #0056b3;
}
</style>
