function stringSubstring(searchedWord, text){
    isFinded = (text.toLocaleLowerCase().split(' ').includes(searchedWord.toLocaleLowerCase()));
    let result;

    if(isFinded){
        result = searchedWord;
    } else {
        result = `${searchedWord} not found!`;
    }
    console.log(result);
}

stringSubstring('javascript','JavaScript is the best programming language');