<script setup>
import {ref, onMounted} from 'vue'
import Person from './Person.vue'

const APIURL = "https://localhost:7137/Person"
const people = ref([])

const searchOpen = ref(false)
const firstName = defineModel('firstName')
const lastName = defineModel('lastName')
const age = defineModel('age')
const dayOfBirth = defineModel('dayOfBirth')
const weigth = defineModel('weigth')
const heigth = defineModel('heigth')
const gender = defineModel('gender')

function loadPeople(peopleToLoad){
  people.value = []

  peopleToLoad.forEach((person) =>{
    if (person.gender === 0){
      person.gender = "Male"
    }
    else{
      person.gender = "Female"
    }
    people.value.push(person)
  })
}

const search = async() => {
  let url = new URL(`${APIURL}/SearchPerson/SearchParams?`)
  function appendSearchParamIfNotNull(key, value){
    if (value || value === 0){
      url.searchParams.append(key, value)
    }
  }

  appendSearchParamIfNotNull("FirstName", firstName.value)
  appendSearchParamIfNotNull("LastName", lastName.value)
  appendSearchParamIfNotNull("Age", age.value)
  appendSearchParamIfNotNull("DayOfBirth", dayOfBirth.value)
  appendSearchParamIfNotNull("Weight", weigth.value)
  appendSearchParamIfNotNull("Height", heigth.value)
  appendSearchParamIfNotNull("Gender", gender.value)

  const response = await fetch(url, {
    method : "GET",
    headers: {
            'Accept': 'application/json',
            "Content-Type": "application/json"
    },
  })

  const responseJSON = await response.json()
  loadPeople(Array.from(responseJSON))
}

onMounted(async() => {
  const response = await fetch(APIURL, {
    method : "GET",
    headers: {
            'Accept': 'application/json',
            "Content-Type": "application/json"
    },
  })

 
  const responseParsed = await response.json()
  

  loadPeople(Array.from(responseParsed));
})

</script>

<template>
  <div>
    <div id="personSearchDiv">
      <div @click="searchOpen = !searchOpen" id="personSearchExpandDiv" @pointerenter="" @pointerleave="">
        <span v-if="!searchOpen">Expand</span>
        <span v-else>Close</span>
      </div>

      <div v-if="searchOpen" id="personSearchInputsDiv" class="personSearchInputs">
        <input placeholder="First name" v-model="firstName" type="text"/>
        <input placeholder="Last name" v-model="lastName" type="text"/>
        <input placeholder="Age" v-model="age" type="number"/>
        <input placeholder="Weight" v-model="weigth" type="number"/>
        <input placeholder="Height" v-model="heigth" type="number"/>
        <input placeholder="Date of birth" v-model="dayOfBirth" type="date"/>
        <select placeholder="Gender" v-model="gender">
          <option value="">None</option>
          <option value="0">Male</option>
          <option value="1">Female</option>
        </select>
        <button @click="search">
          Search
        </button>
      </div>
    </div>
    <div id="peopleContainer">
      <div v-for="person in people" class="personContainer">
        <Person 
            :firstName="person.firstName"
            :lastName="person.lastName"
            :age="person.age"
            :gender="person.gender"
            :height="person.height"
            :weight="person.weight"
            :dayOfBirth="new Date(person.dayOfBirth)">
        </Person>
      </div>
    </div>
  </div>
</template>

<style scoped>
  #personSearchInputsDiv input, select{
    margin: 0px 5% 20px 5%;
    border-radius: 5px;
    padding: 2px;
    background-color: rgb(221, 221, 221);
  }

  #personSearchInputsDiv input::placeholder {
    color: rgb(41, 41, 41);
  }

  #personSearchInputsDiv button{
    margin: 0px 20% 0px 20%;
  }

  #personSearchInputsDiv{
    display: flex;
    flex-direction: column;
    padding-bottom: 10px;
  }

  #personSearchExpandDiv span{
    margin-left: 50%;
    margin-right: 50%;
    font-size: xx-large;
  }

  #personSearchExpandDiv{
    cursor: pointer;
  }

  #personSearchDiv{
    background-color: rgb(89, 89, 89);
    border: 5px rgb(55, 55, 55) solid;
    margin-top: 10px;
    margin-left: 10px;
    margin-right: 10px;
    border-radius: 15px;
  }

  div#peopleContainer{
    width: 100%;
    height: 100%;
  }
  div.personContainer{
    display: inline-block;
    margin-left: 10px;
    margin-right: 10px;
    margin-top: 20px;
  }
</style>