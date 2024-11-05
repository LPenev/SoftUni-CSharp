function pascalCaseSplitter(text = ''){
    const pattern = /([A-Z][a-z]*)/g;
    const matches = text.matchAll(pattern);

    let result = Array.from(matches).map(match => match[0]);

    console.log(result.join(', '));
}

pascalCaseSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan');