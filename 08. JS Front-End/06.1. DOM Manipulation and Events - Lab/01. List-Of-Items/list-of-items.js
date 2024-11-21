function addItem() {
    const listItemsElement = document.getElementById('items');
    const inputTxtElement = document.getElementById('newItemText');

    // check if input is empty
    if(inputTxtElement.value === ''){
        return;
    }

    // create new li element, set element text and append.
    const newLiElement = document.createElement('li');
    newLiElement.textContent = inputTxtElement.value;
    listItemsElement.appendChild(newLiElement);

    // clear input feld
    inputTxtElement.value = '';
}
