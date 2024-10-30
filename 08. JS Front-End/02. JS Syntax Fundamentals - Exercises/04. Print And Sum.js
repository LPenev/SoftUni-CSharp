function printSum(start, end) {
    let numbers = '';
    let sum = 0;

    for( let i = start; i <= end; i++){
        numbers += `${i} `;
        sum += i;
    }

    console.log(numbers.trimEnd());
    console.log(`Sum: ${sum}`);
}

printSum(5,10);