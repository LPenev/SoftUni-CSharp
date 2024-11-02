function countStringOccurrences(text, word){
    let words = text.split(' ');
    let counter = 0;

    for(let currentWord of words){
        if(currentWord === word){
            counter++
        }
    }
    console.log(counter);
}

countStringOccurrences('This is a word and it also is a sentence',
'is'
);