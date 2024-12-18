function attachEvents2() {
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

function attachEvents1() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const loadPostsButton = document.getElementById('btnLoadPosts');
    const postViewButton = document.getElementById('btnViewPost');
    const selectPostElement = document.getElementById('posts');
    const postBodyElement = document.getElementById('post-body');
    const commentListElement = document.getElementById('post-comments');
    const postTitleElement = document.getElementById('post-title');

    loadPostsButton.addEventListener('click', () => {
        selectPostElement.innerHTML = '';
        
        fetch(postsUrl)
            .then(response => response.json())
            .then(posts => {
                Object.values(posts)
                    .forEach(post => {
                        const optionElement = document.createElement('option');
                        optionElement.value = post.id;
                        optionElement.textContent = post.title;

                        selectPostElement.appendChild(optionElement);
                    })
            });
    });

    postViewButton.addEventListener('click', async () => {
        const selectedPostId = selectPostElement.value;

        const postResponse = await fetch(`${postsUrl}/${selectedPostId}`);
        const selectedPost = await postResponse.json();

        postBodyElement.textContent = selectedPost.body;
        postTitleElement.textContent = selectedPost.title;

        const commentsResponse = await fetch(commentsUrl);
        const comments = await commentsResponse.json();
        const commentsFragment = document.createDocumentFragment();

        Object.values(comments)
            .filter(comment => comment.postId === selectedPostId)
            .forEach(comment => {
                const liElement = document.createElement('li');
                liElement.id = comment.id;
                liElement.textContent = comment.text;

                commentsFragment.appendChild(liElement);
            });
        
        commentListElement.innerHTML = '';
        commentListElement.appendChild(commentsFragment);
    });
}

function attachEvents() {
    const postsURL = 'http://localhost:3030/jsonstore/blog/posts'
    const commentsURL = 'http://localhost:3030/jsonstore/blog/comments'

    let loadPostsButton = document.getElementById('btnLoadPosts')
    loadPostsButton.addEventListener('click', loadPostsEvent)

    let postsSelect = document.getElementById('posts')

    let viewPostButton = document.getElementById('btnViewPost')
    viewPostButton.addEventListener('click', viewPostEvent)

    allPosts = {}

    async function loadPostsEvent(event) {
        postsSelect.innerHTML = ''
        let allPostsResponse = await fetch(postsURL)
        allPosts = await allPostsResponse.json()
        
        for (let postArr of Object.entries(allPosts)) {
            let option = document.createElement('option')
            option.textContent = postArr[1].title
            option.value = postArr[0]
            postsSelect.appendChild(option)
        }
    }

    async function viewPostEvent(event) {
        let currentPostObject = document.getElementById('posts')
        let currentPostComments = []

        let allCommentsResponse = await fetch(commentsURL)
        let allComments = await allCommentsResponse.json()
        
        for (let commentArr of Object.entries(allComments)) {
            if (commentArr[1].postId === currentPostObject.value) {
                currentPostComments.push(commentArr[1].text)
            }
        }

        let chosenPost = allPosts[currentPostObject.value]
    
        let titleElement = document.getElementById('post-title')
        titleElement.textContent = chosenPost.title

        let postContentElement = document.getElementById('post-body')
        postContentElement.textContent = chosenPost.body

        let ul = document.getElementById('post-comments')
        ul.innerHTML = ''
        for (let comment of currentPostComments) {
            let li = document.createElement('li')
            li.textContent = comment
            ul.appendChild(li)
        }
    }
}

attachEvents();