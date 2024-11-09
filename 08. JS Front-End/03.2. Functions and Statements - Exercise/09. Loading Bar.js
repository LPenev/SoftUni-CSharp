function loadingBar(progress){
    const createProgressBar = progress => `${progress}% [${'%'.repeat(progress/10)}${'.'.repeat(10-progress/10)}]`;
    console.log(createProgressBar(progress));
    console.log((progress===100)?'100% Complete!':'Still loading...');
}

loadingBar(50);
loadingBar(100);
