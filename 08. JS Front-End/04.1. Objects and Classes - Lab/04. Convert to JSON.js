function convertToJson(name, lastName, hairColor){
    let person = {
        name,
        lastName,
        hairColor,
    }

    let json = JSON.stringify(person);
    console.log(json);
}

convertToJson('George', 'Jones', 'Brown');