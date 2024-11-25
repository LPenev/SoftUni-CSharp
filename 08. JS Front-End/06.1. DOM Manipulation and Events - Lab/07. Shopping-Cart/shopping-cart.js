document.addEventListener('DOMContentLoaded', solve);

   function solve() {
      const addButtonElements = document.querySelectorAll('button.add-product');
      const textareaResultElement = document.querySelector('.shopping-cart textarea');
      const checkOutButtonElement = document.querySelector('button.checkout');
      let totalSum = 0;
      let buyedProductsList = {};

      for(const addButtonElement of addButtonElements){
         addButtonElement.addEventListener('click',(event) => {
            const productElement = addButtonElement.parentElement.parentElement;
            productName = productElement.querySelector('.product-title').textContent;
            productPrice = Number(productElement.querySelector('.product-line-price').textContent).toFixed(2);
            totalSum += Number(productPrice);
            buyedProductsList[productName] = true;

            textareaResultElement.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;
         });
      }

      checkOutButtonElement.addEventListener('click', (event)=> {
         const list = Object.keys(buyedProductsList).join(', ');
         textareaResultElement.textContent += `You bought ${list} for ${totalSum.toFixed(2)}.`;
         disableAddButtons();
      });

      function disableAddButtons(){
         addButtonElements.forEach(addButton=>addButton.disabled = true);
         checkOutButtonElement.disabled = true;
      }
   }
