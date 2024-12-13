function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const results = document.querySelector('#results tbody');
    const submitBtn = document.getElementById('submit');

    displayStudents(readAllStudents(url), results);

    submitBtn.addEventListener('click', e=>addNewStudent(e, url));

    // add new student functions
    function addNewStudent(e, url){
        const inputs = Array.from(e.target.parentNode.querySelectorAll('input'));

        //check for empty inputs
        // TODO....

        const firstName = inputs[0].value;
        const lastName = inputs[1].value;
        const facultyNumber = inputs[2].value;
        const grade = inputs[3].value;

        let student = {
            firstName,
            lastName,
            facultyNumber,
            grade
        }

        fetch(url, {
            method: 'POST',
            body: JSON.stringify(student)
        });

        clearInputFeldsAndResults();
        displayStudents(readAllStudents(url), results);
    }

    function clearInputFeldsAndResults(){
        // clear input felds
        inputs = document.querySelectorAll('.inputs input');
        inputs.forEach(input => input.value = '');

        // clear results
        results.innerHTML = '';
    }

    // display students functions
    function createRowResults(students, results){
        rows = document.createDocumentFragment();

        students.forEach(student => createRow(student));

        function createRow(student){
            const trElement = document.createElement('tr');
            
            const tdElementFirstName = document.createElement('td');
            tdElementFirstName.textContent = student.firstName;

            const tdElementLastName = document.createElement('td');
            tdElementLastName.textContent = student.lastName;

            const tdElementFacultyNumber = document.createElement('td');
            tdElementFacultyNumber.textContent = student.facultyNumber;
            
            const tdElementGrade = document.createElement('td');
            tdElementGrade.textContent = student.grade;

            trElement.appendChild(tdElementFirstName);
            trElement.appendChild(tdElementLastName);
            trElement.appendChild(tdElementFacultyNumber);
            trElement.appendChild(tdElementGrade);
            rows.appendChild(trElement);
        }
        results.appendChild(rows);
    }

    function displayStudents(students, results){
        students.then(data => Object.values(data))
            .then(students => createRowResults(students, results));
    }

    async function readAllStudents(url){
        const response = await fetch(url);
        checkResponse(response);

        const data = await response.json();
        return data;
    }

    function checkResponse(response){
        if(response.status !== 200){
            throw new Error('Server not respond...');
        }
    }
}

attachEvents();