window.addEventListener("load", solve);

function solve(){
    const empty = '';
    const addBtn = document.getElementById('add-btn');
    const deleteBtn = document.querySelector('button.btn.delete');

    const expenseInputElement = document.getElementById('expense');
    const amountInputElement = document.getElementById('amount');
    const dateElement = document.getElementById('date');

    const previewListUlElement = document.getElementById('preview-list');
    const expenseListUlElement = document.getElementById('expenses-list');

    deleteBtn.addEventListener('click', onClear);

    addBtn.addEventListener('click', addInputToPreview);

    function onClear(){
        location.reload();
    }

    function addInputToPreview(){
        const expense = expenseInputElement.value;
        const amount = amountInputElement.value;
        const date = dateElement.value;

        if(expense === empty || amount === empty || date === empty ){
            console.dir('expense, amount or date is empty...');
            return;
        }


        clearInputFelds();
        disableAddBtn(true);
        displayPreview(expense, amount, date);
        addButtonsToPreview();
    }

    function addButtonsToPreview(){
        const okBtn = document.querySelector('button.ok');
        const editBtn = document.querySelector('button.edit');

        editBtn.addEventListener('click', e=> editPreview(e));
        okBtn.addEventListener('click', e=> addToExpenses(e));
    }

    function addInfoIntoInputElements(expense, amount, date){
        expenseInputElement.value = expense;
        amountInputElement.value = amount;
        dateElement.value = date;
    }

    function editPreview(e){
        const pElements = e.target.parentNode.parentNode.querySelectorAll('p');
        const expense = pElements[0].textContent.substring(6);
        let amount = pElements[1].textContent.substring(8)
        amount = amount.substring(0, amount.length - 1);
        const date = pElements[2].textContent.substring(6);
        addInfoIntoInputElements(expense, amount, date);
        disableAddBtn(false);
        clearPreview();
    }

    function addToExpenses(e){
        const liNode = e.target.parentNode.parentNode.querySelector('article');

        const previewLiElement = document.createElement('li');
        previewLiElement.classList.add('expense-item');
        
        previewLiElement.appendChild(liNode);
        expenseListUlElement.appendChild(previewLiElement);

        clearPreview();
        disableAddBtn(false);
    }

    function clearPreview(){
        previewListUlElement.innerHTML = '';
    }
    
    function displayPreview(expense, amount, date){
        const previewLiElement = document.createElement('li');
        previewLiElement.classList.add('expense-item');
        
        const articleElement = document.createElement('article');

        const expensePElement = document.createElement('p');
        expensePElement.textContent = `Type: ${expense}`;

        const amountPElement = document.createElement('p');
        amountPElement.textContent = `Amount: ${amount}$`;

        const datePElement = document.createElement('p');
        datePElement.textContent = `Date: ${date}`;

        articleElement.appendChild(expensePElement);
        articleElement.appendChild(amountPElement);
        articleElement.appendChild(datePElement);
        previewLiElement.appendChild(articleElement);
        
        const divElement = document.createElement('div');
        divElement.classList.add('buttons');
        
        const editBtnElement = document.createElement('button');
        editBtnElement.classList.add('btn');
        editBtnElement.classList.add('edit');
        editBtnElement.textContent = 'edit';
        
        const okBtnElement = document.createElement('button');
        okBtnElement.classList.add('btn');
        okBtnElement.classList.add('ok');
        okBtnElement.textContent = 'ok';
        
        divElement.appendChild(editBtnElement);
        divElement.appendChild(okBtnElement);
        previewLiElement.appendChild(divElement);
        
        previewListUlElement.appendChild(previewLiElement);
    }

    function clearInputFelds(){
        expenseInputElement.value = '';
        amountInputElement.value = '';
        dateElement.value = '';
    }

    function disableAddBtn(flag){
        if(flag){
            addBtn.setAttribute('disabled','disabled');
        }else{
            addBtn.removeAttribute('disabled');
        }
    }
}

