function townsInfo(townsInfoArray){
    let towns = [];

    for(const currentTown of townsInfoArray){
        const [townName, latitude, longitude] = currentTown.split('|').map((x) => x.trim());
        const town = {
            town: townName,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        }

        towns.push(town);
    }
    
    towns.forEach(town => console.log(town));
}

const towns = townsInfo(['Sofia | 42.696552 | 23.32601','Beijing | 39.913818 | 116.363625']);