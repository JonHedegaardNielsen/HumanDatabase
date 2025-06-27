<script setup>
import {ref, onMounted} from 'vue'
import Person from './Person.vue'


const APIURL = "https://localhost:7137/Person"
const people = ref([
])

onMounted(async() => {
  const response = await fetch(APIURL, {
    method : "GET",
    headers: {
            'Accept': 'application/json',
            "Content-Type": "application/json"
        },
  })
  const responseParsed = await response.json()
  const dateToday = new Date()

  Array.from(responseParsed).forEach((person) =>{
    person.dayOfBirth = new Date(person.dayOfBirth)

    let yearDifference = dateToday.getFullYear() -  person.dayOfBirth.getFullYear();

    if (
      dateToday.getMonth() < person.dayOfBirth.getMonth() || 
      (dateToday.getMonth() === person.dayOfBirth.getMonth() && dateToday.getDate() < person.dayOfBirth.getDate())
    ) 
    {
      yearDifference--;
    }

    person.age = yearDifference
    people.value.push(person)
  }
    
  )
})

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
    background-color: blue;
  }
  div.personContainer{
    display: inline-block;
    margin-left: 10px;
    margin-right: 10px;
    margin-top: 20px;
  }
</style>