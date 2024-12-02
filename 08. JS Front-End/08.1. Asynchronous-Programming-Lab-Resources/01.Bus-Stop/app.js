function getInfo() {

    const stopIdElement = document.getElementById('stopId');
    const stopNameElement = document.getElementById('stopName');
    const busesLiElement = document.getElementById('buses');
    
    const liFragment = document.createDocumentFragment();
    
    const stopId = stopIdElement.value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    
    // reset all felds
    stopIdElement.value = '';
    stopNameElement.textContent = '';
    busesLiElement.innerHTML = '';
    
    fetch(url)
    .then(res => res.json())
    .then(data => {
        stopNameElement.textContent = data.name;
        
        Object.keys(data.buses)
            .forEach(busId => {
                const liElement = document.createElement('li');
                const time = buses[busId];
                liElement.textContent = `Bus ${busId} arrives in ${time} minutes`;
                liFragment.appendChild(liElement);
            });
            busesLiElement.appendChild(liFragment);
        })
        .catch(error => printError());
        
        printError = ()=> stopNameElement.textContent = 'Error';
    }