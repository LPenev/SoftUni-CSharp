function attachEvents() {
    const btnLoad = document.getElementById('btnLoad');
    const btnCreate = document.getElementById('btnCreate');
    const url = 'http://localhost:3030/jsonstore/phonebook';

    btnLoad.addEventListener('click',()=>loadPhonebook(url));
    
    btnCreate.addEventListener('click',()=>createPerson(url));

    function createPerson(url){
        const personInputElement = document.getElementById('person');
        const phoneInputElement = document.getElementById('phone');
        
        if(personInputElement.value === '' || phoneInputElement.value === ''){
            return;
        }

        newPerson = {
            person: person.value,
            phone: phone.value
        }

        personInputElement.value = '';
        phoneInputElement.value = '';
        
        try{
            fetch(url,{
                method: 'POST',
                body: JSON.stringify(newPerson)
            });

        }catch(e){
            console.dir(e);
        }

        loadPhonebook(url);
    }

    async function loadPhonebook(url){
        try{
            const response = await fetch(url);
            const data = await response.json();
            displayPhonebook(Object.values(data));
        }catch(e){
            console.dir(e)
        }

    }
    
    function displayPhonebook(phonebook){
        const phonebookUlElement = document.getElementById('phonebook');
        phonebookUlElement.replaceChildren();
        
        let liFragment = document.createDocumentFragment();

        phonebook.forEach(current => {
            const liElement = document.createElement('li');

            const personData = `${current.person}: ${current.phone}`;
            
            liElement.textContent = personData;
            const btnDeleteElement = document.createElement('button');
            
            btnDeleteElement.textContent = 'Delete';
            btnDeleteElement.value = current._id;
            btnDeleteElement.addEventListener('click',(event)=>deletePerson(event, current._id));

            liElement.appendChild(btnDeleteElement);
            liFragment.appendChild(liElement);
        });

        phonebookUlElement.appendChild(liFragment);

    }

    async function deletePerson(event, id){
        const deleteUrl = `${url}/${id}`;
        try{
            const response = await fetch(deleteUrl,{method:'DELETE'});
        }catch(e){
            console.dir(e);
        }

        event.target.parentNode.remove();
    }

}

attachEvents();