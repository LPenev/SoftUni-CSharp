function deleteByEmail() {
    const inputTextElement = document.querySelector('input[name="email"]');
    const tableRowsElements = document.querySelectorAll('#customers tbody tr');
    const resultElement = document.getElementById('result');
    let isDeleted = false;

    tableRowsElements.forEach(element => {
        if(element.children[1].textContent === inputTextElement.value){
            element.remove();
            inputTextElement.value = '';
            isDeleted = true;
            return;
        }
    });
    
    resultElement.textContent = (isDeleted)?'Deleted.':'Not found.';
}
