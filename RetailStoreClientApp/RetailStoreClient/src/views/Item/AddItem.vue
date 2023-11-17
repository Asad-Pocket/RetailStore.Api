<script setup>
import { ref, onMounted, reactive } from 'vue';
import axios from 'axios';
import { useRouter } from "vue-router";

let formData = reactive({
  Name: '',
  Quantity: null,
  ReOrderLevel: null,
  SelectedCompany: null,
});

const router = useRouter();
const handleSubmit = async () => {
  try {
    if (!formData.SelectedCompany) {
      console.error("Invalid selected company");
      return;
    }

    const postData = {
      Name: formData.Name,
      Quantity: formData.Quantity,
      ReOrderLevel: formData.ReOrderLevel,
      CompanyId: formData.SelectedCompany,
    };
    const token = localStorage.getItem("token");
        if(!token)
          return;
        const response = await axios.post("https://localhost:7001/api/items", postData,{
            headers:{
              Authorization:`Bearer ${token}`
            }
        });
    router.push('/');
  } catch (error) {
    console.error("Error submitting form:", error);
  }
};

const companies = ref([]);

onMounted(async () => {
  try {
        const token = localStorage.getItem("token");
        if(!token)
        return;
        const response = await axios.get("https://localhost:7001/api/companies",{
            headers:{
              Authorization:`Bearer ${token}`
            }
        });
        companies.value = response.data;
    } catch (error) {
        console.error('Error fetching data:', error);
    }
});


</script>

<template>
    <div class="background-image">
      <div class="container">
        <form @submit.prevent="handleSubmit" class="my-form">
            <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px;">
                <legend class="form-legend" >Add New Item</legend>
            </div>
          <div class="mb-3">
            <label for="Name" class="form-label">Name</label>
            <input type="text" class="form-control" id="Name" v-model="formData.Name">
          </div>
          <div class="mb-3">
            <label for="Quantity" class="form-label">Quantity</label>
            <input type="number" class="form-control" id="Quantity" v-model="formData.Quantity">
          </div>
          <div class="mb-3">
            <label for="ReOrderLevel" class="form-label">Re-Order Level</label>
            <input type="number" class="form-control" id="ReOrderLevel" v-model="formData.ReOrderLevel">
          </div>
          <div class="mb-3">
            <label for="SelectedCompany" class="form-label">Select Company</label>
            <select class="form-select" id="SelectedCompany" v-model="formData.SelectedCompany">
              <option class="form-control" disabled selected value="Select a company">Select a company</option>
              <option class="form-control" v-for="company in companies" :key="company.id" :value="company.id">{{ company.name }}</option>
            </select>
          </div>
          <div class="mb-3" style="display: flex; justify-content: space-between; align-items: center;">
            <button type="submit" style="display: inline" class="btn btn-primary" font-weight="bold">Add Item</button>
            <router-link to="/item" style="display: inline" class="btn btn-secondary" font-weight="bold">Show Item</router-link>
          </div>
        </form>
      </div>
    </div>
  </template>
  
  <style scoped>
  .background-image {
    background-image: url('https://img.freepik.com/free-vector/flat-design-forest-landscape_23-2149155031.jpg?w=740&t=st=1700149110~exp=1700149710~hmac=7db94f3bb30313dddc9dfb222eb0e08bfafe20986a49cd082efa3a874e019483'); /* Replace with your image URL */
    background-size: cover;
    background-position: center;
    min-height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    backdrop-filter: blur(15px); /* Increased blur effect */
  }
  
  .my-form {
    max-width: 400px;
    margin: auto;
    padding: 20px;
    border: 1px solid #3498db; /* Border color: Blue */
    border-radius: 8px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    background-color: rgba(236, 240, 241, 0.5); /* Light gray with increased opacity */
  }
    

.form-legend {
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 20px;
  color: #290127; /* Legend color: Blue */
}

.form-label {
  font-weight: bold;
  color: #0a2036; /* Label color: Dark gray */
}

.form-control {
  width: 100%;
  padding: 8px;
  margin-bottom: 10px;
  box-sizing: border-box;
  border: 1px solid rgba(189, 195, 199, 0.7); /* Border color with transparency */
  border-radius: 4px;
  background-color: rgba(255, 255, 255, 0.5); /* Adjust the alpha channel for transparency */
}

.btn-primary {
  background-color: rgb(17, 8, 29); /* Button color: Blue */
  color: #f7f3f3;
}

.btn-secondary {
  background-color: rgb(17, 8, 29); /* Button color: Gray */
  color: #eceaea;
}
</style>
