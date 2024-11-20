// Objects - Structure of related data or functionality
// Object Definition
// const person = {};
const person = { name:'Peter', age:20, height:183 };
// Object set und modify
person.city = 'Sofia';
person['city'] = 'Pleven';
// define function = they called method
let cat = {
    speak: function() {
        console.dir('Mauuu!');
    },

    eat(){
        console.dir('Am am am....');
    }
}

cat.speak();
cat.eat();

// define funtion to already object
person.sayHello = (txt) => {
    console.dir(`Hello, ${txt}`);
};
person.sayHello('Ivan');

// Objects build-in methods
console.log(Object.keys(person));
console.log(Object.values(person));
console.log(Object.entries(person));
// loop
console.dir('---loop---');
for([key, value] of Object.entries(person)){
    console.dir(`${key} - ${value}`);
}
