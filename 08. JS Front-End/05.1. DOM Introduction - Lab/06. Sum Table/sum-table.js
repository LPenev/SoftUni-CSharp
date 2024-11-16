function sumTable() {
    // TODO
    const elements = document.querySelectorAll("td + td");
    let sum = 0;
    for(const element of elements){
        sum += Number(element.innerHTML);
    }

    const sumElement = document.getElementById("sum").innerText = sum;
}