function NxNMatrix(number){

    printMatrix(number);

    function printMatrix(number){
        let row = makeRow(number);
        console.log(row.repeat(number));
    }

    function makeRow(number){
        let row = new Array(number).fill(number).join(' ');
        row = row.concat('\n');
        return row;
    }
}

NxNMatrix(2);