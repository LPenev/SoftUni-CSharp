document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const profileElements = document.querySelectorAll('div.profile');

    for(profileElement of profileElements){
        const profileButton = profileElement.querySelector('button');
        
        profileButton.addEventListener('click', (e)=>{
            const profileEl = e.target.parentNode;
            const radioBtnLockChecked = profileEl.querySelector('.radio-group').children[1].checked;
            
            if(radioBtnLockChecked){
                return;
            }

            const hiddenElement = profileEl.querySelector('.hidden-fields');
            (hiddenElement.classList.contains('active'))
                ?hiddenElement.classList.remove('active')
                :hiddenElement.classList.add('active');
        })
    }
}