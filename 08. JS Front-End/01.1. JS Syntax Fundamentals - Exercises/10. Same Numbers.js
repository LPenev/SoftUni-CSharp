function sameNumbers(number) {
    let numbers = number.toString();
    let sum = 0;

    let isEqual = true;
    for(let i=1; i < numbers.length; i++){
        isEqual = (numbers[i-1] === numbers[i]);
        if(isEqual === false) {
            break;
        }
    }

    for(let i=0; i < numbers.length; i++){
        sum += Number(numbers[i]);
    }
    console.log(`${isEqual}\n${sum}`);
}

sameNumbers(2222222);
sameNumbers(1234);