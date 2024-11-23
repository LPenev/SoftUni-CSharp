function attachGradientEvents() {
    const resultElement = document.getElementById('result');
    const gradientElement = document.getElementById('gradient');

    gradientElement.addEventListener('mousemove',(event) =>{
        const currentWidthPosition = event.offsetX;
        const elementWidth = event.target.clientWidth;
        const progress = Math.floor((currentWidthPosition / elementWidth)* 100);
        
        resultElement.textContent = `${progress}%`;
    });
}
