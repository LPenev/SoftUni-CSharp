function charactersInRange(startChar, endChar){
    let chars = printCharactersRange(startChar, endChar);
    console.log(chars);

    function printCharactersRange(a,b){
        let startOfRange = getAsciiValue(a);
        let endOfRange = getAsciiValue(b);
        let result = '';
        
        if(startOfRange > endOfRange){
            const temp = startOfRange;
            startOfRange = endOfRange;
            endOfRange = temp;
        }

        for(let i = ++startOfRange; startOfRange < endOfRange; startOfRange++){
            result = result.concat(' ' + asciiToChar(startOfRange));
        }

        return result;
    }

    function asciiToChar(value){
        return String.fromCharCode(value);
    }

    function getAsciiValue(char){
        return char.charCodeAt();
    }
}

charactersInRange('C','#');