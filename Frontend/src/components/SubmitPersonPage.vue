<script setup>

</script>

<template>
    <div>
        <div id="submitionBox">
            <div class="submitionSection">
                <span>First Name</span> <br>
                <input placeholder="First Name" /> <br>
                <span>Last Name</span> <br>
                <input placeholder="Last Name" />
            </div>

            <div class="submitionSection">
                <span>Day of Birth</span> <br>
                <input placeholder="Day of Birth" type="date" />
            </div>

            <div class="submitionSection">
                <span>Weight</span><br>
                <input placeholder="Weight" type="number" /><br>
                <span>Height</span><br>
                <input placeholder="Height" type="number" />
            </div>

            <div class="submitionSection">
                <span>Gender</span><br>
                <select>
                    <option value="">Choose an option</option>
                    <option value="male">Male</option>
                    <option value="female">Female</option>
                </select>
            </div>

            <button id="submitButton">
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