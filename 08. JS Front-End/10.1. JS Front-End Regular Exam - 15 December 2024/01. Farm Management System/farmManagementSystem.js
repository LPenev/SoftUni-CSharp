function farmer(input){
    farmerCount = Number(input.shift());
    
    let farmers = {};

    for(let i=0; i < farmerCount; i++){
        const current = input.shift().split(' ');
        fName = current[0];
        workArea = current[1];
        tasks = current[2].split(',');

        farmers[fName] = { workArea: workArea, tasks: tasks };
    }

    while(input.length > 0){
        const currentCommand = input.shift().split('/').map(x=> x.trim());
        
        if(currentCommand[0] === 'End'){
            continue;
        }

        switch(currentCommand[0]){
            case 'Execute':
                execute(currentCommand[1], currentCommand[2], currentCommand[3]);
                break;
            case 'Change Area':
                changeArea(currentCommand[1], currentCommand[2]);
                break;
            case 'Learn Task':
                learnTask(currentCommand[1], currentCommand[2]);
                break;
        }
    }

    printAllfarmers(farmers);

    function printAllfarmers(farmers){
        for(const farmerName of Object.keys(farmers)){
            const farmer = farmers[farmerName];
            let tasks = farmer.tasks.sort();
            console.log(`Farmer: ${farmerName}, Area: ${farmer.workArea}, Tasks: ${tasks.join(', ')}`);
        }
    }

    function execute(farmerName, workArea, task){
        const farmer = farmers[farmerName];
        
        if(farmer.workArea === workArea && farmer.tasks.includes(task)){
            console.log(`${farmerName} has executed the task: ${task}!`);
        }else{
            console.log(`${farmerName} cannot execute the task: ${task}.`);
        }
    }

    function changeArea(farmerName, newWorkArea){
        farmers[farmerName].workArea = newWorkArea;
        console.log(`${farmerName} has changed their work area to: ${newWorkArea}`);
    }

    function learnTask(farmerName, newTask){

        if(farmers[farmerName].tasks.includes(newTask)){
            console.log(`${farmerName} already knows how to perform ${newTask}.`);
        }else{
            farmers[farmerName].tasks.push(newTask);
            console.log(`${farmerName} has learned a new task: ${newTask}.`);
        }
    }

}

const input = [
    "2",
    "John garden watering,weeding",
    "Mary barn feeding,cleaning",
    "Execute / John / garden / watering",
    "Execute / Mary / garden / feeding",
    "Learn Task / John / planting",
    "Execute / John / garden / planting",
    "Change Area / Mary / garden",
    "Execute / Mary / garden / cleaning",
    "End"
  ];

  farmer(input);
  




