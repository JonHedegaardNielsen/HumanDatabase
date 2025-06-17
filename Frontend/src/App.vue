<script setup>
import {ref} from 'vue'
import Person from './components/Person.vue'

const people = ref([
  {firstName: 'Jon', lastName: 'Nielsen', age: 18, gender: 'Male',  height: 200, weight: 110},
  {firstName: 'Jon', lastName: 'Nielsen', age: 18, gender: 'Male',  height: 200, weight: 110},
  {firstName: 'Jon', lastName: 'Nielsen', age: 18, gender: 'Male',  height: 200, weight: 110},
  {firstName: 'Jon', lastName: 'Nielsen', age: 18, gender: 'Male',  height: 200, weight: 110},
  {firstName: 'Jon', lastName: 'Nielsen', age: 18, gender: 'Male',  height: 200, weight: 110},
  {firstName: 'Jon', lastName: 'Nielsen', age: 18, gender: 'Male',  height: 200, weight: 110},
])

</script>

<template>
  <div id="peopleContainer">
    <div v-for="person in people" class="personContainer">
      <Person 
          :firstName="person.firstName"
          :lastName="person.lastName"
          :age="person.age"
          :gender="person.gender"
          :height="person.height"
          :weight="person.weight">
      </Person>
    </div>
  
  </div>
</template>

<style scoped>
  div#peopleContainer{
    width: 100%;
    height: 100%;
    background-color: aqua;
  }
  div.personContainer{
    display: inline-block;
    margin-left: 7px;
    margin-right: 7px;
  }

  template{
    background-color: black;
  }
</style>
