function loadRepos() {
   const url = 'https://api.github.com/users/testnakov/repos';
   const resultDivElement = document.getElementById('res');
   fetch(url)
      .then(res => res.text())
      .then(data => resultDivElement.textContent = data)
      .catch(error => resultDivElement.textContent = 'Error');
}