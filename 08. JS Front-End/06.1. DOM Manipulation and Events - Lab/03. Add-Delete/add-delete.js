function addItem() {
    // get reference to input text element
    const inputTextElement = document.getElementById('newItemText');
    // check if inputTextElement is empty
    if(inputTextElement.value === ''){
        return;
    }

    // get reference to list element
    const listItemElement = document.getElementById('items');

    // create li element
    const newListElement = document.createElement('li');
    newListElement.textContent = inputTextElement.value;
    
    // create delete button link
    const deleteListElement = document.createElement('a');
    deleteListElement.href = '#';
    deleteListElement.textContent = '[Delete]';
    
    //append deleteListElement to newListElement
    newListElement.appendChild(deleteListElement);

    //append newListElement to listItemsElement
    listItemElement.appendChild(newListElement);

    //add listener
    deleteListElement.addEventListener('click', deleteItem);

    function deleteItem(){
        newListElement.remove();
    }

    // clear input feld
    inputTextElement.value = '';
}
