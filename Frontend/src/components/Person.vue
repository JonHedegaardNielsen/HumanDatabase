<script setup>
    import {ref} from 'vue';
    defineProps(['firstName', 'lastName', 'age', 'gender', 'height', 'weight'])

</script>

<template>
    <div id="personBox">
        <img src="../assets/NoImage.png" alt="">
        <span>{{firstName}} {{ lastName }} <br></span>
        <span>age: {{age}} <br></span>
        <span>{{ gender }} <br></span>
        <span>{{ height }} <br></span>
        <span>{{ weight }} <br></span>
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
