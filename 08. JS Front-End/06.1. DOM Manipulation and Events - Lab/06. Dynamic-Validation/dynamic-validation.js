document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const inputEmailElement = document.getElementById('email');
    const pattern = /^[a-z]+@[a-z]+\.[a-z]+/;

    inputEmailElement.addEventListener('change',(event)=>{
        console.dir(event.target.value);
        if(pattern.test(event.target.value)){
            event.target.classList.remove('error');
        }else{
            event.target.classList.add('error');
        }
    });
}
