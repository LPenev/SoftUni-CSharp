function sortingNumbers(numbersArray){
    numbersArray.sort((a,b)=>a-b);
    let result = [];
    while(numbersArray.length > 0){
        result.push(numbersArray.shift());
        
        if(numbersArray.length > 0){
            result.push(numbersArray.pop());
        }
    }
    return result;
}

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));