function getPrice(countOfPeople,typeOfGroup,dayOfWeek) {
    let price;
    let sum;

    switch(typeOfGroup) {
        case 'Students':
            if(dayOfWeek == "Friday") {
                price = 8.45;
            } else if(dayOfWeek == "Saturday") {
                price = 9.80;
            } else if (dayOfWeek == "Sunday") {
                price = 10.46;
            }

            if (countOfPeople > 29) {
                price *= 0.85;
            }

        break;
        case 'Business':
            if(dayOfWeek == "Friday") {
                price = 10.90;
            } else if(dayOfWeek == "Saturday") {
                price = 15.60;
            } else if (dayOfWeek == "Sunday") {
                price = 16;
            }

            if (countOfPeople > 99) {
                countOfPeople -= 10;
            }
        break;
        case 'Regular':
            if(dayOfWeek == "Friday") {
                price = 15;
            } else if(dayOfWeek == "Saturday") {
                price = 20;
            } else if (dayOfWeek == "Sunday") {
                price = 22.5;
            }

            if (countOfPeople > 9 && countOfPeople < 21) {
                price *= 0.95;
            }
        break;
    }
    
    sum = price * countOfPeople;
    console.log(`Total price: ${sum.toFixed(2)}`);
}

getPrice(
    40,
    "Regular",
    "Saturday"
    );