function carParkingCheck(input){
    const parking = new Set();

    for(const row of input){
        const [direction, carNumber] = row.split(', ');
        
        if(direction === 'IN') {
            parking.add(carNumber);
        }else if(direction === 'OUT'){
            parking.delete(carNumber);
        }
    }

    if(parking.size > 0){
        Array.from(parking)
            .sort((a,b) => a.localeCompare(b))
            .forEach((number)=>console.log(number));
    } else {
        console.log('Parking Lot is Empty');
    }
}

carParkingCheck(
    ['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA']
        
);

// carParkingCheck(
//     ['IN, CA2844AA',
//     'IN, CA1234TA',
//     'OUT, CA2844AA',
//     'IN, CA9999TT',
//     'IN, CA2866HI',
//     'OUT, CA1234TA',
//     'IN, CA2844AA',
//     'OUT, CA2866HI',
//     'IN, CA9876HH',
//     'IN, CA2822UU']
//     );