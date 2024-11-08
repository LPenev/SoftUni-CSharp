function oddAndEvenSum(number){
    let sumEven = 0;
    let sumOdd = 0;
    let numbers = number.toString().split('').map(Number);

    for(let current of numbers){
        isEven(current)?sumEven+=Number(current):sumOdd+=Number(current);
    }

    console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`);

    function isEven(a){
        return (a%2 !== 0)?false:true;
    }
}

oddAndEvenSum(1000435);