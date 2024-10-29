function theatrePromotions(day,age){
    let result;
    
    switch(day){
        case 'Weekday':
            if((age >= 0 && age <=18)||(age > 64 && age <=122)) {
                result = '12$';
            } else if(age > 18 && age <= 64) {
                result = '18$';
            } else {
                result = 'Error!';
            }
            break;
        
        case 'Weekend':
            if((age >= 0 && age <=18)||(age > 64 && age <=122)) {
                result = '15$';
            } else if(age > 18 && age <= 64) {
                result = '20$';
            } else {
                result = 'Error!';
            }
            break;
        
        case 'Holiday':
            if(age >= 0 && age <=18) {
                result = '5$';
            } else if(age > 18 && age <= 64) {
                result = '12$';
            } else if(age > 64 && age <= 122) {
                result = '10$';
            } else {
                result = 'Error!';
            }
            break;

        default: 
            result = "Error!";
            break;
    }

    console.log(result);
}

theatrePromotions('Holiday',12);