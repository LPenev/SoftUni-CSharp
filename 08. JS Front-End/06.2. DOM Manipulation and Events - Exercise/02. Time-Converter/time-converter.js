document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const formElements = document.querySelectorAll('form');

    formElements.forEach(form=>{
        const button = form.querySelector('input[type=submit]');
        button.addEventListener('click', (e)=>{
            e.preventDefault();
            const inputElement = e.target.previousSibling.previousSibling;
            const currentType = e.target.parentNode.id;
            const seconds = toSeconds(currentType, inputElement.value);
            fillFelds(seconds);
        });
    });

    function fillFelds(seconds){
        document.getElementById('seconds-input').value = fromSeconds('seconds',seconds);
        document.getElementById('minutes-input').value = fromSeconds('minutes',seconds);
        document.getElementById('hours-input').value = fromSeconds('hours',seconds);
        document.getElementById('days-input').value = fromSeconds('days',seconds);
    }

    function toSeconds(type,value){
        const convertor = {
            days: (v) => v * 86400,
            hours: (v) => v * 3600,
            minutes: (v) => v * 60,
            seconds: (v) => v
        }
        return convertor[type](Number(value));
    }

    function fromSeconds(type,value){
        const convertor = {
            days: (v) => v / 86400,
            hours: (v) => v / 3600,
            minutes: (v) => v / 60,
            seconds: (v) => v
        }
        return convertor[type](Number(value)).toFixed(2);
    }
}