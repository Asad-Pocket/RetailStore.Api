<script>
import axios from 'axios';

export default {
  data() {
    return {
      productList: [],
    };
  },
  mounted() {
    this.fetchProductList();
  },
  methods: 
  {
    async fetchProductList() {
      try {
        const response = await axios.get('https://www.pqstec.com/InvoiceApps/values/GetProductListAll');
        this.productList = response.data;
      } catch (error) {
        console.error('Error fetching product list:', error);
      }
    },
    downloadCSV() {
      const csvContent = this.convertToCSV(this.productList);
      this.downloadFile(csvContent, 'product_list.csv');
    },
    convertToCSV(data) {
      const header = Object.keys(data[0]).join(',');
      const rows = data.map(product => Object.values(product).join(','));
      return [header, ...rows].join('\n');
    },
    downloadFile(content, fileName) {
      const blob = new Blob([content], { type: 'text/csv' });
      const link = document.createElement('a');
      link.href = window.URL.createObjectURL(blob);
      link.download = fileName;
      link.click();
    },
  },
};
</script>

<template>
    <div class="background-image">
      <div class="content-container">
        <h1 class="title">Product List</h1>
        <div class="table-container">
          <table>
            <thead>
              <tr>
                <th style="width: 35%;">Name</th>
                <th style="width: 30%;">Product Code</th>
                <th style="width: 25%;">Product Barcode</th>
                <th style="width: 25%;">Price</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="product in productList" :key="product.ProductId">
                <td>{{ product.Name }}</td>
                <td>{{ product.Code }}</td>
                <td>{{ product.ProductBarcode }}</td>
                <td>{{ product.Price }}</td>
              </tr>
            </tbody>
          </table>
        </div>
        <button @click="downloadCSV" class="download-btn" >Download CSV</button>
      </div>
    </div>
  </template>
  
  <style scoped>
.background-image {
  background-image: url('https://img.freepik.com/free-vector/flat-design-forest-landscape_23-2149155031.jpg?w=740&t=st=1700149110~exp=1700149710~hmac=7db94f3bb30313dddc9dfb222eb0e08bfafe20986a49cd082efa3a874e019483');
  background-size: cover;
  background-position: center;
  
  align-items: flex-start;
  backdrop-filter: blur(30px);
}
.content-container {
  max-width: 100%; /* Adjust max-width for wider content */
  margin: auto;
  padding: 20px;
}

.table-container {
  max-height: 500px;
  max-width: 70%;
  overflow-y: auto;
  border: 3px solid #2b0a31;
  background-color: rgba(255, 255, 255, 0.5);
}
table {
  width: 100%;
  margin: 0px auto;
  border-collapse: collapse;
  border: 3px solid #2b0a31;
}
.title {
  color: #f7f5f5;
  font-weight: bold;
  padding: auto;
}
th, td {
  padding: 7px;
  text-align: left;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

th {
  background-color: #221130;
  color: rgb(255, 255, 255);
}

tr:nth-child(even) {
  background-color: #f2f2f2cc;
}

tr:hover {
  background-color: #5fa9db;
  color: #ffffff;
}

.table-container::-webkit-scrollbar {
  width: 8px;
}

.table-container::-webkit-scrollbar-thumb {
  background-color: #bec5ca;
}

.download-btn {
  background-color: #173b53;
  color: #ffffff;
  padding: 10px;
  margin-top: 20px;
  cursor: pointer;
  border: none;
  border-radius: 4px;
  font-weight: bold;
}
</style>

