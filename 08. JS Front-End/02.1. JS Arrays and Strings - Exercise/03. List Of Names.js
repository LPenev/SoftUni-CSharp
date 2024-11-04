function listOfNames(names){
    let counter = 0;
    for(let currentName of names.sort((a,b)=>a.localeCompare(b))){
        console.log(`${++counter}.${currentName}`);
    }
}

listOfNames(["John", "Bob", "Christina", "Ema"]);