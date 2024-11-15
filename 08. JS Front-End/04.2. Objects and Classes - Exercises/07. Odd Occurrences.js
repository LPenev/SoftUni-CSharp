function oddOccurrences(input){
    let results = {};
    let words = input.split(' ').forEach(word => {
        currentWord = word.toLowerCase();
        if(!results.hasOwnProperty(currentWord)){
            results[currentWord] = 1;
        } else {
            results[currentWord]++;
        }
    });

    const result = Object.entries(results)
        .filter((current)=> current[1]%2 !== 0)
        .map(([word, counter])=>word)
        .join(' ');

    console.log(result)
}

oddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');