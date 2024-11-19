function solve() {
    const output = document.getElementById('output');
    const textareaElement = document.getElementById('input').value.trim();
    const result = textareaElement
        .split('.')
        .filter(sentence => sentence)
        .reduce((result,sentence, i) => {
            const resultIndex = Math.floor( i / 3);
            if(!result[resultIndex]){
                result[resultIndex] = [];
            }

            result[resultIndex].push(sentence.trim());
            return result;
        }, [])
        .map(current => `<p>${current.join('.')}.</p>`);

    output.innerHTML = result;
}