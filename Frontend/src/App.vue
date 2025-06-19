<script setup>
import {ref} from 'vue'
import HomePage from './components/HomePage.vue'
import SubmitPersonPage from './components/SubmitPersonPage.vue'
const content = HomePage



const currentPage = ref(HomePage)
</script>

<template>
  <nav>
    <button @click="currentPage = HomePage">Database</button>
    <button @click="currentPage = SubmitPersonPage">Submit</button>
  </nav>

  <component id="currentPageComponent" :is="currentPage"/>

</template>

<style scoped>
  template{
    background-color: black;
  }

  nav{
    background-color: rgb(71, 75, 75);
    width: 100%;
    height: 70px;
  }

  nav button{
    background-color: transparent;
    border-color: transparent;
    font-size: 42px;
    height: 100%;
    text-align: center;
  }

  #currentPageComponent{
  }
</style>
