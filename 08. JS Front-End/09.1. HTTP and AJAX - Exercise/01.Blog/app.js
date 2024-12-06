function attachEvents() {
    const btnLoadPostsElement = document.getElementById('btnLoadPosts');
    const postsSelectElement = document.getElementById('posts');
    const btnViewPostElement = document.getElementById('btnViewPost');
    const postTitleH1Element = document.getElementById('post-title');
    const postBodyPElement = document.getElementById('post-body');
    const postCommentsUlElement = document.getElementById('post-comments');

    const baseUrl = 'http://localhost:3030/jsonstore/blog';
    const postUrl = `${baseUrl}/posts`;
    const commentsUrl = `${baseUrl}/comments`;

    btnLoadPostsElement.addEventListener('click',()=> addPostTitlesIntoSelect(postUrl));
    
    btnViewPostElement.addEventListener('click',()=> {
        const postId = postsSelectElement.value;
        const post = getPostByID(postUrl, postId);
        post.then(x=> {
            const post = Object.values(x);
            const postBody = post[0];
            const postId = post[1];
            const postTitle = post[2];

            setPosttitle(postTitle);
            setPostBody(postBody);
            setCommentsByPostID(postId);
        });
    });

    function setCommentsByPostID(postId){
        const comments = loadAllCommentsByID(commentsUrl,postId);
        postCommentsUlElement.innerHTML = '';

        comments.then(comments => comments.forEach(comment => {
            const liElement = document.createElement('li');
            liElement.innerText = comment.text;
            postCommentsUlElement.appendChild(liElement);
        })
        ).catch(error => console.dir(error));
    }

    async function loadAllCommentsByID(commentsUrl, postId) {
        try{
            const response = await fetch(commentsUrl);
            checkResponse(response);

            const allComments = await response.json();
            const postComments = Object.values(allComments).filter(comment => comment.postId === postId);
            return postComments;
        }catch (error){
            console.dir(error);
        }
    }

    function setPostBody(postBody){
        postBodyPElement.textContent = postBody;
    }

    function setPosttitle(postTitle) {
        postTitleH1Element.textContent = postTitle;
    }

    async function getPostByID(postUrl,postId){
        try{
            const currentPostUrl = `${postUrl}/${postId}`; 
            const response = await fetch(currentPostUrl);
            
            checkResponse(response);
            
            const post = await response.json();
            return post;

        }catch(error){
            console.dir(error);
        }
    }

    async function addPostTitlesIntoSelect(postUrl){
        try{
            const response = await fetch(postUrl);
            
            clearPost();
            checkResponse(response);

            const data = await response.json();
            const posts = Object.values(data);
            
            const selectPostFragment = document.createDocumentFragment();

            posts.forEach( post => {
                const optionElement = document.createElement('option');
                optionElement.value = post.id;
                optionElement.textContent = post.title;
                
                selectPostFragment.appendChild(optionElement);
            })
            
            postsSelectElement.appendChild(selectPostFragment);
    
        }catch (error){
            console.dir(error);
        }
    }

    function checkResponse(response){
        if(response.status !== 200){
            throw new Error('Server not respond...');
        }
    }

    function clearPost(){
        postTitleH1Element.textContent = 'Post Details';
        postBodyPElement.textContent = '';
        postCommentsUlElement.innerHTML = '';
        postsSelectElement.innerHTML = '';
    }
}

attachEvents();