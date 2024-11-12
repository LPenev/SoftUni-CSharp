function printNamesOfsongListFromTypeList(songs){
    let songList = [];
    const numberOfSongs = songs.shift();
    const typeList = songs.pop();

    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    for(let i = 0; i < numberOfSongs; i++){
        const [typeList, name, time] = songs[i].split('_');
        songList.push(new Song(typeList, name, time));
    }

    if(typeList === 'all'){
        songList.forEach((i)=> console.log(i.name));
    }else{
        const filtredSongList = songList.filter((i)=>i.typeList === typeList);
        filtredSongList.forEach((i)=> console.log(i.name));
    }
}

printNamesOfsongListFromTypeList(
    [4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
    );