function totalPrice(product, quantity){
    let sum = getPrice(product) * quantity;
    console.log(sum.toFixed(2));

    function getPrice(product){
        let price = 0;
        switch(product){
            case 'coffee':
                price = 1.5;
                break;

            case 'water':
                price = 1;
                break;

            case 'coke':
                price = 1.4;
                break;

            case 'snacks':
                price = 2;
                break;
        }
        
        return price;
    }
}

totalPrice("coffee", 2);