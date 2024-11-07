function simpleCalculator(firstNumber, secondNumber, operator){
    const operations = {
        multiply: (a,b)=> a * b,
        divide: (a,b)=> a / b,
        add: (a,b)=> a + b,
        subtract: (a,b)=> a - b,
    }

    console.log(operations[operator](firstNumber, secondNumber));
}

simpleCalculator(5, 5, 'multiply');