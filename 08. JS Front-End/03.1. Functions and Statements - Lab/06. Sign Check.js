function signCheck(a, b, c){
    let isNegative = 0 < (a,b,c);
    let result = '';
    isNegative?result = 'Positive':result = 'Negative';
    console.log(result);
}

signCheck(5, 12, -15);