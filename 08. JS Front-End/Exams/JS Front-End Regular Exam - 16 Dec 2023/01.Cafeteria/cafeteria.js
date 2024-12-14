function cafeteria(input){
    const baristasCount = Number(input.shift());

    let baristas = {};
        
    for(let i = 0; i< baristasCount; i++){
        const current = input.shift().split(' ');
        bName = current[0];
        shift = current[1];
        drinks = current[2].split(',');

        baristas[bName] = { shift: shift, drinks: drinks };
    }

    
    while(input.length > 0){
        const currentCommand = input.shift().split('/').map(x=> x.trim());
        
        switch(currentCommand[0]){
            case 'Prepare':
                prepare(currentCommand[1], currentCommand[2], currentCommand[3]);
                break;
            case 'Change Shift':
                changeShift(currentCommand[1], currentCommand[2]);
                break;
            case 'Learn':
                learn(currentCommand[1], currentCommand[2]);
                break;
        }

        if(currentCommand[0] === 'Closed'){
            continue;
        }
    }

    printAllBaristas(baristas);

    function printAllBaristas(baristas){
        for(const baristaName of Object.keys(baristas)){
            const barista = baristas[baristaName];
            console.log(`Barista: ${baristaName}, Shift: ${barista.shift}, Drinks: ${barista.drinks.join(', ')}`);
        }
    }

    function prepare(baristaName, shift, coffeeType){
        const barista = baristas[baristaName];
        
        if(barista.shift === shift && barista.drinks.includes(coffeeType)){
            console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
        }else{
            console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
        }
    }

    function changeShift(baristaName, newShift){
        baristas[baristaName].shift = newShift;
        console.log(`${baristaName} has updated his shift to: ${baristas[baristaName].shift}`);
    }

    function learn(baristaName, newCoffeeType){

        if(baristas[baristaName].drinks.includes(newCoffeeType)){
            console.log(`${baristaName} knows how to make ${newCoffeeType}.`);
        }else{
            baristas[baristaName].drinks.push(newCoffeeType);
            console.log(`${baristaName} has learned a new coffee type: ${newCoffeeType}.`);
        }
    }
}

const input = [
    '3',
      'Alice day Espresso,Cappuccino',
      'Bob night Latte,Mocha',
      'Carol day Americano,Mocha',
      'Prepare / Alice / day / Espresso',
      'Change Shift / Bob / night',
      'Learn / Carol / Latte',
      'Learn / Bob / Latte',
      'Prepare / Bob / night / Latte',
      'Closed'];
    
cafeteria(input);