document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const inputFormElement = document.getElementById('input'); 
    const inputElement = inputFormElement.querySelector('textarea');
    const buttonElement = inputFormElement.querySelector('input[type=submit]');
    
    const furnitureTbodyElement = document.querySelector('table tbody');
    const furnitureTrElements = furnitureTbodyElement.children;

    const formTableElement = document.getElementById('shop');
    const buyBtnElement = formTableElement.querySelector('input[type=submit]');
    const shopTextareaElement = formTableElement.querySelector('textarea');

    buttonElement.addEventListener('click', (e)=>{
        e.preventDefault();
        let currentFragment = document.createDocumentFragment();
        Array.from(JSON.parse(inputElement.value))
            .forEach(element => {
                // image
                const imgElement = document.createElement('img');
                imgElement.src = element.img;
                const imgTdElement = document.createElement('td');
                imgTdElement.appendChild(imgElement);

                // name
                const namePElement = document.createElement('p');
                namePElement.textContent = element.name;
                const nameTdElement = document.createElement('td');
                nameTdElement.appendChild(namePElement);

                // price
                const pricePElement = document.createElement('p');
                pricePElement.textContent = element.price;
                const priceTdElement = document.createElement('td');
                priceTdElement.appendChild(pricePElement);

                // Decoration factor
                const decoPElement = document.createElement('p');
                decoPElement.textContent = element.decFactor;
                const decoTdElement = document.createElement('td');
                decoTdElement.appendChild(decoPElement);

                // Mark - select box
                const markElement = document.createElement('input');
                markElement.setAttribute('type','checkbox');
                const markTdElement = document.createElement('td');
                markTdElement.appendChild(markElement);

                //
                const trElement = document.createElement('tr');
                trElement.appendChild(imgTdElement);
                trElement.appendChild(nameTdElement);
                trElement.appendChild(priceTdElement);
                trElement.appendChild(decoTdElement);
                trElement.appendChild(markTdElement);

                currentFragment.appendChild(trElement);
            });

        furnitureTbodyElement.appendChild(currentFragment);
    });

    buyBtnElement.addEventListener('click', (e)=>{
        e.preventDefault();

        let names = [];
        let totalPrice = 0;
        let decoFactorSum = 0;
        let byedItems = 0;
        let textareaText = '';

        Array.from(furnitureTrElements).forEach(trElement => {
            const markCheckboxElement = trElement.querySelector('input[type=checkbox]');
            
            if(!markCheckboxElement.checked){
                return;
            }
            
            byedItems++;

            const name = trElement.children.item(1).textContent;
            const price = Number(trElement.children.item(2).textContent);
            const decoFactor = Number(trElement.children.item(3).textContent);
            names.push(name);
            totalPrice += price;
            decoFactorSum += decoFactor;
        });

        const decFactor = decoFactorSum / byedItems;

        const line1 = `Bought furniture: ${names.join(', ')}\n`;
        const line2 = `Total price: ${totalPrice}\n`;
        const line3 = `Average decoration factor: ${decFactor}`;
        textareaText += line1;
        textareaText += line2;
        textareaText += line3;
        shopTextareaElement.value =textareaText;
    });
}