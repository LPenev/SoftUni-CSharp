function solve() {
   const townsElement = document.getElementById('towns');
   const seachedText = document.getElementById('searchText').value;
   const resultElement = document.getElementById('result');

   let matches = 0;

   for(const town of townsElement.children){
      if(town.innerText.includes(seachedText)){
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
         matches++;
      }else{
         town.style.textDecoration = 'none';
         town.style.fontWeight = 'normal';
      }
   }

   resultElement.innerText = `${matches} matches found`;
}