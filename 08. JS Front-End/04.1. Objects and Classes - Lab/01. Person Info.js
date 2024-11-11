function personInfoToObject(firstName, lastName, age){
    let personInfo = {
        firstName,
        lastName,
        age,
    };

    return personInfo;
}

console.log(personInfoToObject("Peter", "Pan", "20"));