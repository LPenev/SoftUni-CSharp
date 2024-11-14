function iventory(input){
    input
        .map(row=>row.split('/').map(a=>a.trim()))
        .map(([name,level,item]) => ({
            name,
            level: Number(level),
            item,
        }))
        .sort((a,b)=> a.level - b.level)
        .forEach(hero => {
         console.log(`Hero: ${hero.name}`);
         console.log(`level => ${hero.level}`);
         console.log(`items => ${hero.item}`);
        });;
}

iventory(
    [
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
    );