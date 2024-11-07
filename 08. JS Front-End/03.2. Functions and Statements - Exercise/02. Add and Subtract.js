function addAndSubtract(a, b, c){

    console.log(subtract(sum(a,b),c));

    function sum(numberOne, numberTwo){
        return numberOne + numberTwo;
    }

    
    function subtract(numberOne, numberTwo){
        return numberOne - numberTwo;
    }
    
}

addAndSubtract(23, 6, 10);