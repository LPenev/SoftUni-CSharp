function nElementOfArray(inputArray, step){
    let counter = step;
    let resultArray = [];
    for(let currentElement of inputArray){
        if(counter === step){
            resultArray.push(currentElement);
            counter = 1;
        }else{
            counter++;
        }
    }
    return resultArray;
}

console.log(nElementOfArray(['5', '20', '31', '4', '20'], 2));