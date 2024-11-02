function printSubstring(inputString, startIndex, elementsCount) {
    let result = inputString.substring(startIndex, startIndex + elementsCount);
    console.log(result);
}

printSubstring('ASentence', 1, 8);
printSubstring('SkipWord', 4, 7);