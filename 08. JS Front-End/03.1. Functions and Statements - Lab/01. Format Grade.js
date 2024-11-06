function printGrade(grade){
    console.log(`${descriptionOfGrade(grade)} (${formatGrade(grade)})`);

    function descriptionOfGrade(grade){
        if(grade < 3){
            return "Fail";
        }

        if(grade < 3.5){
            return "Poor";
        }

        if(grade < 4.5){
            return "Good";
        }

        if(grade < 5.5){
            return "Very good";
        }

        return "Excellent";
        
    }

    function formatGrade(grade){

        if(grade < 3){
            grade = 2;
            return grade.toFixed(0);
        }
        return grade.toFixed(2);
    }
}

printGrade(2.77);