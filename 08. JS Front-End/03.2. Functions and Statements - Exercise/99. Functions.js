// Function declaration
function sumTwoNumber(a,b){
    const result = a+b;
    console.dir(result);
}

// Function expression (useful in functional programming)
// The function-expression cannot invoke before initialization
let sumTwoNumbersExpression = function(a,b) {
    const result = a + b;
    console.dir(result);
}

// Invoking Function
sumTwoNumber(5,6);
sumTwoNumbersExpression(6,6);

// Self-invocation (recursion)
countDown(5);
function countDown(x) {
    console.log(x);
    if (x > 0) { countDown(x - 1); }
}

// The Return Statement
const name = fullName('Ivan','Ivanov');
console.dir(name);

function fullName(firstName, lastName){
    const fullName =firstName + ' ' + lastName;
    return fullName;
}

// -= Functional Programming in JS
// -= First Class

const write = function (name) {
    return "Hello, " + name;
}

console.dir(write('Ivan'));

// Arrow Functions
// incremention
let increment = x => x + 1;
console.log(increment(5));  // 6
console.log(increment(increment(5))); // 7
//
let increment2 = function(x) {  return x + 2; }
console.log(increment2(5)); // 7
//
let sum = (a, b) => a + b;
console.log(sum(5, 6));  // 11

let sumX2 = a => {
    let result = a+a;
    result += result;
    return result;
}

console.dir(sumX2(5));