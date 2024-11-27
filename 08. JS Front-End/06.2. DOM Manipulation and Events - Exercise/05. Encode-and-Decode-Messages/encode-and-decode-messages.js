document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const encodeMessageElement = document.querySelector('#encode textarea');
    const encodeButtonElement = document.querySelector('#encode button');

    const decodeMessageElement = document.querySelector('#decode textarea');
    const decodeButtonElemnt = document.querySelector('#decode button');

    encodeButtonElement.addEventListener('click', (e)=>{
        e.preventDefault();
        const encodedMessage = encodeMessage(encodeMessageElement.value);
        encodeMessageElement.value = '';
        decodeMessageElement.value = encodedMessage;
    })

    decodeButtonElemnt.addEventListener('click', (e)=>{
        e.preventDefault();
        decodeMessageElement.value = decodeMessage(decodeMessageElement.value);
    })

    function encodeMessage(message){
        let encodedMessage = '';
        Array.from(message).forEach(element => {
            encodedMessage += String.fromCharCode(element.charCodeAt()+1);
        });
        return encodedMessage;
    }

    function decodeMessage(message){
        let decodedMessage = '';
        Array.from(message).forEach(element => {
            decodedMessage += String.fromCharCode(element.charCodeAt()-1);
        });
        return decodedMessage;
    }
}