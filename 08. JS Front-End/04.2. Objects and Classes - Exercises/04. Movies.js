function storeInformationAboutMovies(inputArray){
    let movies = [];

    addMovies(movies, inputArray);
    printMovies(movies);

    function printMovies(movies){
        movies
        .filter(movie => movie.director && movie.date)
        .forEach(movie => console.log(JSON.stringify(movie)));
    }

    function addMovies(movies, moviesArray){
        const commandAddMovie = 'addMovie';
        const commandDirectedBy = 'directedBy';
        const commandDateOn = 'onDate';
        
        moviesArray.forEach(row => {
            
            if(row.includes(commandAddMovie)){

                const filmName = row.replace(commandAddMovie, '').trim();
                if(!isMovieExsist(movies, filmName)){
                    const movie = {
                        name: filmName
                    };
                    movies.push(movie);
                }
            
            }else if(row.includes(commandDirectedBy)){
                const [filmName, directedBy] = extractInfoFromCommand(row, commandDirectedBy);
                const currentMovie = isMovieExsist(movies, filmName);
                
                if(currentMovie){
                    currentMovie.director = directedBy;
                }

            }else if(row.includes(commandDateOn)){
                const [filmName, onDate] = extractInfoFromCommand(row, commandDateOn);
                const currentMovie = isMovieExsist(movies, filmName);

                if(currentMovie){
                    currentMovie.date = onDate;
                }

            }
        });

        return movies;
    }

    function isMovieExsist(movies, filmName){
        const currentMovie = movies.find(movie => movie.name === filmName);
        return currentMovie;
    }

    function extractInfoFromCommand(row,command){
        return row.split(command).map(a=>a.trim());
    }
}

storeInformationAboutMovies(
    [
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]
    );
