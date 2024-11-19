function solve() {
    const inputElement = document.getElementById('input');
    const selectMenuToElement = document.getElementById('selectMenuTo');
    const outputElement = document.getElementById('result');

    const convertors = {
        binary: decimalToBinary,
        hexadecimal: decimalToHexadecimal,
    }

    outputElement.value = convertors[selectMenuToElement.value](inputElement.value);
    
    function decimalToBinary(number){
        result = Number(number).toString(2);
        return result;
    }

    function decimalToHexadecimal(number){
        result = Number(number).toString(16).toUpperCase();
        return result;
    }
}