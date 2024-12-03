function solve() {
    
    const infoDivElement = document.querySelector('span.info');
    const departBtnElement = document.getElementById('depart');
    const arriveBtnElement = document.getElementById('arrive');
    
    busStop = {
        next: 'depot'
    }

    function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${busStop.next}`;
        fetch(url)
            .then(res => res.json())
            .then(data => {
                busStop = data;
                infoDivElement.innerText = `Next Stop ${busStop.name}`;
                buttonsSet('depart');
            })
            .catch(err => {
                console.log(err);
                buttonsSet('disableAll');
            });
    }

    async function arrive() {
        infoDivElement.innerText = `Arrive at ${busStop.name}`;
        buttonsSet('arrive');
    }

    function buttonsSet(btn){

        if(btn === 'depart'){
            departBtnElement.disabled = true;
            arriveBtnElement.disabled = false;
        
        }else if(btn === 'arrive'){
            departBtnElement.disabled = false;
            arriveBtnElement.disabled = true;
        
        }else{
            departBtnElement.disabled = true;
            arriveBtnElement.disabled = true;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();