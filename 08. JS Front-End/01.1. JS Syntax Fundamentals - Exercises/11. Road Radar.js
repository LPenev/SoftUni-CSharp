function roadRadar(speed, area) {
    let speedLimit = [];
    speedLimit['motorway'] = 130;
    speedLimit['interstate'] = 90;
    speedLimit['city'] = 50;
    speedLimit['residential'] = 20;
    
    if(speed <= speedLimit[area]){
        console.log(`Driving ${speed} km/h in a ${speedLimit[area]} zone`);
    }else{
        let difference = speed - speedLimit[area];
        let status;
        if(difference <= 20) {
            status = 'speeding';
        }else if(difference <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }
        // print result
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit[area]} - ${status}`);
    }
}

roadRadar(140, 'motorway');