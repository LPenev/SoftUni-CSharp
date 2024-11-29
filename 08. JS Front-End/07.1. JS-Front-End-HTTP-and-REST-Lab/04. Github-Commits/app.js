function loadCommits() {
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;

    const ulCommitsElement = document.getElementById('commits');

    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    const liFragment = document.createDocumentFragment();

    fetch(url)
        .then(res => res.json())
        .then(data => {
            data.forEach(element => {
                const text = `${element.commit.author.name}: ${element.commit.message}`;
                const liElement = document.createElement('li');
                liElement.textContent = text;
                liFragment.appendChild(liElement);
            });
            ulCommitsElement.appendChild(liFragment);
        })
        .catch();
}