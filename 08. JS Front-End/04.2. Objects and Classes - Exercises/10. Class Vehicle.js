class Vehicle{
    #parts = {};

    constructor(type, model, parts, fuel){
        this.type = type;
        this.model = model;
        this.parts = parts;
        this.fuel = fuel;
    }

    set parts(value) {
        this.#parts = {
            engine: value.engine,
            power: value.power,
            quality: value.engine * value.power,
        }
    }

    get parts() {
        return this.#parts;
    }

    drive(fuelloss){
        this.fuel -= fuelloss;
    }
}

let parts = { engine: 6, power: 100 };
let vehicle = new Vehicle('a', 'b', parts, 200);
vehicle.drive(100);
console.log(vehicle.fuel);
console.log(vehicle.parts.quality);
