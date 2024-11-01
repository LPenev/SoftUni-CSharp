function reverseArrayOfNumbers(n,inputArray){
    let newArray = [];
    for(let i=0; i < n; i++){
        newArray.push(inputArray[i]);
    }
    let reversedArray = newArray.reverse();
    console.log(reversedArray.join(" "));
}

reverseArrayOfNumbers(3, [10, 20, 30, 40, 50]);