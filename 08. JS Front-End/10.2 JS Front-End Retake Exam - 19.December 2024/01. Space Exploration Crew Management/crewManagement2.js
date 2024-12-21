function crewManagement(input) {
    const n = Number(input.shift());
    const astronauts = {};
    const output = [];

    for (let i = 0; i < n; i++) {
        const [name, section, astronautSkills] = input.shift().split(' ');
        astronauts[name] = {
            section: section,
            skills: astronautSkills ? astronautSkills.split(',') : [],
        };
    }

    for (const command of input) {
        if (command === "End") break;

        const [action, name, arg1, arg2] = command.split(' / ');
        switch (action) {
            case "Perform": {
                const section = arg1;
                const skill = arg2;
                if (astronauts[name].section === section && astronauts[name].skills.includes(skill)) {
                    output.push(`${name} has successfully performed the skill: ${skill}!`);
                } else {
                    output.push(`${name} cannot perform the skill: ${skill}.`);
                }
                break;
            }

            case "Transfer": {
                const newSection = arg1;
                astronauts[name].section = newSection;
                output.push(`${name} has been transferred to: ${newSection}`);
                break;
            }

            case "Learn Skill": {
                const newSkill = arg1;
                if (astronauts[name].skills.includes(newSkill)) {
                    output.push(`${name} already knows the skill: ${newSkill}.`);
                } else {
                    astronauts[name].skills.push(newSkill);
                    output.push(`${name} has learned a new skill: ${newSkill}.`);
                }
                break;
            }
        }
    }

    Object.keys(astronauts).forEach(name => {
        const { section, skills } = astronauts[name];
        skills.sort();
        output.push(`Astronaut: ${name}, Section: ${section}, Skills: ${skills.join(', ')}`);
    });

    console.log(output.join('\n'));
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

crewManagement(input);