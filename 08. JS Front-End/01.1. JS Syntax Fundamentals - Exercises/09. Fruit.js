function fruit(fruit, weightIngrams, pricePerKg) {
    let weight = (weightIngrams / 1000).toFixed(2);
    let money = (weight * pricePerKg).toFixed(2);
    console.log(`I need ${money} to buy ${weight} kilograms ${fruit}.`);
}

fruit('apple', 1563, 2.35);