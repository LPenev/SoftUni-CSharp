const baseUrl = 'http://localhost:3030/jsonstore/orders';
const getOrderURL = (id) => `${baseUrl}/${id}`;

const nameInput = document.getElementById('name');
const quantityInput = document.getElementById('quantity');
const dateInput = document.getElementById('date');
const orderBtn = document.getElementById('order-btn');
const editBtn = document.getElementById('edit-order');
const loadOrdersBtn = document.getElementById('load-orders');
const listOrders = document.getElementById('list');

currentOrderId = null;

orderBtn.addEventListener('click', (e) => createOrder(e));
editBtn.addEventListener('click', (e) => editOrder(e, currentOrderId));
loadOrdersBtn.addEventListener('click', loadOrders);

async function loadOrders(){
    clearListOrders();    
    disableOrderBtn(false);
    disableEditBtn(true);

    try{
        const resource = await fetch(baseUrl);
        if(!resource.ok){
            throw('Database read error.');
        }
        const data = await resource.json();
        const orders = Object.values(data);
        orders.forEach(order => displayOrder(order));
    }catch(error){
        logError(error);
    }
}

function displayOrder(order){
    const orderContainer = document.createElement('div');
    orderContainer.classList.add('container');
    const nameH2 = document.createElement('h2');
    nameH2.textContent = order.name;
    const dateH3 = document.createElement('h3');
    dateH3.textContent = order.date;
    const quantity = document.createElement('h3');
    quantity.textContent = order.quantity;

    const changeBtn = document.createElement('button');
    changeBtn.textContent = 'Change';
    changeBtn.classList.add('change-btn');
    const doneBtn = document.createElement('button');
    doneBtn.textContent = 'Done';
    doneBtn.classList.add('done-btn');

    orderContainer.appendChild(nameH2);
    orderContainer.appendChild(dateH3);
    orderContainer.appendChild(quantity);
    orderContainer.appendChild(changeBtn);
    orderContainer.appendChild(doneBtn);
    listOrders.appendChild(orderContainer);

    changeBtn.addEventListener('click', (e) => prepareOrderToEdit(order, orderContainer));
    doneBtn.addEventListener('click',(e) => deleteOrder(orderContainer, order._id));
}

async function createOrder(event){
    event.preventDefault();

    orderName = nameInput.value;
    orderDate = dateInput.value;
    orderQuantity = quantityInput.value;

    if(!orderName || !orderDate || !orderQuantity){
        alert('Please fill all felds...');
        return;
    }

    orderObj = {
        name: orderName,
        date: orderDate,
        quantity: orderQuantity
    };

    try{
        await fetch(baseUrl,{
            method: 'POST',
            headers: { "Content-Type": "application/json"},
            body: JSON.stringify(orderObj)
        });
    }catch(error){
        logError(error);
    }

    clearInputFelds();
    loadOrders();
}

function prepareOrderToEdit(order, orderContainer){
    fillInputsFelds(order);
    orderContainer.remove();
    disableOrderBtn(true);
    disableEditBtn(false);
    currentOrderId = order._id;
}

async function editOrder(event, id) {
    event.preventDefault();

    orderName = nameInput.value;
    orderDate = dateInput.value;
    orderQuantity = quantityInput.value;

    if(!orderName || !orderDate || !orderQuantity){
        alert('Please fill all felds...');
        return;
    }

    if(!id){
        logError('Missed id by order edit.');
        return;
    }
    
    orderObj = {
        name: orderName,
        date: orderDate,
        quantity: orderQuantity,
        _id: id
    };

    const orderUrl = getOrderURL(id);

    try{
        await fetch(orderUrl,{
            method: 'PUT',
            headers: { "Content-Type": "application/json"},
            body: JSON.stringify(orderObj)
        });
    }catch(error){
        logError(error);
    }

    clearInputFelds();
    //loadOrders();
    displayOrder(orderObj);
    disableOrderBtn(false);
    disableEditBtn(true);
    currentOrderId = null;
}

function deleteOrder(container, id){
    const orderUrl = getOrderURL(id);
    
    if(!id){
        logError('Missed id by delete order.');
        return;
    }

    try{
        fetch(orderUrl, {method: 'DELETE'});
    }catch(error){
        logError(error);
    }
    container.remove();
}

function clearListOrders(){
    listOrders.innerHTML = '';
}

function logError(error){
    console.dir(error);
}

function clearInputFelds(){
    nameInput.value = '';
    dateInput.value = '';
    quantityInput.value = '';
}

function fillInputsFelds(order){
    nameInput.value = order.name;
    dateInput.value = order.date;
    quantityInput.value = order.quantity;
}

function disableOrderBtn(isDisabled){
    orderBtn.disabled = isDisabled;
}

function disableEditBtn(isDisabled){
    editBtn.disabled = isDisabled;
}



