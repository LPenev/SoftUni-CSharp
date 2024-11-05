function extractHashTags(text){
    const pattern = /#([A-Za-z]+)/g;
    let matches = text.matchAll(pattern);

    for(const match of matches){
        console.log(match[1]);
    }
}

extractHashTags('Nowadays everyone uses # to tag a #special word in #socialMedia');