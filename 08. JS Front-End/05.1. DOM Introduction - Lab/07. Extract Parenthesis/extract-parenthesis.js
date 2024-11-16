function extract(elementId) {
    const content = document.getElementById(elementId).innerText;
    const pattern = /\(([^)]+)\)/g;
    let result = [];

    let match = pattern.exec(content);
    while(match){
        result.push(match[1]);
        match = pattern.exec(content);
    }

    return result.join('; ');
}