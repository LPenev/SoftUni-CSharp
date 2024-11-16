function editElement(element, wordToReplace, newWord) {

    const content = element.innerText;
    const matcher = new RegExp(wordToReplace, 'g');
    const edited = content.replace(matcher, newWord);

    element.innerText = edited;
}