function factorialDivision(firstNumber, secondNumber){

    let firstFactorials = getFactorial(firstNumber);
    let secondFactorials = getFactorial(secondNumber);
    console.log((firstFactorials / secondFactorials).toFixed(2));

    function getFactorial(number){
        if(number <= 1){
            return 1;
        }

        return number * getFactorial(number - 1);
    }
}

factorialDivision(5,2);