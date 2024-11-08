function palindromeInegers(numbers){
    for (let currentNumber of numbers){
        console.log(isPalindrome(currentNumber));
    }

    function isPalindrome(number){
        let forwardNumber = number.toString();
        let reversedNumber = number.toString().split('').reverse().join('');
        return forwardNumber === reversedNumber;
    }
}

palindromeInegers([123,323,421,121]);