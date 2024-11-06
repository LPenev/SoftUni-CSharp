function repeatString(string, repeatTimes){
    let result ='';
    for(let i=0; i < repeatTimes; i++){
        result = result.concat(string);
    }

    console.log(result);
}

repeatString('asd',3);