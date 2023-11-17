<script setup>
import axios from 'axios';

</script>

<template>
  <div class="background">
    <div class="Home">
      <div class="row">
        <div class="col-md-6">
          <div class="card mb-4 h-100">
            <img src="https://www.dtlr.com/cdn/shop/articles/D14A1851_1200x1200.jpg?v=1677706091" class="card-img-top img-fluid" alt="Product 1">
            <div class="card-body">
              <h5 class="card-title">Air Jordan 5 Retro</h5>
              <p class="card-text">This Air Jordan 5 Retro is available in our store. This is a Sneakers BD's product. You can also visit our <a href="./">website</a>. We have 1000 pieces in our stock, and we will be re-ordering as we get close to 100 pieces.</p>
            </div>
            <div class="card-footer">
              <small class="text-body-secondary">Last updated 3 mins ago</small>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="card mb-4 h-100">
            <img src="https://gadgetnmusic.com/wp-content/uploads/2023/10/HK9-Ultra-2-AMOLED-Smartwatch-with-ChatGPT.jpg" class="card-img-top img-fluid" alt="Product 2">
            <div class="card-body">
              <h5 class="card-title">Haylou LS02</h5>
              <p class="card-text">This Haylou LS02 is available in our store. This is a Time-Access's product. You can also visit our <a href="./">website</a>. We have 1000 pieces in our stock, and we will be re-ordering as we get close to 100 pieces.</p>
            </div>
            <div class="card-footer">
              <small class="text-body-secondary">Last updated 3 mins ago</small>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style>
.background {
  background-image: url('https://img.freepik.com/free-vector/flat-design-forest-landscape_23-2149155031.jpg?w=740&t=st=1700085486~exp=1700086086~hmac=c863e69790bb87946a6602f6ccf64e3b3329ef83f5fbced1dfcd0655339b1545');
  background-size: cover;
  background-position: center;
  backdrop-filter: blur(5px);
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 0;
}

.Home {
  display: inline;
  padding: auto;
}

.card {
  width: 50%; /* Adjusted width to make it slightly wider */
  height: 30%; /* Adjusted height to make it shorter */
}

.img-fluid {
  max-width: 100%;
  height: 100%;
}
</style>