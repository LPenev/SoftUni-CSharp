function solve() {
    const tableHeadRowCollumns = document.querySelectorAll('table thead tr th');
    const tableBodyRows = document.querySelectorAll('table tbody tr');
    const output = document.getElementById('output');

    const checkedTableCollumns = [...tableHeadRowCollumns]
        .map((th,i) => ({el: th.firstElementChild, name: th.firstElementChild.getAttribute('name'), index: i}))
        .filter(collumn => collumn.el.checked);

    const outputData = [...tableBodyRows]
        .map(row => {
            return checkedTableCollumns.reduce((acc, input) => {
                acc[input.name] = row.children[input.index].textContent;
                return acc;
            }, {})
        });

    output.value = JSON.stringify(outputData,null, 4);
}