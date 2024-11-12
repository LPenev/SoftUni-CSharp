function printAdressBook(inputString){
    let addressBook = {};
    convertStringArrayIntoObject(inputString);
    printAddressBook(sortAddressBook(addressBook));

    function convertStringArrayIntoObject(inputString){
        for(let currentRecord of inputString){
            const [name, address] = currentRecord.split(':');
            addressBook[name] = address;
        }
    }

    function printAddressBook(meetings){
        for(const name in meetings){
            printOutput(`${name} -> ${meetings[name]}`);
        }
    }

    function printOutput(string){
        console.log(string);
    }

    function sortAddressBook(addressBook){
        const sorted = Object.entries(addressBook);
        sorted.sort((a,b) => a[0].localeCompare(b[0]));
        const sortedAddressBook = Object.fromEntries(sorted);
        return sortedAddressBook;
    }
}

printAdressBook(
    ['Bob:Huxley Rd',
    'John:Milwaukee Crossing',
    'Peter:Fordem Ave',
    'Bob:Redwing Ave',
    'George:Mesta Crossing',
    'Ted:Gateway Way',
    'Bill:Gateway Way',
    'John:Grover Rd',
    'Peter:Huxley Rd',
    'Jeff:Gateway Way',
    'Jeff:Huxley Rd']
    );