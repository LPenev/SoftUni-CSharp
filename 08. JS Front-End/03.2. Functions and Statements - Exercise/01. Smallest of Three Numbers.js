function smalltestOfThreeNumbers(a, b, c){
    let result;
    if(isFirstNumberSmalltest(a,b)){
        isFirstNumberSmalltest(a,c)?result = a:result = c;
    } else {
        isFirstNumberSmalltest(b,c)?result = b:result = c;
    }

    console.log(result);

    function isFirstNumberSmalltest(firstNumber, secondNumber){
        return firstNumber < secondNumber;
    }
}

smalltestOfThreeNumbers(2, 3, 1);