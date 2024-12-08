function attachEvents() {
    const messagesTextareaElement = document.getElementById('messages');
    const authorInputElement = document.querySelector('input[name=author]');
    const contentInputElement = document.querySelector('input[name=content]');

    const submitBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');
    
    const url = 'http://localhost:3030/jsonstore/messenger';

    submitBtn.addEventListener('click', ()=>{
        submitMessage(url);
    })

    refreshBtn.addEventListener('click', ()=>{
        refreshMessages(url);
    })

    function submitMessage(url) {
        const author = authorInputElement.value;
        const content = contentInputElement.value;

        if(author === '' || content === ''){
            return;
        }
        
        const message = {
            author,
            content
        }

        postMessage(url, message);
        
        refreshMessages(url);
    }

    function postMessage(url, message) {
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(message)
        });
    }
    
    async function refreshMessages(url) {
        clearMessagesTextarea();

        try{
            const response = await fetch(url);
            checkResponse(response);
            
            let messages = []

            const data = await response.json();
            Object.values(data).forEach(post => {
                const message = `${post.author}: ${post.content}`;
                messages.push(message);
            })

            messagesTextareaElement.textContent = messages.join('\n');
            
        }catch(err){
            console.dir(err);
        }
    }

    function clearMessagesTextarea(){
        messagesTextareaElement.innerText = '';
    }

    function checkResponse(response){
        if(response.status !== 200){
            throw new Error('Server not respond...');
        }
    }
}

attachEvents();