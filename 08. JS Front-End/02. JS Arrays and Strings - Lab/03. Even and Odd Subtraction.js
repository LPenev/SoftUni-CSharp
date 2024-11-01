function evenAndOddSubtraction(inputArray){
    let sumOdd = 0;
    let sumEven = 0;

    for(let i=0;i< inputArray.length-1;i++){
        if(inputArray[i]%2 !== 0){
            sumOdd += inputArray[i];
        } else {
            sumEven += inputArray[i];
        }
    }

    console.log(sumOdd - sumEven);
}

evenAndOddSubtraction([1,2,3,4,5,6]);