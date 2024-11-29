function loadRepos() {
	const baseUrl = 'https://api.github.com/users';

	const username = document.getElementById('username').value;
	const reposUlElement = document.getElementById('repos');
	reposUlElement.innerHTML = '';

	const url = `${baseUrl}/${username}/repos`;

	fetch(url)
		.then(res => res.json())
		.then(data =>{
			data.forEach(element => {
				const liAElement = createLiAElement(element.full_name, element.html_url); 
				reposUlElement.appendChild(liAElement);
			})
		})
		.catch(error => console.log(error));

	function createLiAElement(name, url){
		const liElement = document.createElement('li');
		const aElement = document.createElement('a');
		const textNode = document.createTextNode(name);
		aElement.appendChild(textNode);
		aElement.href = url;
		liElement.appendChild(aElement);
		return liElement;
	}
}