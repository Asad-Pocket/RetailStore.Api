<script setup>
import axios from 'axios';
import { reactive, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute();
const router = useRouter();
const token = localStorage.getItem("token");
const edititemdetails = reactive({
  Id: 0,
  Name: '',
});

const handleSubmit = async () => {
  try {
    // Convert the route parameter to an integer
    const itemId = parseInt(route.params.id, 10);

    // Log the request payload to check if it's correct
    console.log("Request Payload:", {
      Id: itemId,
      Name: edititemdetails.Name,
    });
    const postData = {
      CompanyId : itemId,
      Name: edititemdetails.Name,
    };
    console.log("Request Payload:", {
      Id: postData.CompanyId,
      Name: postData.Name,
    });

    // Make a PUT request to update the existing item
    await axios.put(`https://localhost:7001/api/companies/${itemId}`,postData,{
            headers:{
              Authorization:`Bearer ${token}`
            }
        });

    // Redirect to the item list page after a successful update
    router.push('/company/details');
  } catch (error) {
    console.error("Error updating item:", error);
    if (error.response) {
      console.error("Response data:", error.response.data);
    }
  }
};

onMounted(() => {
  // Fetch item details, including the associated company
  axios.get(`https://localhost:7001/api/companies/${route.params.id}`,{
            headers:{
              Authorization:`Bearer ${token}`
            }
        })
    .then((response) => {
      const data = response.data;

      // Set item details
      edititemdetails.Id = data.id;
      edititemdetails.Name = data.name;
    })
    .catch((error) => {
      console.error("Error fetching item details:", error);
    });
});
</script>



<template>
  <div class="background-image">
    <div class="container">
      <form @submit.prevent="handleSubmit" class="my-form">
        <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px;">
          <legend class="form-legend">Update Item</legend>
        </div>
        <div class="mb-3">
          <label for="Name" class="form-label">Name</label>
          <input type="text" class="form-control" id="Name" v-model="edititemdetails.Name">
        </div>
        <div class="mb-3" style="display: flex; justify-content: space-between; align-items: center;">
          <button type="submit" style="display: inline" class="btn btn-primary" font-weight="bold">Update Item</button>
          <router-link to="/company/details" style="display: inline" class="btn btn-secondary" font-weight="bold">Show Item</router-link>
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
  border: 1px solid #bdc3c7; /* Input border color: Light gray */
  border-radius: 4px;
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
