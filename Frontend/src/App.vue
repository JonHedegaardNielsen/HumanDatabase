<script setup>
import {ref} from 'vue'
import HomePage from './components/HomePage.vue'
import SubmitPersonPage from './components/SubmitPersonPage.vue'


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
    background-color: rgb(89, 89, 89);
    width: 100%;
    height: 70px;
    padding: 5px;
  }

  nav button{
    background-color: rgba(0, 0, 0, 0.071);
    border-color: black;
    font-size: 42px;
    height: 100%;
    margin: 0;
    box-shadow: 5px;
    margin-right: 15px;
    text-align: center;
  }

  nav button:hover{
    background-color: rgba(0, 0, 0, 0.16);
  }

  #currentPageComponent{
  }
</style>
