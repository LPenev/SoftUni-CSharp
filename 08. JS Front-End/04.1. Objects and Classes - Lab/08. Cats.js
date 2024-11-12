function printCatsInfo(catsDataArray){
    class Cat {
        constructor(name,age){
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    let cats = [];
    for(const currentCat of catsDataArray){
        const [name, age] = currentCat.split(' ');
        cats.push(new Cat(name, age)); 
    }

    cats.forEach((cat) => cat.meow());
}

printCatsInfo(['Candy 1', 'Poppy 3', 'Nyx 2']);