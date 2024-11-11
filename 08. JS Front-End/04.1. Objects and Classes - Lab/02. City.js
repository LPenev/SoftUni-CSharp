function printObjectInfo(objectInfo){
    for( let key in objectInfo){
        console.log(`${key} -> ${objectInfo[key]}`);
    }
}

printObjectInfo({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
}
);