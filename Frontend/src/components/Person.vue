<script setup>
    import {ref} from 'vue';
    defineProps(['firstName', 'lastName', 'age', 'gender', 'height', 'weight', 'dayOfBirth'])

</script>

<template>
    <div id="personBox">
        <img src="../assets/NoImage.png" alt="">
        <span>{{firstName}} {{ lastName }} <br></span>
        <span>age: {{age}} <br></span>
        <span>gender: {{ gender }} <br></span>
        <span>height: {{ height }} <br></span>
        <span>weight: {{ weight }} <br></span>
        <span>dayOfBirth: {{ dayOfBirth.getDate() }}-{{ dayOfBirth.getMonth()  }}-{{ dayOfBirth.getFullYear() }} <br></span>
    </div>
</template>

<style scoped>
div#personBox{
    background-color: black;
    width: 150px;
    border-radius: 5px;
}
#personBox img{
    border-top-left-radius: 5px;
    border-top-right-radius: 5px;
    height: 60%;
    width: 100%;
}
</style>
