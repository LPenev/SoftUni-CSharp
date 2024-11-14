function storeProvision(storeProducts, delivery){
    let storeDB = {};

    addProductsIntoStore(storeDB,storeProducts);
    addProductsIntoStore(storeDB,delivery);
    printDB(storeDB);

    function printDB(storeDB){
        for(const product in storeDB){
            console.log(`${product} -> ${storeDB[product]}`);
        }
    }

    function addProductsIntoStore(DBase,products){
        for(let i = 0; i < products.length; i+=2){
            const product = products[i];
            const quantity = Number(products[i+1]);
            if(!DBase[product]){
                DBase[product] = 0;
            }

            DBase[product] += quantity;
        }
        return DBase;
    }
}


storeProvision(
    ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']        
);