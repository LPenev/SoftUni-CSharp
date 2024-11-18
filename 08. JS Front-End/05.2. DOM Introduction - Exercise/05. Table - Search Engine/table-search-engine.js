function solve() {
    const tableRowsElements = document.querySelectorAll('table.container tbody tr');
    const searchText = document.getElementById('searchField').value;
   
    if (searchText == ''){
        return;
    }

    for(tableRow of tableRowsElements){
        tableRow.classList.remove('select');

        if(tableRow.innerText.includes(searchText)){
            tableRow.classList.add('select');
        }
    }
}