<script setup>
import {ref, defineModel} from 'vue'
const APIURL = "https://localhost:7137/Person"

const submit = async() =>
{
    const person = {
            "firstName" : firstName.value,
            "lastName" : lastName.value,
            "dayOfBirth" : dayOfBirth.value,
            "weight" : parseInt(weigth.value),
            "height" : parseInt(heigth.value),
            "gender" : parseInt(gender.value)
    }

    console.log(person)

    await fetch(APIURL, {
        method : "POST",
        headers: {
            'Accept': 'application/json',
            "Content-Type": "application/json"
        },
        body : JSON.stringify(person)
    })
}

const firstName = defineModel('firstName')
const lastName = defineModel('lastName')
const dayOfBirth = defineModel('dayOfBirth')
const weigth = defineModel('weigth')
const heigth = defineModel('heigth')
const gender = defineModel('gender')
</script>

<template>
    <div>
        <div id="submitionBox">
            <div class="submitionSection">
                <span>First Name</span> <br>
                <input placeholder="First Name" v-model="firstName"/> <br>
                <span>Last Name</span> <br>
                <input placeholder="Last Name" v-model="lastName" />
            </div>

            <div class="submitionSection">
                <span>Day of Birth</span> <br>
                <input placeholder="Day of Birth" type="date" v-model="dayOfBirth" />
            </div>

            <div class="submitionSection">
                <span>Weight</span><br>
                <input placeholder="Weight" type="number" v-model="weigth" /><br>
                <span>Height</span><br>
                <input placeholder="Height" type="number" v-model="heigth" />
            </div>

            <div class="submitionSection">
                <span>Gender</span><br>
                <select v-model="gender">
                    <option value="">Choose an option</option>
                    <option value="0">Male</option>
                    <option value="1">Female</option>
                </select>
            </div>

            <button @click="submit" id="submitButton">
                Submit
            </button>
        </div>
    </div>
</template>

<style scoped>

.submitionSection{
    padding-bottom: 50px;
}

#submitButton{
    margin-left: 30%;
    margin-right: 50%;
    width: 40%;
    margin-bottom: 50px;
    height: 50px;
    background-color: black;
    color: rgb(182, 182, 182);
    font-size: 32px;
}

#submitionBox {
    padding: 50px;
    padding-bottom: 10px;
    margin-left: 2%;
    margin-right: 2%;
    margin-top: 20px;
    width: 96%;
    background: rgb(107, 107, 107);
    border-radius: 20px;
}

#submitionBox div {
    display: block;
    width: 100%;
}

#submitionBox input, select{
    background-color: black;
    color: gray;
    margin-top: 20px;
    border-width: 0;
    border-radius: 4px;
    padding: 4px;
    width: 50%;
    margin-bottom: 30px;
}

#submitionBox input:focus{
    color: white;
    outline: none;
}

#submitionBox select:focus{
    color: white;
}
</style>