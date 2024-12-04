function attachEvents(){
    const wetherIcons = {
        "Sunny": '☀',
        "Partly sunny": '⛅',
        "Overcast": '☁',
        "Rain": '☂'
    };

    const baseUrl = 'http://localhost:3030/jsonstore/forecaster';
    const locationsUrl = `${baseUrl}/locations`;
    
    const locationInputElement = document.getElementById('location');
    const submitBtnElement = document.getElementById('submit');
    const forecastDivElement = document.getElementById('forecast');
    const currentDivElement = document.querySelector('#forecast div#current');
    const upcomingDivElement = document.querySelector('#forecast div#upcoming');
    const labelElement = document.getElementsByClassName('label')[0];
    
    submitBtnElement.addEventListener('click',(ev)=>{
        forecastDivElement.style.display = '';
        const location = locationInputElement.value.toLowerCase();
        locationInputElement.value = '';

        if(location === ''){
            return;
        }

        if(document.querySelector('.forecasts')!==null){
            document.querySelector('.forecasts').remove();
        }

        if(document.querySelector('.forecast-info')!==null){
            document.querySelector('.forecast-info').remove();
        }

        
        fetch(locationsUrl)
        .then(res => res.json())
        .then(data => data.filter(x=>x.name.toLowerCase() === location))
            .then(data => {
                const townCode = data[0].code;
                currentForecast(townCode);
                upcomingForecast(townCode);
            })
            .catch(e => labelElement.textContent='Error'
        ).finally(labelElement.textContent = 'Current conditions');
    })
    
    
    async function currentForecast(townCode){
        const url = `${baseUrl}/today/${townCode}`;
        try{
            const response = await fetch(url);
            const data = await response.json();
            
            const forecastDivElement = document.createElement('div');
            forecastDivElement.classList.add('forecasts');
            
            const symbolSpanElement = document.createElement('span');
            symbolSpanElement.classList.add('condition','symbol');
            symbolSpanElement.innerText = wetherIcons[data.forecast.condition];
            
            const conditionSpanElement = document.createElement('span');
            conditionSpanElement.classList.add('condition');
            
            forecastDivElement.appendChild(symbolSpanElement);
            forecastDivElement.appendChild(conditionSpanElement);
            
            const infoArray = [data.name,`${data.forecast.low}°/${data.forecast.high}°`,data.forecast.condition];

            infoArray.forEach(element=> {
                const forecastdataSpanElement = document.createElement('span');
                forecastdataSpanElement.classList.add('forecast-data');
                forecastdataSpanElement.innerText = element;

                conditionSpanElement.appendChild(forecastdataSpanElement);
            });
            
            currentDivElement.appendChild(forecastDivElement);
        }catch{
            labelElement.textContent='Error';
        }
    }
        
    async function upcomingForecast(townCode){
        const url = `${baseUrl}/upcoming/${townCode}`;
        try{
            const response = await fetch(url);
            const data = await response.json();

            const forecastInfoDivElement = document.createElement('div');
            forecastInfoDivElement.classList.add('forecast-info');

            data.forecast.forEach(element=> {
                const upcomingSpanElement = document.createElement('span');
                upcomingSpanElement.classList.add('upcoming');

                const symbolSpanElement = document.createElement('span');
                symbolSpanElement.classList.add('symbol');
                symbolSpanElement.innerText = wetherIcons[element.condition];

                const gradSpanElement = document.createElement('span');
                gradSpanElement.classList.add('forecast-data');
                gradSpanElement.innerText = `${element.low}°/${element.high}°`;

                const weatherSpanElement = document.createElement('span');
                weatherSpanElement.classList.add('forecast-data');
                weatherSpanElement.innerText = element.condition;

                upcomingSpanElement.appendChild(symbolSpanElement);
                upcomingSpanElement.appendChild(gradSpanElement);
                upcomingSpanElement.appendChild(weatherSpanElement);
                forecastInfoDivElement.appendChild(upcomingSpanElement);
            })

            upcomingDivElement.appendChild(forecastInfoDivElement);

        }catch{
            labelElement.textContent='Error';
        }
    }
}
attachEvents();