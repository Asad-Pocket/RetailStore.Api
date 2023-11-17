<script setup>
import { ref, onMounted, reactive } from 'vue';
import axios from 'axios';
import { useRouter } from "vue-router";

let formData = reactive({
  Email: null,
  Password: null,
});

const router = useRouter();
const handleSubmit = async () => {
  try {
    const postData = {
      Email: formData.Email,
      Password: formData.Password,
    };

    const response =  await axios.post("https://localhost:7001/api/Account/login", postData);
    if(response.status == 200)
    {
        localStorage.setItem("token",response.data)
    }
    console.log(localStorage.getItem("token"));
  } catch (error) {
    console.error("Error submitting form:", error);
  }

  router.push("./")
};


</script>

<template>
    <div class="background-image">
      <div class="container">
        <form @submit.prevent="handleSubmit" class="my-form">
            <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px;">
                <legend class="form-legend" >Login</legend>
            </div>
          <div class="mb-3">
            <label for="Email" class="form-label">Email</label>
            <input type="text" class="form-control" id="Email" v-model="formData.Email">
          </div>
          <div class="mb-3">
            <label for="Password" class="form-label">Password</label>
            <input type="password" class="form-control" id="Password" v-model="formData.Password">
          </div>
          <div class="mb-3" style="display: flex; justify-content: space-between; align-items: center;">
            <button type="submit" style="display: inline" class="btn btn-primary" font-weight="bold">Submit</button>
            <p class="directLogin" href="" font-weight = "bold" >Do not have an account? <a href="/register">Create new account</a></p>
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
  background-color: rgb(25, 8, 46); /* Button color: Blue */
  font-weight: bold;
  color: #f7f3f3;
}
.directLogin{
    font-weight: bold;
    padding: auto;
    margin: 10px;
}

</style>
