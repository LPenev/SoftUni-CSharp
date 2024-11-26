document.addEventListener('DOMContentLoaded', solve);

function solve() {
   const formElement = document.querySelector('#task-input');
   const divContentElement = document.querySelector('div#content');

   formElement.addEventListener('click', (e)=> {
      e.preventDefault();
      
      if(e.target.type != 'submit'){
         return;
      }
      
      const inputElement = e.currentTarget.querySelector('input[type=text]');
      const sectionsArray = inputElement.value.split(',').map(x=>x.trim());
      const sectionFragment = document.createDocumentFragment();

      for(section of sectionsArray){
          const createDivElement = document.createElement('div');
          const createPElement = document.createElement('p');
          const textNode = document.createTextNode(section);
          createPElement.style.display = 'none';
          createDivElement.addEventListener('click', (e)=>{
            console.dir(e.currentTarget);
            e.currentTarget.querySelector('p').style.display = 'block';
          });

          createPElement.appendChild(textNode);
          createDivElement.appendChild(createPElement);
          sectionFragment.appendChild(createDivElement);
      }

      divContentElement.appendChild(sectionFragment);
   })
}