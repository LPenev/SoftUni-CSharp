function mathOperations(num1, num2, operand){
    switch(operand){
        case '+':
            result = num1 + num2;
            break;

        case '-':
            result = num1 - num2;
            break;
        
        case '*':
            result = num1 * num2;
            break;
        
        case '/':
            result = num1 / num2;
            break;
        
        case '%':
            result = num1 % num2;
            break;
        
        case '**':
            result = num1 ** num2;
            break;
    }

    console.log(result);
}

mathOperations(2,2,'+');