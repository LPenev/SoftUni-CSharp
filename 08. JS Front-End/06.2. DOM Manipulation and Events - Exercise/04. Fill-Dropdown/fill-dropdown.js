document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const menuElement = document.getElementById('menu');
    const textElement = document.getElementById('newItemText');
    const valueElement = document.getElementById('newItemValue');
    const submitButtonElement = document.querySelector('form input[type=submit]');

    submitButtonElement.addEventListener('click',(e)=>{
        e.preventDefault();

        const createOptionElement = document.createElement('option');
        createOptionElement.textContent = textElement.value;
        createOptionElement.value = valueElement.value;
        
        menuElement.appendChild(createOptionElement);

        clearFelds();
    })

    function clearFelds(){
        textElement.value = '';
        valueElement.value = '';
    }
}