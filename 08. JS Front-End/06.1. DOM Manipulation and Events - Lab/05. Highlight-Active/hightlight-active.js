document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const inputElements = document.querySelectorAll('input[type=text]');

    Array.from(inputElements)
    .forEach(inputEement => inputEement.addEventListener('focus',(event)=>{
            event.target.parentElement.classList.add('focused');
    }));

    Array.from(inputElements)
        .forEach(inputEement => inputEement.addEventListener('blur',(event)=>{
            event.target.parentElement.classList.remove('focused');
    }));
}