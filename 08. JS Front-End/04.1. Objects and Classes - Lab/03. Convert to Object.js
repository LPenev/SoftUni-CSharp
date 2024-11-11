function jsonToObject(jsonString){
    let obj = JSON.parse(jsonString);

    printObjectInfo(obj);

    function printObjectInfo(objectInfo){
        for( let key in objectInfo){
            console.log(`${key}: ${objectInfo[key]}`);
        }
    }
}

jsonToObject('{"name": "George", "age": 40, "town": "Sofia"}');