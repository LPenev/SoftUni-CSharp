function crewManagement(input) {
    astronautCount = Number(input.shift());
    
    let astronauts = {};

    for(let i=0; i < astronautCount; i++){
        const current = input.shift().split(' ');
        fName = current[0];
        spacecraftSection = current[1];
        skills = current[2].split(',');

        astronauts[fName] = { spacecraftSection, skills: skills };
    }

    while(input.length > 0){
        const currentCommand = input.shift().split('/').map(x=> x.trim());
        
        if(currentCommand[0] === 'End'){
            continue;
        }

        switch(currentCommand[0]){
            case 'Perform':
                perform(currentCommand[1], currentCommand[2], currentCommand[3]);
                break;
            case 'Transfer':
                transfer(currentCommand[1], currentCommand[2]);
                break;
            case 'Learn Skill':
                learn(currentCommand[1], currentCommand[2]);
                break;
        }
    }

    function perform(astronautName, spacecraftSection, skill){
        const astronaut  = astronauts[astronautName];
        
        if(astronaut.spacecraftSection === spacecraftSection && astronaut.skills.includes(skill)){
            console.log(`${astronautName} has successfully performed the skill: ${skill}!`);
        }else{
            console.log(`${astronautName} cannot perform the skill: ${skill}.`);
        }
    }

    function transfer(astronautName, newSpacecraftSection){
        astronauts[astronautName].spacecraftSection = newSpacecraftSection;
        console.log(`${astronautName} has been transferred to: ${newSpacecraftSection}`);
    }

    function learn(astronautName, newSkill){

        if(astronauts[astronautName].skills.includes(newSkill)){
            console.log(`${astronautName} already knows the skill: ${newSkill}.`);
        }else{
            astronauts[astronautName].skills.push(newSkill);
            console.log(`${astronautName} has learned a new skill: ${newSkill}.`);
        }
    }

    printAllfarmers(astronauts);

    function printAllfarmers(astronauts){
        for(const astronautName of Object.keys(astronauts)){
            const astronaut = astronauts[astronautName];
            let skills = astronaut.skills.sort();
            console.log(`Astronaut: ${astronautName}, Section: ${astronaut.spacecraftSection}, Skills: ${skills.join(', ')}`);
        }
    }
}

const input = [
    "2",
  "Alice command_module piloting,communications",
  "Bob engineering_bay repair,maintenance",
  "Perform / Alice / command_module / piloting",
  "Perform / Bob / command_module / repair",
  "Learn Skill / Alice / navigation",
  "Perform / Alice / command_module / navigation",
  "Transfer / Bob / command_module",
  "Perform / Bob / command_module / maintenance",
  "End"
];

// input1 erwartet output
// Alice has successfully performed the skill: piloting!
// Bob cannot perform the skill: repair.
// Alice has learned a new skill: navigation.
// Alice has successfully performed the skill: navigation!
// Bob has been transferred to: command_module
// Bob has successfully performed the skill: maintenance!
// Astronaut: Alice, Section: command_module, Skills: communications, navigation, piloting
// Astronaut: Bob, Section: command_module, Skills: maintenance, repair


const input2 = [
    "3",
    "Tom engineering_bay construction,maintenance",
    "Sara research_lab analysis,sampling",
    "Chris command_module piloting,communications",
    "Perform / Tom / engineering_bay / construction",
    "Learn Skill / Sara / robotics",
    "Perform / Sara / research_lab / robotics",
    "Transfer / Chris / research_lab",
    "Perform / Chris / research_lab / piloting",
    "Learn Skill / Tom / diagnostics",
    "Perform / Tom / engineering_bay / diagnostics",
    "End"
  ];
// input2 erwartet output
// Tom has successfully performed the skill: construction!
// Sara has learned a new skill: robotics.
// Sara has successfully performed the skill: robotics!
// Chris has been transferred to: research_lab
// Chris has successfully performed the skill: piloting!
// Tom has learned a new skill: diagnostics.
// Tom has successfully performed the skill: diagnostics!
// Astronaut: Tom, Section: engineering_bay, Skills: construction, diagnostics, maintenance
// Astronaut: Sara, Section: research_lab, Skills: analysis, robotics, sampling
// Astronaut: Chris, Section: research_lab, Skills: communications, piloting

  
crewManagement(input);