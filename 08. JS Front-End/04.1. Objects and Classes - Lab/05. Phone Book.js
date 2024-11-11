function printPhoneBook(persons){
    // declare a phonebook object
    let phonebook = {};
    
    // convert inputed strings of persons to object    
    convertStringToObject(persons);
    
    // print phone book
    printPhoneBook(phonebook);

    function convertStringToObject(persons){
        for(let person of persons){
            let [key, value] = person.split(' ');
            phonebook[key] = value;
        }
    }
    
    // print phone book
    function printPhoneBook(phonebook){
        for(let key in phonebook){
            console.log(`${key} -> ${phonebook[key]}`);
        }
    }
}

printPhoneBook(
    ['Tim 0834212554',
        'Peter 0877547887',
        'Bill 0896543112',
        'Tim 0876566344'
    ]
);