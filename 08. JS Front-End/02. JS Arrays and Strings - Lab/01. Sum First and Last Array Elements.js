function sumOfFirstAndLastElement(inputArray){
    let first = inputArray[0];
    let last = inputArray[inputArray.length-1];
    let result = first + last;
    console.log(result);
}

let array = [1,2,3,4,5,6,7,8,9];
sumOfFirstAndLastElement(array);