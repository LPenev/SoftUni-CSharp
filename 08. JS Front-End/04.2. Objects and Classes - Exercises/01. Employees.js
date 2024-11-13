function printListOfEmployers(employersDataArray){
    let employees = [];

    class Employee {
        constructor(employeeName, personalNum){
            this.employeeName = employeeName;
            this.personalNum = personalNum;
        }
    }

    for(const currentEmployee of employersDataArray){
        const employeeName = currentEmployee;
        const personalNum = employeeName.length;
        employees.push(new Employee(employeeName, personalNum));
    }

    employees.forEach((employee)=> printEmployeeInfo(employee.employeeName, employee.personalNum));

    function printEmployeeInfo(employeeName, personalNum){
        console.log(`Name: ${employeeName} -- Personal Number: ${personalNum}`);
    }
}

printListOfEmployers(
    [
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
);