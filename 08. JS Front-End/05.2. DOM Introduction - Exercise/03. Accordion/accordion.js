function toggle() {
    const extraInfoElement = document.getElementById('extra');
    const toggleButtonElement = document.querySelector('.head span.button');
    
    if(extraInfoElement.style.display == 'block'){
        extraInfoElement.style.display = 'none'
        toggleButtonElement.innerText = 'More';
    }else{
        extraInfoElement.style.display = 'block';
        toggleButtonElement.innerText = 'Less';
    }
}