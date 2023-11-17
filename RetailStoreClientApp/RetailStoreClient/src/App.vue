<script setup>
import { ref, watchEffect } from 'vue';
import { RouterLink, RouterView } from 'vue-router';

const isAuthenticated = ref(localStorage.getItem('token') !== null);

watchEffect(() => {
  isAuthenticated.value = localStorage.getItem('token') !== null;
});

const handleLogout = () => {
  localStorage.removeItem('token');
};
</script>

<template>
  <nav class="navhandle" data-bs-theme="dark">
    <div class="navbarhandle">
      <a class="navbar-brand main-link" href="/">RetailStore</a>
      <div class="content">
        <a class="navbar-brand main-link" href="/getdata">GetData</a>
      </div>
      <div class="nav-links">
        <a v-if="isAuthenticated" class="navbar-brand nav-link" href="../item">Items</a>
        <a v-if="isAuthenticated" class="navbar-brand nav-link" href="../Company/Details">Companies</a>
      </div>
    </div>
    <div class="auth-section">
      <RouterLink v-if="!isAuthenticated" class="navbar-brand" to="/login">Login</RouterLink>
      <a v-else class="navbar-brand" @click="handleLogout" href="/">Logout</a>
    </div>
  </nav>

  <div class="Container">
    <RouterView />
  </div>
</template>

<style>
.navhandle {
  display: flex;
  justify-content: space-between;
  background-color: rgb(53, 53, 100);
  padding: 15px;
  color: aliceblue;
  padding-inline: 30px;
}

.content {
  font-size: 0.5rem; /* Adjust the font size */
  font-weight: 700;

  margin-left: 20px; /* Adjust the margin-left */
}

.navbarhandle {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.main-link {
  font-size: 1.7rem;
  font-weight: bold;
}

.nav-links {
  display: flex;
  align-items: center;
  margin-left: 20px; /* Adjust as needed */
}

.nav-link {
  font-size: 1.2rem;
  font-weight: bold;
  margin-right: 20px; /* Adjust as needed */
}

.auth-section {
  font-size: large;
  font-weight: 800;
  display: flex;
  align-items: center;
}
</style>
