function arrayRotation(inputArray, numberOfRotation){
    for(let i=0; i < numberOfRotation; i++){
        let firstElement = inputArray.shift();
        inputArray.push(firstElement);
    }

    console.log(inputArray.join(' '));
}

arrayRotation([51, 47, 32, 61, 21], 2);