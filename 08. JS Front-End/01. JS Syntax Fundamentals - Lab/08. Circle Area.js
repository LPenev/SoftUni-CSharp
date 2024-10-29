function circleArea(radius) {
    let result;

    if(typeof(radius)!= 'number'){
        result = `We can not calculate the circle area, because we receive a ${typeof(radius)}.`;
    } else {
        result = (Math.PI * Math.pow(radius,2)).toFixed(2);
    }
    console.log(result);
}

circleArea(5);