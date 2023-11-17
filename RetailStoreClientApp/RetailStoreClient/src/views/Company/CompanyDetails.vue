<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import ConfirmDeletePopUp from '../../components/ConfirmDeletePopUp.vue';

const itemList = ref([]);
let deletePopUpInstance;
const deleteId = ref(0);
const token = localStorage.getItem("token");

onMounted(async () => {
    deletePopUpInstance = new window.bootstrap.Modal(document.getElementById('deleteConfirmation'));
    
    try {
        if(!token)
        return;
        const response = await axios.get("https://localhost:7001/api/companies",{
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
    deleteId.value = id;
    deletePopUpInstance.show();
}
const closeDeletePopup = () => {
  axios.delete(`https://localhost:7001/api/companies/${deleteId.value}`,{
            headers:{
              Authorization:`Bearer ${token}`
            }
        })
  .then(() => {
    itemList.value = itemList.value.filter(x => x.id != deleteId.value); 
  })
  deletePopUpInstance.hide();
}
</script>
<template>
  <div class="background-image">
    <div class="container mt-4">
      <div class="row mb-2">
        <div class="col-12 text-center">
          <RouterLink class="btn btn-primary Add-button" to="/company/add">Add New Company</RouterLink>
        </div>
      </div>
      <div class="table-container">
        <table class="table table-striped table-bordered">
          <thead class="thead-dark">
            <tr>
              <th>Name</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody v-if="itemList.length > 0">
            <tr v-for="item in itemList" :key="item.id">
              <td>{{ item.name }}</td>
              <td class="text-center">
                <RouterLink class="btn btn-primary edit-button" :to="`../company/edit/${item.id}`">Edit</RouterLink>
                <button type="button" @click="openDeletePopup(item.id)" class="btn btn-danger delete-button">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <ConfirmDeletePopUp @confirm-delete-click="closeDeletePopup"></ConfirmDeletePopUp>
  </div>
</template>

<style scoped>
/* Add scoped to ensure the styles only apply to this component */

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

.container {
  width: 100%;
  max-width: 70%;
  margin-top: 20px;
}

.table-container {
  width: 100%;
  background-color: rgba(255, 255, 255, 0.8);
  border-radius: 4px;
  padding: 20px;
}

.table {
  width: 100%;
  background-color: #93b0ce;
  border-radius: 0.5rem;
}
th, td {
  text-align: center;
  padding: 0.8rem;
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
.text-center{
  justify-content: space-between;
}
.edit-button {
  justify-content: flex-start;
  padding: 0.5rem 1rem;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 0.5rem;
  cursor: pointer;
  transition: background-color 0.3s;
}
.delete-button{
  justify-content: flex-start;
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 0.5rem;
  cursor: pointer;
  transition: background-color 0.3s;
}
.edit-button:hover {
  background-color: #0056b3;
}
.delete-button:hover{
  background-color: coral;
}
.Add-button{
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
