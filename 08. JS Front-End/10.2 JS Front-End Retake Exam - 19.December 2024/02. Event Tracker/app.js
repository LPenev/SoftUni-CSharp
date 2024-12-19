window.addEventListener("load", solve);

function solve(){
    const eventNameInput = document.getElementById('event');
    const shortNoteInput = document.getElementById('note');
    const eventDateInput = document.getElementById('date');
    const upcomingListUl = document.getElementById('upcoming-list');
    const eventListUl = document.getElementById('events-list');
    const deleteEventsBtn = document.querySelector('#events .btn.delete');
    const saveBtn = document.getElementById('save');

    saveBtn.addEventListener('click', (e)=> createEvent(e));
    deleteEventsBtn.addEventListener('click', deleteAllEndedEvents);

    function createEvent(e){
        e.preventDefault();

        const eventName = eventNameInput.value;
        const shortNote = shortNoteInput.value;
        const eventDate = eventDateInput.value;
        const eventObj = {
            eventName, shortNote, eventDate
        };

        const eventItem = document.createElement('li');
        eventItem.classList.add('event-item');
        const eventContainer = document.createElement('div');
        eventContainer.classList.add('event-container');
        const containerArticle = document.createElement('article');
        const namePElement = document.createElement('p');
        namePElement.textContent = `Name: ${eventName}`;
        const notePElement = document.createElement('p');
        notePElement.textContent = `Note: ${shortNote}`;
        const datePElement = document.createElement('p');
        datePElement.textContent = `Date: ${eventDate}`;

        eventItem.appendChild(eventContainer);
        eventContainer.appendChild(containerArticle);
        containerArticle.appendChild(namePElement);
        containerArticle.appendChild(notePElement);
        containerArticle.appendChild(datePElement);
        
        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons');
        
        const editBtn = document.createElement('button');
        editBtn.textContent = 'Edit';
        editBtn.classList.add('btn');
        editBtn.classList.add('edit');
        editBtn.addEventListener('click',e => editEvent(eventItem, eventObj));

        const doneBtn = document.createElement('button');
        doneBtn.textContent = 'Done';
        doneBtn.classList.add('btn');
        doneBtn.classList.add('done');
        doneBtn.addEventListener('click', e => doneEvent(eventItem, eventObj));

        buttonsDiv.appendChild(editBtn);
        buttonsDiv.appendChild(doneBtn);
        eventContainer.appendChild(buttonsDiv);

        upcomingListUl.appendChild(eventItem);
        clearInputFelds();
    }

    function doneEvent(eventContainer, eventObj){
        const eventItem = document.createElement('li');
        eventItem.classList.add('event-item');
        const containerArticle = document.createElement('article');
        const namePElement = document.createElement('p');
        namePElement.textContent = `Name: ${eventObj.eventName}`;
        const notePElement = document.createElement('p');
        notePElement.textContent = `Note: ${eventObj.shortNote}`;
        const datePElement = document.createElement('p');
        datePElement.textContent = `Date: ${eventObj.eventDate}`;

        eventItem.appendChild(containerArticle);
        containerArticle.appendChild(namePElement);
        containerArticle.appendChild(notePElement);
        containerArticle.appendChild(datePElement)
        eventListUl.appendChild(eventItem);

        eventContainer.remove();
    }

    function editEvent(container, eventObj, e){
        eventNameInput.value = eventObj.eventName;
        shortNoteInput.value = eventObj.shortNote;
        eventDateInput.value = eventObj.eventDate;
        container.remove();
    }

    function clearInputFelds(){
        eventNameInput.value = '';
        shortNoteInput.value = '';
        eventDateInput.value = '';
    }

    function deleteAllEndedEvents(){
        eventListUl.innerHTML = '';
    }
}

