function wordsTracker(input){
    const words = input
        .shift()
        .split(' ')
        //.reduce((result, word)=>({...result, [word]: 0}),{});
        .reduce((result, word)=> {
            result[word] = 0;
            return result;
        },{});

        input.forEach((word)=> {
            (words.hasOwnProperty(word))?words[word] += 1:'';
        });

    Object.entries(words)
    .sort((a, b) => b[1] - a[1])
    .forEach(([word,score])=> console.log(`${word} - ${score}`));
}

wordsTracker(
    [
        'this sentence', 
        'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]        
);